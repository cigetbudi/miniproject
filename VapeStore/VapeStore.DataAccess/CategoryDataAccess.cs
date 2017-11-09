using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VapeStore.DataModel;
using VapeStore.ViewModel;

namespace VapeStore.DataAccess
{
    public class CategoryDataAccess
    {
        public static string Message = string.Empty;

        public static List<CategoryViewModel> GetAll()
        {
            List<CategoryViewModel> result = new List<CategoryViewModel>();
            using (var db = new VapeContext())
            {
                result = (from cat in db.Mst_Category
                          select new CategoryViewModel
                          {
                              Id = cat.Id,
                              CategoryCode = cat.CategoryCode,
                              CategoryName = cat.CategoryName,
                              IsActive = cat.IsActive
                          }).ToList();

            }
            return result;
        }

        public static CategoryViewModel GetById(int id)
        {
            CategoryViewModel result = new CategoryViewModel();
            using (var db = new VapeContext())
            {
                result = (from cat in db.Mst_Category
                          where cat.Id == id
                          select new CategoryViewModel
                          {
                              Id = cat.Id,
                              CategoryCode = cat.CategoryCode,
                              CategoryName = cat.CategoryName,
                              IsActive = cat.IsActive
                          }).FirstOrDefault();

            }
            return result;
        }



        public static bool Update(CategoryViewModel model)
        {
            bool result = true;
            try
            {
                using (var db = new VapeContext())
                {
                    if (model.Id == 0)
                    {
                        Mst_Category cat = new Mst_Category();
                        cat.CategoryCode = model.CategoryCode;
                        cat.CategoryName = model.CategoryName;
                        cat.IsActive = model.IsActive;
                        db.Mst_Category.Add(cat);
                        db.SaveChanges();
                    }
                    else
                    {
                        Mst_Category cat = db.Mst_Category.Where(o => o.Id == model.Id).FirstOrDefault();
                        if (cat != null)
                        {
                            cat.CategoryCode = model.CategoryCode;
                            cat.CategoryName = model.CategoryName;
                            cat.IsActive = model.IsActive;
                            db.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                result = false;
            }
            return result;
        }

        public static bool Delete(int id)
        {
            bool result = true;
            try
            {
                using (var db = new VapeContext())
                {
                    Mst_Category cat = db.Mst_Category.Where(o => o.Id == id).FirstOrDefault();
                    if (cat != null)
                    {
                        db.Mst_Category.Remove(cat);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                result = false;
            }
            return result;
        }
    }
}
