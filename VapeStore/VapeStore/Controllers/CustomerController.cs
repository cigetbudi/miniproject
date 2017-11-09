using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VapeStore.DataAccess;
using VapeStore.ViewModel;

namespace VapeStore.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            return View(CustomerDataAccess.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create (CustomerViewModel model)
        {
            return CreateEdit(model);
        }

        [HttpPost]
        public ActionResult CreateEdit (CustomerViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (CustomerDataAccess.Update(model))
                    {
                        return Json(new{success = true, message = "berhasil"},JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new{success = false , message = CustomerDataAccess.Message},JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { success = false, message = "Isi data dulu dengan benar!" },JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {

                return Json(new {success = false , message = ex.Message },JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Edit (int id)
        {
            return View(CustomerDataAccess.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(CustomerViewModel model)
        {
            return CreateEdit(model);
        }

        public ActionResult Delete (int id)
        {
            return View(CustomerDataAccess.GetById(id));
        }
        [HttpPost]
        public ActionResult DeleteConfirm (int id)
        {
            if (CustomerDataAccess.Delete(id))
            {
                return Json (new{success = true, message = "Sukses" },JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json (new{success= false, message = CustomerDataAccess.Message},JsonRequestBehavior.AllowGet);
            }
        }
    }
}