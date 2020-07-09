using System;
using System.Collections.Generic;
using System.Linq;
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