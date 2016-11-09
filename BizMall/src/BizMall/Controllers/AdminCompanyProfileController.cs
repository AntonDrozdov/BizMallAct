using BizMall.Data.Repositories.Abstract;
using BizMall.Models.CompanyModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BizMall.Controllers
{
    public class AdminCompanyProfileController : Controller
    {
        private readonly IRepositoryUser _repositoryUser;
        private readonly IRepositoryCompany _repositoryCompany;
        public AdminCompanyProfileController(IRepositoryUser repositoryUser, IRepositoryCompany repositoryCompany) {
            _repositoryUser = repositoryUser;
            _repositoryCompany = repositoryCompany;
        }

        public IActionResult Profile()
        {
            ViewBag.ActiveSubMenu = "Профиль";

            var user = _repositoryUser.GetCurrentUser(User.Identity.Name);
            var Company = _repositoryCompany.GetUserCompany(user);

            switch (Company.AccountType)
            {
                case AccountType.Company: 
                        return View("CompanyProfileEditView");
                        break;
                case AccountType.PrivatePerson: 
                        return View("PrivatePersonProfileEditView");
                        break;
                default: 
                        return View("PrivatePersonProfileEditView");
                        break;
            }
        }
    }
}
