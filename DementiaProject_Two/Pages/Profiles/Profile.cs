using DementiaProject_Two.Models.Account;
using DementiaProject_Two.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DementiaProject_Two.Controllers
{
    public class ProfileModel : PageModel
    {
        private IRepository repo;
        public UserInformationModel UserInfo { get; set; }

        public ProfileModel(IRepository repo)
        {
            this.repo = repo;
        }

        [HttpPost]
        public IActionResult EditProfil([Bind(include:"FirstName, LastName, Gender, Id, ZipCode, Picture")] UserInformationModel userModel)
        {
            UserInfo = repo.Get(userModel.Id);
            if (UserInfo == null)
            {
                return null;
            }
            else
            {
                return null;
            }
        }

    }
}