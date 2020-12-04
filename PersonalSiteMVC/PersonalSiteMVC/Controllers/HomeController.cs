using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonalSiteMVC.Models;
using System.Net;
using System.Net.Mail;

namespace PersonalSiteMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Resume()
        {           

            return View();
        }

        public ActionResult Portfolio()
        {           

            return View();
        }

        public ActionResult Classmates()
        {           

            return View();
        }
                //GET
        public ActionResult Contact()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(ContactViewModel cvm)
        {
            //WHen a class has validation attributes, that validation should be checked before 
            //attempting to process the data
            if (!ModelState.IsValid)
            {
                //Send them back to the form and pass the object (cvm) to the view.  
                //This will restore the info they typed in the textbox so they dont have to
                //type it again.
                return View(cvm);
            }

            //Steps to send an email:

            //1) Create a string for the message
            string emailBody = $"You have recieved an email from {cvm.Name} with a subject of {cvm.Subject}.  Please respond to {cvm.Email} with " +
                $"your email to the following message: <br/><br/> {cvm.Message}";

            //2) Create the Mail Message Obj  - we added the System.Net.Mail
            MailMessage msg = new MailMessage
            (
                //From
                "no-reply@davidsee.net",
                //To(where the actual message is sent)
                "engr317@gmail.com",
                //Subject
                "Email from davidsee.net",
                //Body
                emailBody
            );

            //3 (optional) Customize the MailMessage Obj
            msg.IsBodyHtml = true; //Allows HTML formatting in the email
            //msg.cc.Add("another@email.com");
            //msg.ReplyToList.Add(cvm.Email); //Response to the senders email instead of our SmarterASP.Net email.
            //msg.Priority = MailPriority.High;

            //4) Create the SmtpClient -  This is the information from the HOST (smarterasp.net)
            //This allows the email to be sent.
            SmtpClient client = new SmtpClient("mail.davidsee.net");

            //client cred (smarterASP requires for username and password)
            client.Credentials = new NetworkCredential("no-reply@davidsee.net", "123456Ks!");
            client.Port = 8889;

            //5) Attempt to send the email
            //IT is always possible the mailserver will be down or ahve a configuration issue.
            //So we want to wrap our code with a try/catch
            try
            {
                //attempt to send the email
                client.Send(msg);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Sorry, Something went wrong.  Error message: {ex.Message}<br/>{ex.StackTrace}";
                return View(cvm);
            }

            return View("EmailConfirmation", cvm);
        }
    }
}


