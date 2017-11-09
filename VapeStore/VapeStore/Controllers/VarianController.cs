using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VapeStore.DataAccess;
using VapeStore.ViewModel;

namespace VapeStore.Controllers
{
    public class VarianController : Controller
    {
        //
        // GET: /Varian/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            return View(VarianDataAccess.GetAll());
        }

        public ActionResult GetByItem(string itemCode)
        {
            return View(VarianDataAccess.GetByItem(itemCode));
        }


        public ActionResult Create()
        {
            ViewBag.CategoryList = new SelectList(CategoryDataAccess.GetAll(), "CategoryCode", "CategoryName");

            ViewBag.ItemList = new SelectList(ItemDataAccess.GetByCategory(""), "ItemCode", "ItemName");

            return View();
        }

        [HttpPost]
        public ActionResult Create(VarianViewModel model)
        {
            return CreateEdit(model);
        }
        [HttpPost]
        public ActionResult CreateEdit(VarianViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (VarianDataAccess.Update(model))
                    {
                        return Json(new { success = true, message = "berhasil" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, message = VarianDataAccess.Message }, JsonRequestBehavior.AllowGet);
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
            VarianViewModel model = VarianDataAccess.GetById(id);

            ViewBag.CategoryList = new SelectList(CategoryDataAccess.GetAll(), "CategoryCode", "CategoryName");

            ViewBag.ItemList = new SelectList(ItemDataAccess.GetByCategory(model.CategoryCode), "ItemCode", "ItemName");

            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(VarianViewModel model)
        {
            return CreateEdit(model);
        }

        public ActionResult Delete(int id)
        {
            return View(VarianDataAccess.GetById(id));
        }
        [HttpPost]
        public ActionResult DeleteConfirm(int id)
        {
            if (VarianDataAccess.Delete(id))
            {
                return Json(new { success = true, message = "Sukses" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, message = VarianDataAccess.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}