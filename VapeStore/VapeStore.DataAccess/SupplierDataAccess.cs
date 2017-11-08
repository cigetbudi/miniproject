using VapeStore.ViewModel;
using VapeStore.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VapeStore.DataAccess
{
   public class SupplierDataAccess
    {
       public static string Message = string.Empty;

       public static List<SupplierViewModel> GetAll()
       {
           List<SupplierViewModel> result = new List<SupplierViewModel>();
           using (var db = new VapeContext())
           {
               result = (from sup in db.Mst_Supplier
                         select new SupplierViewModel
                         {
                             Id = sup.Id,
                             SupplierCode = sup.SupplierCode,
                             SupplierName =sup.SupplierName,
                             Address = sup.Address,
                             Phone = sup.Phone,
                             IsActive = sup.IsActive
                         }).ToList();

           }
           return result;
       }

       public static SupplierViewModel GetById(int id)
       {
           SupplierViewModel result = new SupplierViewModel();
           using (var db = new VapeContext())
           {
               result = (from sup in db.Mst_Supplier
                         select new SupplierViewModel
                         {
                             Id = sup.Id,
                             SupplierCode = sup.SupplierCode,
                             SupplierName = sup.SupplierName,
                             Address = sup.Address,
                             Phone = sup.Phone,
                             IsActive = sup.IsActive
                         }).FirstOrDefault();

           }
           return result;
       }



       public static bool Update(SupplierViewModel model)
       {
           bool result = true;
           try
           {
               using (var db = new VapeContext())
               {
                   if (model.Id==0)
                   {
                       Mst_Supplier sup = new Mst_Supplier();
                       sup.SupplierCode = model.SupplierCode;
                       sup.SupplierName = model.SupplierName;
                       sup.Address = model.Address;
                       sup.Phone = model.Phone;
                       sup.IsActive = model.IsActive;
                       db.Mst_Supplier.Add(sup);
                       db.SaveChanges();
                   }
                   else
                   {
                       Mst_Supplier sup = db.Mst_Supplier.Where(o => o.Id == model.Id).FirstOrDefault();
                       if (sup != null)
                       {
                           sup.SupplierCode = model.SupplierCode;
                           sup.SupplierName = model.SupplierName;
                           sup.Address = model.Address;
                           sup.Phone = model.Phone;
                           sup.IsActive = model.IsActive;
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
                   Mst_Supplier sup = db.Mst_Supplier.Where(o => o.Id == id).FirstOrDefault();
                   if (sup !=null)
                   {
                       db.Mst_Supplier.Remove(sup);
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
