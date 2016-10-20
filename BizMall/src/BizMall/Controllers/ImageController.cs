using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BizMall.Data.Repositories.Abstract;
using BizMall.Models.CommonModels;
using BizMall.Models.CompanyModels;
using System.IO;
using BizMall.ViewModels.AdminCompanyGoods;
using BizMall.Utils;
using Microsoft.AspNetCore.Http;

namespace BizMall.Controllers
{
    public class ImageController : Controller
    {
        private readonly IRepositoryImage _repositoryImage;

        public ImageController(IRepositoryImage repositoryImage) {
            _repositoryImage = repositoryImage;
        }


    }
}