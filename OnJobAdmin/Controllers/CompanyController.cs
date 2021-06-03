using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnJobAdmin.Controllers
{
    public class CompanyController : Controller
    {
        AdminBal.Bal.Admin_Bal _adminBal = new AdminBal.Bal.Admin_Bal();
        AdminEntity.AdminModel.Admin _adminModel = new AdminEntity.AdminModel.Admin();
        AdminEntity.AdminModel.Company _user = new AdminEntity.AdminModel.Company();
        // GET: Company
        [Authorize]
        public ActionResult Index()
        {
            _adminModel.lstCompany = _adminBal.GetCompany();
            return View(_adminModel);
        }

        [Authorize]
        public JsonResult CompanyDisable(int id)
        {
            _adminBal.CompanyInctive(id);
            TempData["Message"] = "1";

            return Json("Disable Successfull!");
        }
    }
}