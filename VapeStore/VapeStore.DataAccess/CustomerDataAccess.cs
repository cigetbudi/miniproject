using VapeStore.DataModel;
using VapeStore.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VapeStore.DataAccess
{
    public class CustomerDataAccess
    {
        public static string Message = string.Empty;

        public static List<CustomerViewModel> GetAll()
        {
            List<CustomerViewModel> result = new List<CustomerViewModel>();
            using (var db = new VapeContext())
            {
                result = (from cus in db.Mst_Customer
                          select new CustomerViewModel
                {
                    Id = cus.Id,
                    CostumerName = cus.CostumerName,
                    Address = cus.Address,
                    Email = cus.Email,
                    Phone = cus.Phone,
                    IsActive = cus.IsActive
                }).ToList();
            }
            return result;
        }

        public static CustomerViewModel GetById(int id)
        {
            CustomerViewModel result = new CustomerViewModel();
            using (var db = new VapeContext())
            {
                result = (from cus in db.Mst_Customer
                          where cus.Id ==id
                          select new CustomerViewModel
                          {
                              Id = cus.Id,
                              CostumerName = cus.CostumerName,
                              Address = cus.Address,
                              Email = cus.Email,
                              Phone = cus.Phone,
                              IsActive = cus.IsActive
                          }).FirstOrDefault();
            }
            return result;
        }

        public static bool Update (CustomerViewModel model)
        {
            bool result = true;
            try
            {
                using (var db = new VapeContext())
                {
                    if (model.Id==0)
                    {
                        Mst_Customer cus = new Mst_Customer();
                        cus.CostumerName = model.CostumerName;
                        cus.Address = model.Address;
                        cus.Email = model.Email;
                        cus.Phone = model.Phone;
                        cus.IsActive = model.IsActive;
                        db.Mst_Customer.Add(cus);
                        db.SaveChanges();

                    }

                    else
                    {
                        Mst_Customer cus = db.Mst_Customer.Where(o => o.Id == model.Id).FirstOrDefault();
                        if (cus != null)
                        {
                            cus.CostumerName = model.CostumerName;
                            cus.Address = model.Address;
                            cus.Email = model.Email;
                            cus.Phone = model.Phone;
                            cus.IsActive = model.IsActive;
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

        public static bool Delete (int id)
        {
            bool result = true;
            try
            {
                using(var db = new VapeContext())
                {
                    Mst_Customer cus = db.Mst_Customer.Where(o => o.Id == id).FirstOrDefault();
                    if (cus !=null)
                    {
                        db.Mst_Customer.Remove(cus);
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
