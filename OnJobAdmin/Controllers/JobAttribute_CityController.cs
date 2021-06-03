using AdminEntity.AdminModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnJobAdmin.Controllers
{
    public class JobAttribute_CityController : Controller
    {
        AdminBal.Bal.Admin_Bal _adminBal = new AdminBal.Bal.Admin_Bal();
        AdminEntity.AdminModel.Admin _adminModel = new AdminEntity.AdminModel.Admin();
        AdminEntity.AdminModel.City _city = new AdminEntity.AdminModel.City();
        AdminEntity.AdminModel.State _state = new AdminEntity.AdminModel.State();
        
        // GET: JobAttribute_City
        [Authorize]
        public ActionResult Index()
        {
            _adminModel.lstCity = _adminBal.GetCity();
            return View(_adminModel);
        }

        [Authorize]
        public ActionResult AddCity()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddCity(City ObjCity)
        {
            if (ModelState.IsValid)
            {
                _adminBal.AddCity(ObjCity);
                TempData["Message"] = "3";
                return RedirectToAction("index");
            }
            else
            {
                TempData["Message"] = "City Add Faild!! or Already Added";
                return RedirectToAction("index");
            }
        }

        [Authorize]
        public ActionResult UpdateCity(int id)
        {
            _city = _adminBal.GetCityDetailsById(id);

            return View(_city);
        }

        [Authorize]
        [HttpPost]
        public ActionResult UpdateCity(City ObjCity)
        {
            if (ModelState.IsValid)
            {
                ObjCity = _adminBal.EditCity(ObjCity);
                TempData["Message"] = "2";

                return RedirectToAction("index");
            }
            else
            {
                TempData["Message"] = "3";
                return RedirectToAction("index");
            }
        }





        [HttpPost]
        public JsonResult AjaxMethodState()
        {
            List<SelectListItem> state = new List<SelectListItem>();
           

            _adminModel.lstState = _adminBal.GetState();

            for (int i = 0; i < _adminModel.lstState.Count; i++)
            {
                state.Add(new SelectListItem
                {
                    Value = _adminModel.lstState[i].State_id.ToString(),
                    Text = _adminModel.lstState[i].State_name
                });
            }

            return Json(state);
        }
    }
}