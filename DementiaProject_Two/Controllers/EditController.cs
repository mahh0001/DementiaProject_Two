using DementiaProject_Two.Models.Account;
using DementiaProject_Two.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DementiaProject_Two.Pages
{
    public class EditController : Controller
    {
        private IRepository repo;

        [BindProperty]
        public UserInformationModel UserInfo { get; set; }

        public EditController(IRepository repo)
        {
            this.repo = repo;
        }
        public IActionResult EditProfil(UserInformationModel userModel)
        {
            UserInfo = repo.Get(userModel.Id);
            if (UserInfo == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                repo.Update(UserInfo);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
    }
}