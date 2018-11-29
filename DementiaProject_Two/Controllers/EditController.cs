using DementiaProject_Two.Models.Account;
using DementiaProject_Two.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DementiaProject_Two.Controllers
{
    public class EditController : Controller
    {
        private IRepository repo;

        public UserInformationModel UserInfo { get; set; }

        public EditController(IRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult EditProfil(UserInformationModel userModel)
        {
            UserInfo = repo.Get(userModel.Id);
            if (UserInfo == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        //public IActionResult OnPost()
        //{
        //    if (ModelState.IsValid)
        //    {
        //        repo.Update(UserInfo);
        //        return RedirectToAction("Index", "Home");
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}
    }
}