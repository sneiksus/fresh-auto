using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Back.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Back.Controllers
{
    
    public class UserController : Controller
    {
        [HttpGet]
        public IEnumerable<Car> GetCarsIndex()
        {
            using (EFContext con = new EFContext())
            {
                var res = con.Cars.ToList().Take(6);
                return res;
            }
        }

        [HttpPost]
        public IActionResult sendMessage(string name, string phone, string email, string mes)
        {
            MailAddress from = new MailAddress("contacte@freshauto.com.ua", "fresh auto");
            MailAddress to = new MailAddress("sanekgalchyn@ukr.net");
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Повідомлення з сайту";
            m.Body = $"Новий запит з контактної форми\nІм'я: {name}\nТелефон: {phone}\nEmail: {email}\n\n{mes}";
            SmtpClient smtp = new SmtpClient("sc", 25);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("contacte@freshauto.com.ua", "11111");
            smtp.EnableSsl = false;
            smtp.Send(m);
            return Ok();
        }
        [HttpPost]
        public IActionResult sendOrder(Order order)
        {

            using (EFContext con = new EFContext())
            {
                order.Status = "Нове";
                con.Orders.Add(order);
                con.SaveChanges();
                return Ok();
            }
        }

        [HttpGet]
        public IEnumerable<Car> GetCarsCatalog()
        {
            using (EFContext con = new EFContext())
            {
                var res = con.Cars.ToList();
                return res;
            }
        }
    }
}