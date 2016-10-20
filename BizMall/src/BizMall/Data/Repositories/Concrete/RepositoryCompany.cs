using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BizMall.Models;
using BizMall.Models.CompanyModels;
using BizMall.Data.DBContexts;
using BizMall.Data.Repositories.Abstract;
using BizMall.Data.Repositories.Concrete;
using Microsoft.EntityFrameworkCore;
using BizMall.ViewModels.AccountViewModels;

namespace BizMall.Data.Repositories.Concrete
{
    //Сам context наследуем из RepositoryBase
    public class RepositoryCompany : RepositoryBase, IRepository, IRepositoryCompany
    {
        public RepositoryCompany(ApplicationDbContext ctx) : base(ctx)
        {
        }

        public Company CreateCompanyAccount(string userId, CreateEditCompanyViewModel model)
        {
            var company = new Company {
                ApplicationUserId = userId,
                AccountType = AccountType.Company,
                Title = model.Name,
                Description = model.ActivityDescription,
                ContactEmail = model.Email,
                Telephone = model.Telephone                
            };

            _ctx.Companies.Add(company);
            _ctx.SaveChanges();
            return company;
            throw new NotImplementedException();
        }

        public Company CreateDefaultUserCompany(string userId)
        {
            var company = new Company { Title = "Моя компания", ApplicationUserId = userId};
            _ctx.Companies.Add(company);
            _ctx.SaveChanges();
            return company;
        }

        public Company CreatePrivatePersonAccount(string userId, CreateEditCompanyViewModel model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Company> GetAllCompanies()
        {
            throw new NotImplementedException();
        }

        public Company GetCompany(int shopId)
        {
            throw new NotImplementedException();
        }

        public Company GetUserCompany(ApplicationUser User)
        {
            var company = _ctx.Companies.Where(s => s.ApplicationUserId == User.Id).Include(s => s.Goods).FirstOrDefault();
            return company;
        }
    }
}
