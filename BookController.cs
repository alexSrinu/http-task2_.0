using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using task_2._0.Models;

namespace task_2._0.Controllers
{
    public class BookController : Controller
    {
        Repository R1 = new Repository();
        // GET: Book
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Register r)
        {
            if (ModelState.IsValid)
            {

                if (R1.CheckUserExists(r.Name, r.Phone, r.Email))
                {
                    ModelState.AddModelError("", "User with same username, mobile number, or email already exists.");
                    return View(r);
                }
               


                R1.Register(r);
                return RedirectToAction("RegisterSuccess");
            }

            return View(r);

        }
        [HttpGet]
        public ActionResult LoginStudent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginStudent(Login l)
        {
            if(ModelState.IsValid)
            {
               if(R1.LoginStudent(l.Email , l.Password))
                {
                    
                    return RedirectToAction("Details",new { l.Email, l.Password });
                }
                else
                {
                    TempData["value"] = "Invalid user";
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult LoginAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginAdmin(Login l)
        {
            if (ModelState.IsValid)
            {
                if (R1.LoginAdmin(l.Email, l.Password))
                {
                    return RedirectToAction("GetDetails");
                }
                else
                {
                    TempData["value"] = "Invalid user";
                }
            }
            return View();
        }
        private Profile GetProfileModel()
        {

            // Replace with your logic to get the profile data
            return new Profile
            {
                Name = "John Doe",
                Email = "john.doe@example.com",
                Phone = "123-456-7890"
            };
        }
        public ActionResult RegisterSuccess()
        {
            return View();
        }
        public ActionResult Logout()
        {
            return View();
        }
        public ActionResult GetDetails()
        {
            ModelState.Clear();
            return View(R1.GetDetails());


        }
        public ActionResult SEdit(string Email,string Password)
        {
            return View(R1.Details(Email,Password).Find(emp => emp.Email==Email));
        }
        [HttpPost]
        public ActionResult SEdit( Register e1)
        {
            R1.SEdit(e1);
            return RedirectToAction("Details",new { e1.Email, e1.Password });
            //return View();
        }
        public ActionResult Details(string Email,string Password)
        {
            //ModelState.Clear();
            //return View(R1.Details(Email,Password));
            ModelState.Clear();
            var person = R1.Details(Email, Password);
            TempData["value"] = Email;

            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);

        }

        public ActionResult Edit(int id)
        {
            TempData["value"] = id;

            return View(R1.GetDetails().Find(emp => emp.Id == id));
        }
        [HttpPost]
        public ActionResult Edit(int id, Register e1)
        {
            R1.Edit(e1);
            return RedirectToAction("GetDetails");
            //return View();
        }
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                R1.Delete(id);
                return RedirectToAction("GetDetails");
            }
            return View();
        }


    }
}
           
        
    
