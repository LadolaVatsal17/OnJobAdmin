using AdminEntity.AdminModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnJobAdmin.Controllers
{
    public class JobAttribute_CategoryController : Controller
    {
        AdminBal.Bal.Admin_Bal _adminBal = new AdminBal.Bal.Admin_Bal();
        AdminEntity.AdminModel.Admin _adminModel = new AdminEntity.AdminModel.Admin();
        AdminEntity.AdminModel.Category _category = new AdminEntity.AdminModel.Category();
        
        [Authorize]
        public ActionResult Index()
        {
            _adminModel.lstCategory = _adminBal.GetCategory();
            return View(_adminModel);
        }

        [Authorize]
        public ActionResult AddCategory()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddCategory(Category Objcategory)
        {
            if (ModelState.IsValid)
            {
                int result;
                result = _adminBal.AddCategory(Objcategory);
                if (result == 1)
                {
                    TempData["Message"] = "4";
                    ModelState.Clear();
                    
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Message"] = "5";
                    ModelState.Clear();

                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        [Authorize]
        public ActionResult UpdateCategory(int id)
        {
            _category = _adminBal.GetCategoryDetailsById(id);
            
            return View(_category);
        }

        [Authorize]
        [HttpPost]
        public ActionResult UpdateCategory(Category ObjCategory)
        {
            if (ModelState.IsValid)
            {
                ObjCategory = _adminBal.EditCategory(ObjCategory);
                TempData["Message"] = "2";

                return RedirectToAction("index");
            }
            else
            {
                TempData["Message"] = "3";
                return RedirectToAction("index");
            }
        }

        [Authorize]
        public JsonResult CategoryDisable(int id)
        {
            _adminBal.CategoryInactive(id);
           
            return Json("Disable Successfull!");
        }
    }
}