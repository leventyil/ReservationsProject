using Microsoft.AspNetCore.Mvc;
using ReservationProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;

namespace ReservationProject.Controllers
{
    public class ReservationController : Controller
    {
        private readonly AppDbContext db;

        public ReservationController(AppDbContext db)
        {
            this.db = db;
        }

        public IActionResult List()
        {
            var reservations = db.Reservations.ToList();           
            return View(reservations);
        }

        [HttpGet]
        public IActionResult Make()
        {
            List<SelectListItem> companies = new List<SelectListItem>();    
            foreach(var item in db.Companies)
            {
                companies.Add( new SelectListItem { Text = $"{item.CompanyName}", Value = $"{item.CompanyName}" });
            }
            ViewBag.Companies = companies;

            List<SelectListItem> tableNo = new()
            {
                new SelectListItem { Text = "1", Value = "1" },
                new SelectListItem { Text = "2", Value = "2" },
                new SelectListItem { Text = "3", Value = "3" },
                new SelectListItem { Text = "4", Value = "4" },
                new SelectListItem { Text = "5", Value = "5" },
                new SelectListItem { Text = "6", Value = "6" },
                new SelectListItem { Text = "7", Value = "7" }
            };
            ViewBag.Tables = tableNo;          
            return View();          
        }

        [HttpPost]
        public IActionResult Make(ReservationModel r)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Girilen değerler ile veritabanı uyumlu değil. Rezervasyon kaydedilmedi.";
                return RedirectToAction("List");
            }

            db.Reservations.Add(r);
            db.SaveChanges();                                 
            TempData["SuccessMessage"] = "Rezervasyon Yapıldı.";        
            return RedirectToAction("List");
        }       
    }
}
