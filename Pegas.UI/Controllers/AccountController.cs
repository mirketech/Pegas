using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Pegas.Data;
using Pegas.UI.Models;

namespace Pegas.UI.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Settings()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authenticate(LoginModel model, string returnUrl)
        {
            string Return;
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Login", "Account");
            }
            if (returnUrl == "?ReturnUrl=%2f" || returnUrl == null)
            {
                Return = string.Empty;
            }
            else
            {
                Return = returnUrl.Replace("%2f", "/").Replace("?ReturnUrl=", "");
            }

            bool url = string.IsNullOrWhiteSpace(Return);
            bool CheckUser = DoesUserExist(model.UserName, model.Password);

            if (CheckUser == true)
            {
                Session["UserName"] = model.UserName;

                //var authTicket = new FormsAuthenticationTicket(1, model.UserName, DateTime.Now, DateTime.Now.AddMinutes(20), model.RememberMe, "", "/");
                //HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(authTicket));
                //Response.Cookies.Add(cookie);

                if (!url && (Return != "/Account/Login" || Return != "/Account/Authenticate" || Return != "/Account/ChangePassword"))
                {
                    return Redirect(Return);
                }
                else
                {
                    return RedirectToAction("Index", "Dashboard");
                }
            }

            string msg = "Username or password you provided is incorrect.";
            TempData["ErrorMessage"] = msg;
            return RedirectToAction("Login");
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePSModel record)
        {
            User entity;
            string msg;
            using (PegasEntities context = new PegasEntities())
            {
                if (record != null)
                {
                    if (record.NewPassword == record.NewPasswordAgain)
                    {
                        entity = context.Users.First(p => p.Username == record.UserName);
                        if (entity.Password == record.OldPassword)
                        {
                            entity.Password = record.NewPassword;
                            context.SaveChanges();
                        }
                        else
                        {
                            msg = "Your password cannot be changed, contact to your administrator.";
                            TempData["ErrorMessage"] = msg;
                            return RedirectToAction("Account");
                        }
                    }
                    else
                    {
                        msg = "New passwords are not same, check new password.";
                        TempData["ErrorMessage"] = msg;
                        return RedirectToAction("Account");
                    }
                }
            }
            msg = "Your password changed successfully.";
            TempData["ErrorMessage"] = msg;
            return RedirectToAction("Account");
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login", "Account");
        }

        public ActionResult RenewPassword(RenewPSModel record)
        {

            PegasEntities DBContext = new PegasEntities();

            var user = DBContext.Users.First(u => u.Username == record.UserName);
            string password = user.Password;
            string recipient = user.Password;

            SendEmail(recipient, password, record.UserName);

            TempData["Notification"] = "Your password sent to your email.";

            return RedirectToAction("Login");
        }

        public void SendEmail(string recipient, string password, string username)
        {
            // Replace sender@example.com with your "From" address. 
            // This address must be verified with Amazon SES.
            String FROM = "itsupport@pegasthailand.com";
            String FROMNAME = "Pegas TH IT Support";

            // Replace recipient@example.com with a "To" address. If your account 
            // is still in the sandbox, this address must be verified.
            String TO = recipient;

            // Replace smtp_username with your Amazon SES SMTP user name.
            String SMTP_USERNAME = @"AYT\itsupport";

            // Replace smtp_password with your Amazon SES SMTP user name.
            String SMTP_PASSWORD = "iT1$98!";

            // (Optional) the name of a configuration set to use for this message.
            // If you comment out this line, you also need to remove or comment out
            // the "X-SES-CONFIGURATION-SET" header below.
            String CONFIGSET = "ConfigSet";

            // If you're using Amazon SES in a region other than US West (Oregon), 
            // replace email-smtp.us-west-2.amazonaws.com with the Amazon SES SMTP  
            // endpoint in the appropriate AWS Region.
            String HOST = "mail.pegast.com";

            // The port you will connect to on the Amazon SES SMTP endpoint. We
            // are choosing port 587 because we will use STARTTLS to encrypt
            // the connection.
            int PORT = 587;

            // The subject line of the email
            String SUBJECT =
                "Your new password.";

            // The body of the email
            String BODY =
                "<h1>Dear </h1>" + username + "," +
                "<p>Your new password is " +
                "<b>" + password + "</b>" +
                ", don't forget to change your password once you login." +
                "Best regards," +
                "Pegas TH IT Team";

            // Create and build a new MailMessage object
            MailMessage message = new MailMessage();
            message.IsBodyHtml = true;
            message.From = new MailAddress(FROM, FROMNAME);
            message.To.Add(new MailAddress(TO));
            message.Subject = SUBJECT;
            message.Body = BODY;
            // Comment or delete the next line if you are not using a configuration set
            message.Headers.Add("X-SES-CONFIGURATION-SET", CONFIGSET);

            using (var client = new SmtpClient(HOST, PORT))
            {
                // Pass SMTP credentials
                client.Credentials =
                    new NetworkCredential(SMTP_USERNAME, SMTP_PASSWORD);

                // Enable SSL encryption
                client.EnableSsl = true;

                // Try to send the message. Show status in console.
                try
                {
                    Console.WriteLine("Attempting to send email...");
                    client.Send(message);
                    Console.WriteLine("Email sent!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("The email was not sent.");
                    Console.WriteLine("Error message: " + ex.Message);
                }
            }
        }

        public bool DoesUserExist(string userName, string password)
        {

            PegasEntities DB = new PegasEntities();

            bool userValidated = true;

            var user = DB.Users.FirstOrDefault(u => u.Username == userName);

            if (user != null)
            {
                if (user.Password == password)
                {
                    userValidated = true;
                    return userValidated;
                }
                else
                {
                    userValidated = false;
                }
            }
            return false;

            //bool userValidated = true;
            //var domainContext = new PrincipalContext(ContextType.Domain, "BKK.PGS.DOM");
            //var foundUser = UserPrincipal.FindByIdentity(domainContext, IdentityType.SamAccountName, userName);
            //if (foundUser != null)
            //{
            //    if (domainContext.ValidateCredentials(userName, password))
            //    {
            //        userValidated = true;
            //        return userValidated;
            //    }
            //    else
            //    {
            //        userValidated = false;
            //    }
            //}
            //return false;

        }
    }
}
