using Kutse_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Kutse_App.Controllers
{
    public class HomeController : Controller
    {
        private static string[] Greetings = new string[]
        {
            "Tere hommikust!",
            "Tere päevast!",
            "Tere õhtus!",
        };

        private static readonly Dictionary<int, string> Pidu = new Dictionary<int, string>
        {
            {1, "Head uut aastat!"},
            {2, "Head Eesti iseseisvuspäeva!"},
            {12, "Haid jõule"}
        };

        public ActionResult Index()
        {
            
            int month = DateTime.Now.Month;
            int hour = DateTime.Now.Hour;

            string greeting = Greetings[hour % 3];
            string holidayMessage = Pidu.ContainsKey(month) ? Pidu[month] : "";

            ViewBag.Greeting = greeting + (string.IsNullOrEmpty(holidayMessage) ? "" : " " + holidayMessage);
            ViewBag.Message = "Ootan sind minu peole! Palun tule!!!";

            return View();
        }

        [HttpGet]

        public ViewResult Ankeet()
        {
            return View();
        }

        [HttpPost]

        public ViewResult Ankeet(Guest guest)
        {
            E_mail(guest);
            if (ModelState.IsValid) { return View("Thanks", guest); }
            else { return View(); }
        }
        public void E_mail(Guest guest)
        {
            try
            {
                WebMail.SmtpServer = "smtp.gmail.com";
                WebMail.SmtpPort = 587;
                WebMail.EnableSsl = true;
                WebMail.UserName = "jelizaveta.ostapjuk.work@gmail.com";
                WebMail.Password = "lsrs danp cdwm ogmd ";
                WebMail.From = "jelizaveta.ostapjuk.work@gmail.com";
                WebMail.Send(guest.Email, " Vastus kutsele ", guest.Name + " vastas " + ((guest.WillAttend ?? false ? " tuleb peole" : " ei tule saatnud")));
                ViewBag.Message = "Kiri on saatnud!";
            }
            catch (Exception)
            {
                ViewBag.Message = "Mul on kahju! Ei saa kirja saada!!!";
            }
        }
    }
}