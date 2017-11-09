using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VapeStore.DataModel;
using VapeStore.ViewModel;

namespace VapeStore.DataAccess
{
    public class VarianDataAccess
    {
        public static string Message = string.Empty;

        public static List<VarianViewModel> GetAll()
        {
            List<VarianViewModel> result = new List<VarianViewModel>();
            using (var db = new VapeContext())
            {
                result = (from var in db.Mst_Varian
                          join ite in db.Mst_Item on var.ItemCode equals ite.ItemCode
                          select new VarianViewModel
                          {
                              Id = var.Id,
                              VarianCode = var.VarianCode,
                              VarianName = var.VarianName,
                              ItemCode = var.ItemCode,
                              ItemName = ite.ItemName,
                              Country = var.Country,
                              Strength = var.Strength,
                              PGVG = var.PGVG,
                              Size = var.Size,
                              Price = var.Price,
                              Unit = var.Unit,
                              IsActive = var.IsActive,
                          }).ToList();

            }
            return result;
        }

        public static VarianViewModel GetById(int id)
        {
            VarianViewModel result = new VarianViewModel();
            using (var db = new VapeContext())
            {
                result = (from var in db.Mst_Varian
                          join ite in db.Mst_Item on var.ItemCode equals ite.ItemCode into itelf
                          from ite in itelf.DefaultIfEmpty()
                          join cat in db.Mst_Category on ite.CategoryCode equals cat.CategoryCode into catlf
                          from cat in catlf.DefaultIfEmpty()
                          where var.Id == id
                          select new VarianViewModel
                          {
                              Id = var.Id,
                              VarianCode = var.VarianCode,
                              VarianName = var.VarianName,
                              CategoryCode = ite.CategoryCode,
                              ItemCode = var.ItemCode,
                              ItemName = ite.ItemName,
                              Country = var.Country,
                              Strength = var.Strength,
                              PGVG = var.PGVG,
                              Size = var.Size,
                              Price = var.Price,
                              Unit = var.Unit,
                              IsActive = var.IsActive,
                          }).FirstOrDefault();

            }
            return result;
        }



        public static bool Update(VarianViewModel model)
        {
            bool result = true;
            try
            {
                using (var db = new VapeContext())
                {
                    if (model.Id == 0)
                    {
                        Mst_Varian var = new Mst_Varian();
                              var.VarianCode = model.VarianCode;
                              var.VarianName = model.VarianName;
                              var.ItemCode = model.ItemCode;
                              var.Country = model.Country;
                              var.Strength = model.Strength;
                              var.PGVG = model.PGVG;
                              var.Size = model.Size;
                              var.Price = model.Price;
                              var.Unit = model.Unit;
                              var.IsActive = model.IsActive;
       
                        db.Mst_Varian.Add(var);
                        db.SaveChanges();


                    }
                    else
                    {
                        Mst_Varian var = db.Mst_Varian.Where(o => o.Id == model.Id).FirstOrDefault();
                        if (var != null)
                        {
                            var.VarianCode = model.VarianCode;
                            var.VarianName = model.VarianName;
                            var.ItemCode = model.ItemCode;
                            var.Country = model.Country;
                            var.Strength = model.Strength;
                            var.PGVG = model.PGVG;
                            var.Size = model.Size;
                            var.Price = model.Price;
                            var.Unit = model.Unit;
                            var.IsActive = model.IsActive;
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

        public static List<VarianViewModel> GetByItem(string itemCode)
        {
            List<VarianViewModel> result = new List<VarianViewModel>();
            using (var db = new VapeContext())
            {
                result = (from var in db.Mst_Varian
                          join ite in db.Mst_Item
                              on var.ItemCode equals ite.ItemCode
                          where var.ItemCode == itemCode
                          select new VarianViewModel
                          {
                              Id = var.Id,
                              VarianCode = var.VarianCode,
                              VarianName = var.VarianName,
                              ItemCode = var.ItemCode,
                              ItemName = ite.ItemName,
                              Country = var.Country,
                              Strength = var.Strength,
                              PGVG = var.PGVG,
                              Size = var.Size,
                              Price = var.Price,
                              Unit = var.Unit,
                          }).ToList();
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
                    Mst_Varian var = db.Mst_Varian.Where(o => o.Id == id).FirstOrDefault();
                    if (var != null)
                    {
                        db.Mst_Varian.Remove(var);
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


