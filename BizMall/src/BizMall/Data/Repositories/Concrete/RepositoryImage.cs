using System.Linq;
using BizMall.Data.DBContexts;
using BizMall.Data.Repositories.Abstract;
using BizMall.Models.CommonModels;
using BizMall.Models.CompanyModels;
using Microsoft.EntityFrameworkCore;

namespace BizMall.Data.Repositories.Concrete
{
    public class RepositoryImage : RepositoryBase, IRepository, IRepositoryImage  
    {
        public RepositoryImage(ApplicationDbContext ctx) : base(ctx)
        {
           
        }

        public Image SaveImage(Image item)
        {
            _ctx.Images.Add(item);
            _ctx.SaveChanges();
            return item; 
        }

        public void DeleteImage(int imageId) {
            Image image = _ctx.Images.Where(i => i.Id == imageId).FirstOrDefault();
            _ctx.Images.Remove(image);
            _ctx.SaveChanges();
        }

        public void DeleteAllGoodImages(int goodId) {
            Good dbEntry = _ctx.Goods.Where(g => g.Id == goodId)
                       .Include(g => g.Category)
                       .Include(g => g.Category.ParentCategory)
                       .Include(g => g.Images)
                       .SingleOrDefault();

            dbEntry.Images.Clear();
            _ctx.Entry(dbEntry).State = EntityState.Modified;
            _ctx.SaveChanges();
        }

        public Image GetImage(int ImageId) {
            return _ctx.Images.Where(i => i.Id == ImageId).SingleOrDefault();
        }

        public Image GetGoodImage(int GoodId)
        {
            //return _ctx.Images.Where(i => i.GoodId == GoodId).SingleOrDefault();
            return null;
        }
    }
}
