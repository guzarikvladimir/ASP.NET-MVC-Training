using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using BLL.Interfaces.Entities;
using BLL.Interfaces.Services;
using MVCPL.Infrastructure;
using MVCPL.Infrastructure.Mappers;
using MVCPL.Models;
using Ninject.Infrastructure.Language;

namespace MVCPL.Controllers
{
    [Authorize(Roles = "Administrator, Moderator")]
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly IUserService _userService;

        public TaskController(ITaskService taskService, IUserService userService)
        {
            _taskService = taskService;
            _userService = userService;
        }

        public ActionResult TaskManagement(int page = 1)
        {
            var pageSize = 10;
            var tasks = _taskService.GetAllTaskEntities().Select(t => t.ToMvcTask());
            var viewModel = new TaskPagedData()
            {
                PageInfo = new PageInfo() { TotalItems = tasks.Count(), PageNumber = page, PageSize = pageSize },
                Tasks = tasks.Skip((page - 1) * pageSize).Take(pageSize).ToList()
            };
            return View(viewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TaskViewModel task)
        {
            if (ModelState.IsValid)
            {
                task.CreationDateTime = DateTime.Now;
                task.PointsCompleted = 0;
                task.StatusId = 1;
                _taskService.CreateTask(task.ToBllTask());
                var newTask = _taskService.GetTaskByTitle(task.Title);
                return RedirectToAction("Assign", new { id = newTask.Id });
            }
            return View(task);
        }

        public async Task<ActionResult> Assign(int id = 0)
        {
            var task = await _taskService.GetTaskEntity(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            ViewBag.Users = _userService.GetAllUserEntities()
                .Select(u => u.ToMvcUser())
                .Where(u => u.Role == "User" && !task.Users.Exists(ut => ut.Id == u.Id)).ToList();
            return View(task.ToMvcTask());
        }

        [HttpPost]
        public async Task<ActionResult> Assign(TaskViewModel task, int[] selectedUsers)
        {
            var newTask = await _taskService.GetTaskEntity(task.Id);
            newTask.Users.Clear();
            if (selectedUsers != null)
            {
                foreach (var userId in selectedUsers)
                {
                    newTask.Users.Add(new UserEntity() { Id = userId });
                }

                if (newTask.Users.Count != 0)
                {
                    _taskService.AssignTask(newTask);
                }

                return View("SendEmail", newTask.Users.Select(u => u.Id));
            }
            return RedirectToAction("TaskManagement");
        }

        [HttpPost]
        public async Task<ActionResult> SendEmail(string email, string password, int[] users)
        {
            var hostName = string.Empty;
            if (Request.RequestContext.HttpContext.Request.Url != null)
                hostName = Request.RequestContext.HttpContext.Request.Url.Authority;

            foreach (var id in users)
            {
                var userToSend = await _userService.GetUserEntity(id);
                MailSender.SendEmail(
                    email,
                    userToSend.Email,
                    "New task",
                    $"Здравствуйте!<br/>У вас новое задание. Вы можете ознакомиться с ним перейдя по ссылке <a href=\"http://{hostName}/{userToSend.Email}/MyTasks\">http://{hostName}/{userToSend.Email}/MyTasks</a>.",
                    email,
                    password);
            }
            return RedirectToAction("TaskManagement");
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id = 0)
        {
            var task = await _taskService.GetTaskEntity(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            ViewBag.Users = _userService.GetAllUserEntities()
                .Where(u => task.Users.Exists(tu => tu.Id == u.Id))
                .Select(u => u.ToMvcUser()).ToList();
            ViewBag.Statuses = new SelectList(_taskService.GetAllStatuses, "id", "Name");
            return View(task.ToMvcTask());
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id = 0)
        {
            var task = await _taskService.GetTaskEntity(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(TaskEntity task)
        {
            _taskService.DeleteTask(task);
            return RedirectToAction("TaskManagement");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id = 0)
        {
            var task = await _taskService.GetTaskEntity(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            ViewBag.Statuses = new SelectList(_taskService.GetAllStatuses, "id", "Name", task.StatusId);
            return View(task.ToMvcTask());
        }

        [HttpPost]
        public ActionResult Edit(TaskEntity task)
        {
            if (ModelState.IsValid)
            {
                _taskService.UpdateTask(task);
                return RedirectToAction("TaskManagement");
            }
            return View(task.ToMvcTask());
        }

        [HttpGet]
        public ActionResult ChangeStatus(string name, int userId = 0, int taskId = 0)
        {
            _taskService.UpdateUserTaskEntity(new UserTaskEntity()
            {
                UserId = userId,
                TaskId = taskId,
                StatusId = _taskService.GetAllStatuses.FirstOrDefault(s => s.Name == name).Id
            });
            return RedirectToAction("Details", new { id = taskId });
        }
    }
}