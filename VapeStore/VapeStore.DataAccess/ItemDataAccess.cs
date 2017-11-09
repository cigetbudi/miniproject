using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VapeStore.DataModel;
using VapeStore.ViewModel;

namespace VapeStore.DataAccess
{
    public class ItemDataAccess
    {
            public static string Message = string.Empty;

            public static List<ItemViewModel> GetAll()
            {
                List<ItemViewModel> result = new List<ItemViewModel>();
                using (var db = new VapeContext())
                {
                    result = (from ite in db.Mst_Item
                              join cat in db.Mst_Category on ite.CategoryCode equals cat.CategoryCode
                              select new ItemViewModel
                              {
                                  Id = ite.Id,
                                  ItemCode = ite.ItemCode,
                                  ItemName = ite.ItemName,
                                  CategoryCode = ite.CategoryCode,
                                  CategoryName = cat.CategoryName,
                                  Description = ite.Description,
                                  Stock = ite.Stock,
                                  IsActive = ite.IsActive
                              }).ToList();

                }
                return result;
            }

            public static ItemViewModel GetById(int id)
            {
                ItemViewModel result = new ItemViewModel();
                using (var db = new VapeContext())
                {
                    result = (from ite in db.Mst_Item
                              join cat in db.Mst_Category on ite.CategoryCode equals cat.CategoryCode
                              where ite.Id == id
                              select new ItemViewModel
                              {
                                  Id = ite.Id,
                                  ItemCode = ite.ItemCode,
                                  ItemName = ite.ItemName,
                                  CategoryCode = ite.CategoryCode,
                                  CategoryName = cat.CategoryName,
                                  Description = ite.Description,
                                  Stock = ite.Stock,
                                  IsActive = ite.IsActive
                              }).FirstOrDefault();

                }
                return result;
            }



            public static bool Update(ItemViewModel model)
            {
                bool result = true;
                try
                {
                    using (var db = new VapeContext())
                    {
                        if (model.Id == 0)
                        {
                            Mst_Item ite = new Mst_Item();
                            ite.ItemCode = model.ItemCode;
                            ite.ItemName = model.ItemName;
                            ite.CategoryCode = model.CategoryCode;
                            ite.Description = model.Description;
                            ite.Stock = ite.Stock;
                            ite.IsActive = model.IsActive;
                            db.Mst_Item.Add(ite);
                            db.SaveChanges();
                        }
                        else
                        {
                            Mst_Item ite = db.Mst_Item.Where(o => o.Id == model.Id).FirstOrDefault();
                            if (ite != null)
                            {
                                ite.ItemCode = model.ItemCode;
                                ite.ItemName = model.ItemName;
                                ite.CategoryCode = model.CategoryCode;
                                ite.Description = ite.Description;
                                ite.Stock = ite.Stock;
                                ite.IsActive = model.IsActive;
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

            public static List<ItemViewModel> GetByCategory(string categoryCode)
            {
                List<ItemViewModel> result = new List<ItemViewModel>();
                using (var db = new VapeContext())
                {
                    result = (from ite in db.Mst_Item
                              join cat in db.Mst_Category
                                  on ite.CategoryCode equals cat.CategoryCode
                              where ite.CategoryCode == categoryCode
                              select new ItemViewModel
                              {
                                  Id = ite.Id,
                                  ItemCode = ite.ItemCode,
                                  ItemName = ite.ItemName,
                                  CategoryCode = ite.CategoryCode,
                                  Description = ite.Description,
                                  Stock = ite.Stock,
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
                        Mst_Item ite = db.Mst_Item.Where(o => o.Id == id).FirstOrDefault();
                        if (ite != null)
                        {
                            db.Mst_Item.Remove(ite);
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


  