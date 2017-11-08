using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VapeStore.DataModel;
using VapeStore.ViewModel;

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
    }
}
