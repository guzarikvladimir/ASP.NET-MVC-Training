using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using BLL.Interfaces.Entities;
using BLL.Interfaces.Services;
using MVCPL.Infrastructure.Mappers;

namespace MVCPL.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly ITaskService _taskService;

        public HomeController(IUserService service, ITaskService taskService)
        {
            _userService = service;
            _taskService = taskService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.AuthType = User.Identity.AuthenticationType;
            }
            ViewBag.Login = User.Identity.Name;
            ViewBag.IsAdminInRole = User.IsInRole("Administrator")
                ? "You have administrator rights."
                : "You do not have administrator rights.";

            return View();
        }

        [HttpGet]
        public ActionResult Tasks(string email)
        {
            var user = _userService.GetUserByEmail(email);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user.ToMvcUser());
        }

        public async Task<RedirectToRouteResult> MarkProgress(int userId = 0, int taskId = 0, int points = 0)
        {
            _taskService.UpdateUserTaskEntity(new UserTaskEntity()
            {
                UserId = userId,
                TaskId = taskId,
                PointsCompleted = ++points
            });
            var email = await _userService.GetUserEntity(userId);
            return RedirectToAction("Tasks", email);
        }

        public ActionResult AutocompleteSearch(string term)
        {
            var models = _userService.SearchUsersByEmail(term)
                .Select(u => new { value = u.Email });
            //var models = _userService.Find(u => u.Email.Contains(term))
            //    .Select(u => new {value = u.Email});

            return Json(models, JsonRequestBehavior.AllowGet);
        }
    }
}