using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnJobAdmin.Controllers
{
    public class JobPostController : Controller
    {
        AdminBal.Bal.Admin_Bal _adminBal = new AdminBal.Bal.Admin_Bal();
        AdminEntity.AdminModel.Admin _adminModel = new AdminEntity.AdminModel.Admin();
        AdminEntity.AdminModel.JobPost _jobpostModel = new AdminEntity.AdminModel.JobPost();
        
        // GET: JobPost
        [Authorize]
        public ActionResult Index()
        {
            _adminModel.lstjobpost = _adminBal.GetPostjobData();

            return View(_adminModel);
        }

        [Authorize]
        public ActionResult ViewPostedJob(int id)
        {
            _jobpostModel = _adminBal.GetPostedJobDetailsById(id);

            return View(_jobpostModel);
        }

        [Authorize]
        public JsonResult JobpostDisable(int id)
        {
            _adminBal.JobpostInactive(id);

            return Json("Disable Successfull!");
        }
    }
}