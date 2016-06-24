using System.Collections.Generic;
using System.Web.Mvc;
using CaptchaMvc.HtmlHelpers;
using CaptchaMvc.Interface;
using CodeChallange.Entity;
using CodeChallange.Service.UserService;

namespace CodeChallange.UI.Controllers
{
    [HandleError]
    public class HomeController : BaseController
    {
        private IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        private List<User> GetUsers(int skip, int take)
        {
            ViewBag.Count = _userService.GetTotalCount();
            return _userService.ListUser(skip, take, x => x.ID.ToString()) ?? new List<User>();
        }

        public ActionResult Index(int skip = 0, int take = 10)
        {
            return View(GetUsers(skip, take));
        }

        public ActionResult Read(int skip = 0, int take = 10)
        {
            return PartialView("_Details", GetUsers(skip, take));            
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var result = _userService.GetUser(id);
            return PartialView(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User model)
        {
            if (ModelState.IsValid && this.IsCaptchaValid("Invalid captcha"))
            {
                ModelState.Clear();

                _userService.AddUser(model);

                return Json(new { message = "Success", isSuccess = true });
            }
            else
            {
                IUpdateInfoModel captchaValue = this.GenerateCaptchaValue(5);
                return Json(new
                {
                    isSuccess = false,
                    message = "Invalid captcha",
                    Captcha =
                        new Dictionary<string, string>
                        {
                            {captchaValue.ImageElementId, captchaValue.ImageUrl},
                            {captchaValue.TokenElementId, captchaValue.TokenValue}
                        }
                });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(User model)
        {
            _userService.UpdateUser(model);

            return Json(new { message = "Success", isSuccess = true });
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            _userService.DeleteUser(id);

            return Json(new { message = "Success", isSuccess = true });
        }


    }
}