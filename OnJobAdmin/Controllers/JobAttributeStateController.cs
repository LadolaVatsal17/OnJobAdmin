using AdminEntity.AdminModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnJobAdmin.Controllers
{
    public class JobAttributeStateController : Controller
    {
        AdminBal.Bal.Admin_Bal _adminBal = new AdminBal.Bal.Admin_Bal();
        AdminEntity.AdminModel.Admin _adminModel = new AdminEntity.AdminModel.Admin();
        AdminEntity.AdminModel.State _state = new AdminEntity.AdminModel.State();
        // GET: JobAttributeState
        [Authorize]
        public ActionResult Index()
        {
            _adminModel.lstState = _adminBal.GetState();
            
            return View(_adminModel);
        }

        [Authorize]
        public ActionResult AddState()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddState(State ObjState)
        {
            if (ModelState.IsValid)
            {
                int result;
                result = _adminBal.AddState(ObjState);
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
        public ActionResult UpdateState(int id)
        {
           _state = _adminBal.GetStateDetailsById(id);

           return View(_state);    
        }

        [Authorize]
        [HttpPost]
        public ActionResult UpdateState(State ObjState)
        {
            if(ModelState.IsValid)
            {
                ObjState = _adminBal.EditState(ObjState);
                TempData["Message"] = "2";

                return RedirectToAction("index");
            }
            else
            {
                TempData["Message"] = "3";
                return RedirectToAction("index");
            }
        }
    }
}