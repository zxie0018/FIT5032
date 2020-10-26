using FIT5032_Task03.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace FIT5032_Task03.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult UploadFile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            if(file != null)
            {
                var fileName = file.FileName;
                var filePath = Server.MapPath(string.Format("~/{0}", "File"));


                file.SaveAs(Path.Combine(filePath, fileName));

                ViewBag.Message = "File uploaded successfully.";
            }


            return View();
        }

        public ActionResult SendingEmail()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendingEmail(EmailModel email)
        {
            SmtpClient smtpClient = new SmtpClient
            {
                Host = "smtp.gmail.com",
                EnableSsl = true
            };
            NetworkCredential networkCredential = new NetworkCredential("zxie0018@student.monashe.edu", "YourPassword");
            smtpClient.UseDefaultCredentials = true;
            smtpClient.Credentials = networkCredential;
            smtpClient.Port = 587;

            MailMessage mm = new MailMessage(
                email.FromEmail,
                email.ToEmail,
                email.Subject,
                email.Body);

            if(email.Attachment != null)
            {
                mm.Attachments.Add(email.Attachment);
            }

            mm.IsBodyHtml = false;

            try
            {
                smtpClient.SendMailAsync(mm);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateMessageWithAttachment(): {0}",
                ex.ToString());
            }

            ViewBag.Message = "Email sending successfully.";

            return View();
        }

        public ActionResult RichText()
        {
            return View();
        }

    }
}