using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LGAClient.Models;
using LGAClient.Repository;
using LGAClient.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LGAClient.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public Person Person { get; set; }

        public AccountController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            Person = new Person();
            if (id == null)
            {
                //create
                return View(Person);
            }
            //update
            Person = _db.Person.FirstOrDefault(u => u.Id == id);
            if (Person == null)
            {
                return NotFound();
            }
            return View(Person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert()
        {
            if (ModelState.IsValid)
            {
                using (Service<Person> service = new Service<Person>(_db))
                {
                    if (Person.Id == 0)
                    {
                        service.Insert(Person);
                    }
                    else
                    {
                        service.Update(Person);
                    }
                    return RedirectToAction("Index");
                }
                
            }
            return View(Person);
        }

        #region API Calls
        [HttpGet]
        public async Task<IActionResult> GetAllPeople()
        {
            try
            {
                using (Service<Person> service = new Service<Person>(_db))
                {
                    return Json(new { data = await service.ListAsync() }); ;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            Service<Person> service = new Service<Person>(_db);
            var entityDeleted = await service.DeleteEntityAsync(id);
            if (!entityDeleted)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            return Json(new { success = true, message = "Delete successful" });
        }
        #endregion
    }
}
