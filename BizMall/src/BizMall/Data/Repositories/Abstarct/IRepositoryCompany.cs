using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BizMall.Models;
using BizMall.Models.CompanyModels;
using BizMall.ViewModels.AccountViewModels;

namespace BizMall.Data.Repositories.Abstract
{
    public interface IRepositoryCompany
    {
        IEnumerable<Company> GetAllCompanies();
        Company GetUserCompany(ApplicationUser currentUser);
        Company GetCompany(int companyId);
        Company CreateDefaultUserCompany(string userId);
        Company CreateCompanyAccount(string userId, CreateEditCompanyViewModel model);
        Company CreatePrivatePersonAccount(string userId, CreateEditCompanyViewModel model);
    }
}
