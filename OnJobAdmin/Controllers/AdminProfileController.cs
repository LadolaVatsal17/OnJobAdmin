using AdminEntity.AdminModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnJobAdmin.Controllers
{
    public class AdminProfileController : Controller
    {
        AdminBal.Bal.Admin_Bal _adminBal = new AdminBal.Bal.Admin_Bal();
        AdminEntity.AdminModel.Admin _adminModel = new AdminEntity.AdminModel.Admin();
        // GET: AdminProfile
        public ActionResult Index()
        {
            int Admin_id = Convert.ToInt32(Session["Admin_id"]);
            _adminModel = _adminBal.GetAdmminDataById(Admin_id);
            
            return View(_adminModel);
        }

        [Authorize]
        public ActionResult UpdateProfile(Admin ObjAdmin)
        {
            if (ModelState.IsValid)
            {
                _adminModel = _adminBal.Update_AdminInfo(ObjAdmin);
                TempData["Message"] = "1";

                return View("index");
            }
            else
            {
                TempData["Message"] = "Update Faild!!.";
                return View("index");
            }
        }

        [Authorize]
        public ActionResult ChangePassword()
        {
            int Admin_id = Convert.ToInt32(Session["Admin_id"]);
            _adminModel = _adminBal.GetAdmminDataById(Admin_id);

            return View(_adminModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(Admin ObjAdmin)
        {
            int Admin_id = Convert.ToInt32(Session["Admin_id"]);
            _adminModel = _adminBal.GetAdmminDataById(Admin_id);
            
            if (ObjAdmin.Password == _adminModel.Password)
            {
                /*if(_adminModel.NewPassword != null & _adminModel.ConformPassword != null)
                {*/
                    string newPassword = ObjAdmin.ConformPassword;
                    _adminBal.ChangePassword(newPassword, Admin_id);
                    TempData["Message"] = "1";

                    return RedirectToAction("Index");
                /*}*/
                /*else
                {
                    TempData["Message"] = "Update Faild!!";
                    
                    return View();
                }*/
                
            }
            return View();
        }
    }
}