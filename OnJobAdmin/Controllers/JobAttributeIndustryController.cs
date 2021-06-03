using AdminEntity.AdminModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnJobAdmin.Controllers
{
    public class JobAttributeIndustryController : Controller
    {
        AdminBal.Bal.Admin_Bal _adminBal = new AdminBal.Bal.Admin_Bal();
        AdminEntity.AdminModel.Admin _adminModel = new AdminEntity.AdminModel.Admin();
        AdminEntity.AdminModel.Industry _industry = new AdminEntity.AdminModel.Industry();
        // GET: JobAttributeIndustry
        public ActionResult Index()
        {
            _adminModel.lstIndustry = _adminBal.GetIndustry();
            return View(_adminModel);
        }

        [Authorize]
        public ActionResult AddIndustry()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddIndustry(Industry ObjIndustry)
        {
            if(ModelState.IsValid)
            {
                int result;
                result = _adminBal.AddIndustry(ObjIndustry);
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
        public ActionResult UpdateIndustry(int id)
        {
            _industry = _adminBal.GetIndustryDetailsById(id);

            return View(_industry);
        }

        [Authorize]
        [HttpPost]
        public ActionResult UpdateIndustry(Industry ObjIndustry)
        {
            if (ModelState.IsValid)
            {
                ObjIndustry = _adminBal.EditIndustry(ObjIndustry);
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
        public JsonResult IndustryDisable(int id)
        {
            _adminBal.IndustryInactive(id);
            TempData["Message"] = "1";
            return Json("Disable Successfull!");
        }
    }
}