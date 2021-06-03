using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnJobAdmin.Controllers
{
    public class UserController : Controller
    {
        AdminBal.Bal.Admin_Bal _adminBal = new AdminBal.Bal.Admin_Bal();
        AdminEntity.AdminModel.Admin _adminModel = new AdminEntity.AdminModel.Admin();
        AdminEntity.AdminModel.Users _user = new AdminEntity.AdminModel.Users();

        // GET: User
        [Authorize]
        public ActionResult Index()
        {
            _adminModel.lstUsers = _adminBal.GetUser();
            
            return View(_adminModel);
        }

        [Authorize]
        public JsonResult UserDisable(int id)
        {
            _adminBal.UserInactive(id);
            TempData["Message"] = "1";
            return Json("Disable Successfull!");
        }
    }
}