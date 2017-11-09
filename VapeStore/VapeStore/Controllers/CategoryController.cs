using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VapeStore.DataAccess;
using VapeStore.ViewModel;

namespace VapeStore.Controllers
{
    public class CategoryController : Controller
    {
        //
        // GET: /Category/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            return View(CategoryDataAccess.GetAll());
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CategoryViewModel model)
        {
            return CreateEdit(model);
        }
        [HttpPost]
        public ActionResult CreateEdit(CategoryViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (CategoryDataAccess.Update(model))
                    {
                        return Json(new { success = true, message = "berhasil" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, mesage = CategoryDataAccess.Message }, JsonRequestBehavior.AllowGet);
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
            return View(CategoryDataAccess.GetById(id));
        }
        [HttpPost]
        public ActionResult Edit(CategoryViewModel model)
        {
            return CreateEdit(model);
        }

        public ActionResult Delete(int id)
        {
            return View(CategoryDataAccess.GetById(id));
        }
        [HttpPost]
        public ActionResult DeleteConfirm(int id)
        {
            if (CategoryDataAccess.Delete(id))
            {
                return Json(new { success = true, message = "Sukses" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, message = CategoryDataAccess.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}