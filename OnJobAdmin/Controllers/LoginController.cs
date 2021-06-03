using AdminEntity.AdminModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnJobAdmin.Controllers
{
    public class LoginController : Controller
    {
        AdminBal.Bal.Admin_Bal _adminBal = new AdminBal.Bal.Admin_Bal();
        AdminEntity.AdminModel.Admin _adminModel = new AdminEntity.AdminModel.Admin();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(Admin ObjAdmin)
        {
            _adminModel = _adminBal.GetLoginDetails(ObjAdmin);
            
            if (_adminModel.Email != null & _adminModel.Password != null) 
            {
                Session["Email"] = _adminModel.Email;
                Session["Password"] = _adminModel.Password;
                Session["Admin_id"] = _adminModel.Admin_id;

                TempData["Message"] = "2";
                FormsAuthentication.SetAuthCookie(_adminModel.Email, false);
                return RedirectToAction("Index", "DashBoard", _adminModel);//method,controller,object
            }
            else
            {
                TempData["Message"] = "1";
                ModelState.Clear();
                
                return View();
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();
            TempData["Message"] = "Logout Successfully";
            return RedirectToAction("Index", "Login");
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ForgotPassword(Admin ObjAdmin)
        {
            if (ObjAdmin.Email != null)
            {
                _adminModel = _adminBal.GetForgotPassword(ObjAdmin);
                if (_adminModel.Password != null)
                {
                 

                    String ToEmailAddress = _adminModel.Email;
                    String Username = "Admin";
                    String EmailBody = "Hi ," + Username + ",<br/><br/>Your Password Is <br/> <br/>" + _adminModel.Password;
                    MailMessage PassRecMail = new MailMessage("065aayush@gmail.com", ToEmailAddress);

                    PassRecMail.Body = EmailBody;
                    PassRecMail.IsBodyHtml = true;
                    PassRecMail.Subject = "Reset Password";


                    using (SmtpClient client = new SmtpClient())
                    {
                        client.EnableSsl = true;
                        client.UseDefaultCredentials = false;
                        client.Credentials = new NetworkCredential("065aayush@gmail.com", "password123&&&");
                        client.Host = "smtp.gmail.com";
                        client.Port = 587;
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;

                        client.Send(PassRecMail);
                    }
                    TempData["Message"] = "2";
                    return RedirectToAction("index");
                }
                else
                {
                    TempData["Message"] = "3";
                    return RedirectToAction("index");
                }

            }
            else
            {

                TempData["Message"] = "3";
                return View();
            }

        }
    }
}