using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnJobAdmin.Controllers
{
    public class DashboardController : Controller
    {
        AdminBal.Bal.Admin_Bal _adminBal = new AdminBal.Bal.Admin_Bal();
        AdminEntity.AdminModel.Admin _adminModel = new AdminEntity.AdminModel.Admin();

        // GET: Dashboard
        public ActionResult Index()
        {

            _adminModel = _adminBal.GetAllCount();
            _adminModel.lstCompany = _adminBal.GetCompany();
            _adminModel.lstUsers = _adminBal.GetUser();
            
            return View(_adminModel);
        }
    }
}