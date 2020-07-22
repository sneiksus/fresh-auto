using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Back.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Back.Controllers
{
    public class AuthController : Controller
    {

        [HttpPost]
        [Authorize]
        public IActionResult GetLogin()
        {
            return Ok();
        }
        [HttpPost]
        [Authorize]
        public IActionResult AddCar(Car car)
        {
            using(EFContext con = new EFContext())
            {
                con.Cars.Add(car);
                con.SaveChanges();
                return Ok();
            }
        }
        [HttpGet]
        [Authorize]
        public IEnumerable<Car> GetCars()
        {
            using (EFContext con = new EFContext())
            {
                return con.Cars.ToList();
            }
        }
        [HttpGet]
        [Authorize]
        public IEnumerable<Order> GetOrders()
        {
            using (EFContext con = new EFContext())
            {
                return con.Orders.ToList();
            }
        }
        [HttpPost]
        [Authorize]
        public IActionResult ChangeStatus(int num, string status)
        {
            using (EFContext con = new EFContext())
            {
              con.Orders.SingleOrDefault(x => x.Id == num).Status = status;
                
                con.SaveChanges();
                return Ok();
            }
        }
        [HttpPost]
        [Authorize]
        public IActionResult DelOrder(int num)
        {
            using (EFContext con = new EFContext())
            {
                var order = con.Orders.SingleOrDefault(x => x.Id == num);
                con.Orders.Remove(order);
                con.SaveChanges();
                return Ok();
            }
        }
        [HttpPost]
        [Authorize]
        public IActionResult DelCar(int num)
        {
            using (EFContext con = new EFContext())
            {
                var car = con.Cars.SingleOrDefault(x => x.Id == num);
                con.Cars.Remove(car);
                con.SaveChanges();
                return Ok();
            }
        }

    }
}