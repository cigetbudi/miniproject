using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VapeStore.DataAccess;
using VapeStore.ViewModel;

namespace VapeStore.Controllers
{
    public class ItemController : Controller
    {
        //
        // GET: /Item/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetByCategory(string categoryCode)
        {
            return View(ItemDataAccess.GetByCategory(categoryCode));
        }


        public ActionResult List()
        {
            return View(ItemDataAccess.GetAll());
        }
        public ActionResult Create()
        {
            ViewBag.CategoryList = new SelectList(CategoryDataAccess.GetAll(), "CategoryCode", "CategoryName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(ItemViewModel model)
        {
            return CreateEdit(model);
        }
        [HttpPost]
        public ActionResult CreateEdit(ItemViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (ItemDataAccess.Update(model))
                    {
                        return Json(new { success = true, message = "berhasil" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, mesage = ItemDataAccess.Message }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { succes = false, message = "Please full fill required fields!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);

            }
        }
        public ActionResult Edit(int id)
        {
            ViewBag.CategoryList = new SelectList(CategoryDataAccess.GetAll(), "CategoryCode", "CategoryName");
            return View(ItemDataAccess.GetById(id));
        }
        [HttpPost]
        public ActionResult Edit(ItemViewModel model)
        {
            return CreateEdit(model);
        }

        public ActionResult Delete(int id)
        {
            return View(ItemDataAccess.GetById(id));
        }
        [HttpPost]
        public ActionResult DeleteConfirm(int id)
        {
            if (ItemDataAccess.Delete(id))
            {
                return Json(new { success = true, message = "Sukses" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, message = ItemDataAccess.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}