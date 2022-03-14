using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeDbContext db;
        public EmployeeController(EmployeeDbContext context)
        {
            db = context;
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult GetData()
        {
            var abc = db.Employees.ToList();
            return View(abc);
        }
        [HttpPost]
        public IActionResult Create(Employee model)
        {
            db.Employees.Add(model);
            db.SaveChanges();
            return RedirectToAction("GetData");
        }
        public IActionResult Delete(int id)
        {
            var dlt = db.Employees.Where(m => m.id == id).FirstOrDefault();
            db.Employees.Remove(dlt);
            db.SaveChanges();
            return RedirectToAction("GetData");
        }
        public IActionResult Edit(int id)
        {
            var ab = db.Employees.Where(m => m.id == id).FirstOrDefault();
            return View(ab);
        }
        public IActionResult Details(int id)
        {
            var ab = db.Employees.Where(m => m.id == id).FirstOrDefault();
            return View(ab);
        }

    }
}
