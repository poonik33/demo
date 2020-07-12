using Demo.DBModel;
using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Controllers
{
    public class AccountController : Controller
    {
        UserDbEntities objUserDbEntities = new UserDbEntities();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            UserModel objUserModel = new UserModel();
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserModel objUserModel)
        {
            if(ModelState.IsValid)
            {
                if (!objUserDbEntities.Users.Any(m => m.Email == objUserModel.Email))
                {
                    User objUser = new DBModel.User();
                    objUser.CreatedOn = DateTime.Now;
                    objUser.FirstName = objUserModel.FirstName;
                    objUser.LastName = objUserModel.LasttName;
                    objUser.Email = objUserModel.Email;
                    objUser.Password = objUserModel.Password;

                    objUserDbEntities.Users.Add(objUser);
                    objUserModel = new UserModel();
                    objUserDbEntities.SaveChanges();
                    objUserModel.Message = "User is successfully Added";
                    return RedirectToAction("Index", "Home");
                }
                else 
                {
                    ModelState.AddModelError("Error", "Email Already exits");
                    return View();
                
                }
            }
            
            return View();
        }
        public ActionResult Login()
        {
            LoginModel ObjloginModel = new LoginModel();

            return View(ObjloginModel);
        }


        [HttpPost]
        public ActionResult Login(LoginModel objLoginModel)
        {
            if (ModelState.IsValid)
            {
                
                if (objUserDbEntities.Users.Where(m =>m.Email == objLoginModel.Email && m.Password == objLoginModel.Password ).FirstOrDefault() ==null) 
                {
                    ModelState.AddModelError("Error", "Invalid Email and password ");
                    return View();
                }
                 else
                {
                    Session["Email"] = objLoginModel.Email;
                    RedirectToAction("Index", "Home");
                }
            }

            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index","Home"); 
        }
    }
}