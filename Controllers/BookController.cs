using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using task_2._0.Models;
using PagedList;
using PagedList.Mvc;

namespace task_2._0.Controllers
{
    public class BookController : Controller
    {
        Repository R1 = new Repository();
        //private object existingMobileNumbers;
        // GET: Book
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
            public ActionResult Register()
            {
           // R1.CheckMobileExists(email);

            return View();
            }
       
        [HttpPost]
        public ActionResult Register(Register r)
        {
            if (ModelState.IsValid)
           {
                //if (R1.CheckUserExists(r.Name, r.Phone, r.Email))
                //{
                //    ModelState.AddModelError("", "User with same username, mobile number, or email already exists.");
                //    return View(r);
                //}
              R1.Register(r);
                return RedirectToAction("RegisterSuccess");
           }

            return View(r);
            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        R1.Register(r);
            //        return RedirectToAction("RegisterSuccess");
            //    }
            //    catch
            //    {
            //        ModelState.AddModelError(ModelState,)
            //    }
            //}

        }


        [HttpGet]
        public JsonResult CheckUser(string Phone)
        {
            //if (R1.CheckMobileExists(Phone))
            //{
              //  return Json(!R1.CheckMobileExists.Any(Register=>Register.Phone==Phone,JsonRequestBehavior.AllowGet);
          //  }

            if (R1.CheckMobileExists(Phone))
            {
               return Json(new { success = false, message = "This mobile no  already exists." },JsonRequestBehavior.AllowGet);
            }

            return Json(new { success = true, message = "" },JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult CheckUser1(string Email)
        {
            //if (R1.CheckMobileExists(Phone))
            //{
            //  return Json(!R1.CheckMobileExists.Any(Register=>Register.Phone==Phone,JsonRequestBehavior.AllowGet);
            //  }

            if (R1.CheckEmailExists(Email))
            {
                return Json(new { success = false, message = "This email already exists." }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { success = true,message=""}, JsonRequestBehavior.AllowGet);
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
        //private Profile GetProfileModel()
        //{

        //    // Replace with your logic to get the profile data
        //    return new Profile
        //    {
        //        Name = "John Doe",
        //        Email = "john.doe@example.com",
        //        Phone = "123-456-7890"
        //    };
        //}
        public ActionResult RegisterSuccess()
        {
            return View();
        }
        public ActionResult Logout()
        {
            return View();
        }
        //public ActionResult GetDetails()
        //{
        //    ModelState.Clear();
        //    return View(R1.GetDetails());


        //}
        public ActionResult GetDetails(string searchString, string CountryId, int? Page)
        {
            int pageSize = 3; // Number of items per page

            int pageNumber = Page ?? 1;

            var model = R1.GetPagedData(pageSize,pageNumber).ToList();
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(r => r.Name.Contains(searchString)).ToList();
            }

          
            if (!string.IsNullOrEmpty(CountryId) && CountryId != "All")
            {
                model = model.Where(s => s.CountryId == CountryId).ToList();
            }

            
            var allCountries = R1.GetDetails().Select(x => x.CountryId).Distinct().ToList();
            ViewBag.CountryIdList = new SelectList(allCountries);
          //  int pageSize = 3; // Number of items per page
           // int pageNumber = Page ?? 1;



            IPagedList<Register> pagedModel = model.ToPagedList(Page??1,3);

            return View(pagedModel); // Pass IPagedList to the view
        }

       

        [HttpGet]
        
        public ActionResult SEdit(string Email,Register r)
        {
            Register register = R1.Details(r).Find(emp => emp.Email == Email); // Assuming R1.Details returns a Register object based on Email
            if (register == null)
            {
                return HttpNotFound(); // Handle case where the register with the given email is not found
            }

            return View(register);
        }
       

        [HttpPost]
        public ActionResult SEdit(Register e1)
        {
            if (ModelState.IsValid)
            {
                R1.SEdit(e1); // Assuming R1.SEdit updates the Register object
                return RedirectToAction("Details", new { Email = e1.Email, Password = e1.Password }); // Redirect to details view
            }

            // If ModelState is not valid, return to the edit view with validation errors
            return View(e1);
        }


        //[HttpGet]
        //public ActionResult SEdit(Register r)
        //{
        //    return View(R1.Details(r).Find(emp => emp.Email==r.Email ));
        //}
        //[HttpPost]
        //public ActionResult SEdit(string Email, Register e1)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        R1.SEdit(e1);
        //        return RedirectToAction("Details", new { e1.Email, e1.Password });
        //    }
        //   return View();
        //}
        public ActionResult Details(Register r)
        {
            //ModelState.Clear();
            //return View(R1.Details(Email,Password));
            ModelState.Clear();
            var person = R1.Details(r);
           TempData["value"] = r.Email;

            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);

        }

        public ActionResult ViewDetails(int id, bool isPartial )
        {
            var item = R1.GetDetails(id);// Your logic to get the item by ID

            if (isPartial)
            {
                return PartialView("_Partial", item);
            }

            return View(item);
        }


        public ActionResult Edit(int Id)
        {
           
            TempData["value"] = Id;

            return View(R1.GetDetails().Find(emp => emp.Id == Id));
        }
        [HttpPost]
        public ActionResult Edit(int id, Register e1)
        {
           
                R1.Edit(e1);
                return RedirectToAction("GetDetails");
                        return View();
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
           
        
    
