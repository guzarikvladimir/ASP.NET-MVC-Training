using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using BLL.Interfaces.Entities;
using BLL.Interfaces.Services;
using MVCPL.Infrastructure;
using MVCPL.Infrastructure.Mappers;

namespace MVCPL.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IExceptionService _exceptionService;

        public AdminController(IUserService service, IRoleService roleService,
            IExceptionService exceptionService)
        {
            _userService = service;
            _roleService = roleService;
            _exceptionService = exceptionService;
        }

        public ActionResult UserManagement(string role, string name,
            int page = 1, int pageSize = 10, SortState sortOrder = SortState.DateAsc)
        {
            var users =
                _userService.GetAllUserEntities()
                .Select(u => u.ToMvcUser());
            if (!string.IsNullOrEmpty(name))
            {
                users = users.Where(u => u.Email.Contains(name));
            }
            if (!string.IsNullOrEmpty(role) && !role.Equals("All"))
            {
                users = users.Where(u => u.Role == role);
            }
            switch (sortOrder)
            {
                case SortState.NameAsc:
                    users = users.OrderBy(u => u.Email);
                    break;
                case SortState.NameDesc:
                    users = users.OrderByDescending(u => u.Email);
                    break;
                case SortState.DateAsc:
                    users = users.OrderBy(u => u.CreationDate);
                    break;
                case SortState.DateDesc:
                    users = users.OrderByDescending(u => u.CreationDate);
                    break;
                default:
                    users = users.OrderBy(u => u.CreationDate);
                    break;
            }

            var pageSizes = new List<int>(20);
            for (var i = 1; i <= 20; i++)
            {
                pageSizes.Add(i);
            }
            
            var viewModel = new UserPagedData()
            {
                PageInfo = new PageInfo() { TotalItems = users.Count(), PageNumber = page, PageSize = pageSize, PageSizes = new SelectList(pageSizes, pageSize) },
                SortInfo = new UserSortInfo(sortOrder),
                FilterInfo = new UserFilterInfo(_roleService.GetAllRoleEntities().Select(r => r.Name).ToList(), role, name),
                Users = users.Skip((page - 1) * pageSize).Take(pageSize).ToList()
            };

            if (Request.IsAjaxRequest())
            {
                return PartialView("UserList", viewModel);
            }
            return View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id = 0)
        {
            var user = await _userService.GetUserEntity(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user.ToMvcUser());
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(UserEntity user)
        {
            _userService.DeleteUser(user);
            return RedirectToAction("UserManagement");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id = 0)
        {
            var user = await _userService.GetUserEntity(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.Roles = new SelectList(_roleService.GetAllRoleEntities(), "Id", "Name", user.RoleId);
            return View(user.ToMvcUser());
        }

        [HttpPost]
        public ActionResult Edit(UserEntity user)
        {
            if (ModelState.IsValid)
            {
                _userService.UpdateUser(user);
                return RedirectToAction("UserManagement");
            }
            return View(user.ToMvcUser());
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id = 0)
        {
            var user = await _userService.GetUserEntity(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user.ToMvcUser());
        }

        public ActionResult ExceptionManagement(int page = 1)
        {
            throw new NotImplementedException();
            //int pageSize = 10;
            //var exceptionsPerPage = _exceptionService.GetAllExceptionEntities().Skip((page - 1) * pageSize).Take(pageSize).Select(e => e.ToMvcException());
            //var pageInfo = new PageInfo()
            //{
            //    PageNumber = page,
            //    PageSize = pageSize,
            //    TotalItems = _exceptionService.GetAllExceptionEntities().Count()
            //};
            //var evm = new PagedData<ExceptionViewModel>() { PageInfo = pageInfo, Data = exceptionsPerPage };
            //return View(evm);
        }
    }
}