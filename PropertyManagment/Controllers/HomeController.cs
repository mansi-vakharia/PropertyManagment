using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PropertyManagment.Controllers
{
    public class HomeController : Controller
    {
        PropertyManagmentEntities db = new PropertyManagmentEntities();
        public ActionResult Index(string type)
        {
            if (Session["Id"] != null && Convert.ToInt32(Session["Id"]) > 0)
            {
                Session["TypeManagment"] = type;
                if (!string.IsNullOrEmpty(type))
                {
                    if(type == "agent" || type == "client")
                    {
                        return RedirectToAction("User", "Home");
                    }
                    else if(type == "property")
                    {
                        return RedirectToAction("Property", "Home");
                    }
                    else
                    {
                        return RedirectToAction("Login", "Account");
                    }
                    //return RedirectToAction("Login", "Home");
                }
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        #region User Section

        public ActionResult UserAdd(int? id)
        {
            if (Session["Id"] != null && Convert.ToInt32(Session["Id"]) > 0)
            {
                if (id != null && id.Value > 0)
                {
                    var data = db.Users.FirstOrDefault(f => f.Id == id.Value);
                    if (data != null)
                    {
                        return View(data);
                    }
                }
                return View(new User());
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        public ActionResult UserAdd(User model, HttpPostedFileBase file)
        {
            if (Session["Id"] != null && Convert.ToInt32(Session["Id"]) > 0)
            {
                var isExists = db.Users.Any(w => w.Email.ToLower() == model.Email.ToLower() && w.Id != (model.Id > 0 ? model.Id : -1));
                if (isExists)
                {
                    ViewBag.Msg = "" + model.Email + " account already exists.";
                    return View(model);
                }
                if (file != null)
                {
                    var fileName = Path.GetFileName(file.FileName); //getting only file name(ex-ganesh.jpg)  
                    var ext = Path.GetExtension(file.FileName); //getting the extension(ex-.jpg)  

                    string name = Path.GetFileNameWithoutExtension(fileName); //getting file name without extension  
                    string myfile = Guid.NewGuid() + ext; //appending the name with id  
                                                          // store the file inside ~/project folder(Img)  
                    var path = Path.Combine(Server.MapPath("~/UploadFiles"), myfile);
                    model.ImagePath = myfile;
                    file.SaveAs(path);
                }
                if (model.Id > 0)
                {
                    var data = db.Users.FirstOrDefault(w => w.Id == model.Id);
                    if (data != null)
                    {
                        data.FullName = model.FullName;
                        data.DOB = model.DOB;
                        data.MobileNo = model.MobileNo;
                        data.About = model.About;
                        data.Password = model.Password;
                        data.RefId = model.RefId;
                        data.ImagePath = model.ImagePath;
                        db.SaveChanges();
                        return RedirectToAction("User", "Home");
                    }

                }
                else
                {

                    model.RefId = model.RefId > 0 ? model.RefId : Convert.ToInt32(Session["Id"]);
                    model.UserType = Session["TypeManagment"].ToString();
                    db.Users.Add(model);
                    var status = db.SaveChanges() > 0;
                    if (status)
                    {
                        return RedirectToAction("User", "Home");
                    }
                }
                ViewBag.Msg = "" + model.UserType + " added failed, Please try again!!";
                return View(model);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult User()
        {
            if (Session["Id"] != null && Convert.ToInt32(Session["Id"]) > 0)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult UserPartial(string keyword, string type)
        {
            if (Session["Id"] != null && Convert.ToInt32(Session["Id"]) > 0)
            {
                var data = db.Users.Where(x => x.UserType == type
             && (x.FullName.Contains(string.IsNullOrEmpty(keyword) ? x.FullName : keyword)
             || x.Email.Contains(string.IsNullOrEmpty(keyword) ? x.Email : keyword)
             || x.MobileNo.Contains(string.IsNullOrEmpty(keyword) ? x.MobileNo : keyword)
             || x.About.Contains(string.IsNullOrEmpty(keyword) ? x.About : keyword)
             )).ToList();
                return View(data);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult UserRemove(int id)
        {
            if (Session["Id"] != null && Convert.ToInt32(Session["Id"]) > 0)
            {
                var data = db.Users.FirstOrDefault(f => f.Id == id);
                if (data != null)
                {
                    db.Users.Remove(data);
                    db.SaveChanges();
                    // return RedirectToAction("User", "Home");
                }
                return RedirectToAction("User", "Home");
                //else
                //{
                //    return RedirectToAction("User", "Home");
                //}
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        #endregion


        #region Property Section

        public ActionResult PropertyAdd(int? id)
        {
            if (Session["Id"] != null && Convert.ToInt32(Session["Id"]) > 0)
            {
                if (id != null && id.Value > 0)
                {
                    var data = db.Properties.FirstOrDefault(f => f.Id == id.Value);
                    if (data != null)
                    {
                        return View(data);
                    }
                }
                return View(new Property());
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        public ActionResult PropertyAdd(Property model, HttpPostedFileBase file)
        {
            if (Session["Id"] != null && Convert.ToInt32(Session["Id"]) > 0)
            {
                //var isExists = db.Properties.Any(w => w.Email.ToLower() == model.Email.ToLower() && w.Id != (model.Id > 0 ? model.Id : -1));
                //if (isExists)
                //{
                //    ViewBag.Msg = "" + model.Email + " account already exists.";
                //    return View(model);
                //}
                if (file != null)
                {
                    var fileName = Path.GetFileName(file.FileName); //getting only file name(ex-ganesh.jpg)  
                    var ext = Path.GetExtension(file.FileName); //getting the extension(ex-.jpg)  

                    string name = Path.GetFileNameWithoutExtension(fileName); //getting file name without extension  
                    string myfile = Guid.NewGuid() + ext; //appending the name with id  
                                                          // store the file inside ~/project folder(Img)  
                    var path = Path.Combine(Server.MapPath("~/UploadFiles"), myfile);
                    model.ImagePath = myfile;
                    file.SaveAs(path);
                }
                if (model.Id > 0)
                {
                    var data = db.Properties.FirstOrDefault(w => w.Id == model.Id);
                    if (data != null)
                    {
                        data.PropertyNumber = model.PropertyNumber;
                        data.Title = model.Title;
                        data.Address = model.Address;
                        data.Badroom = model.Badroom;
                        data.Bathroom = model.Bathroom;
                        data.Kitchen = model.Kitchen;
                        data.Size = model.Size;
                        data.Type = model.Type;
                        data.Livingroom = model.Livingroom;
                        data.Price = model.Price;
                        data.Status = model.Status;
                        data.ImagePath = model.ImagePath;
                        db.SaveChanges();
                        return RedirectToAction("Property", "Home");
                    }

                }
                else
                {

                    model.UserId = Convert.ToInt32(Session["Id"]);
                    db.Properties.Add(model);
                    var status = db.SaveChanges() > 0;
                    if (status)
                    {
                        return RedirectToAction("Property", "Home");
                    }
                }
                //ViewBag.Msg = "" + model.UserType + " added failed, Please try again!!";
                return View(model);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult Property()
        {
            if (Session["Id"] != null && Convert.ToInt32(Session["Id"]) > 0)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult PropertyPartial(string keyword, string type, string badroom="", string bathroom = "", string kitchen = "", string parking = "", string living = "")
        {
            if (Session["Id"] != null && Convert.ToInt32(Session["Id"]) > 0)
            {
                var data = db.Properties.Where(x =>  (x.PropertyNumber.Contains(string.IsNullOrEmpty(keyword) ? x.PropertyNumber : keyword)
             || x.Title.Contains(string.IsNullOrEmpty(keyword) ? x.Title : keyword)
             || x.Address.Contains(string.IsNullOrEmpty(keyword) ? x.Address : keyword)
             || x.Badroom.Contains(string.IsNullOrEmpty(keyword) ? x.Badroom : keyword)
             || x.Bathroom.Contains(string.IsNullOrEmpty(keyword) ? x.Bathroom : keyword)
             || x.Kitchen.Contains(string.IsNullOrEmpty(keyword) ? x.Kitchen : keyword)
             || x.Parking.Contains(string.IsNullOrEmpty(keyword) ? x.Parking : keyword)
             || x.Size.Contains(string.IsNullOrEmpty(keyword) ? x.Size : keyword)
             || x.Type.Contains(string.IsNullOrEmpty(keyword) ? x.Type : keyword)
             || x.Livingroom.Contains(string.IsNullOrEmpty(keyword) ? x.Livingroom : keyword))
             && x.Badroom == (string.IsNullOrEmpty(badroom) ? x.Badroom : badroom)
             && x.Bathroom == (string.IsNullOrEmpty(bathroom) ? x.Bathroom : bathroom)
             && x.Kitchen == (string.IsNullOrEmpty(kitchen) ? x.Kitchen : kitchen)
             && x.Parking == (string.IsNullOrEmpty(parking) ? x.Parking : parking)
             && x.Livingroom == (string.IsNullOrEmpty(living) ? x.Livingroom : living)
             ).ToList();
                return View(data);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult PropertyRemove(int id)
        {
            if (Session["Id"] != null && Convert.ToInt32(Session["Id"]) > 0)
            {
                var data = db.Properties.FirstOrDefault(f => f.Id == id);
                if (data != null)
                {
                    db.Properties.Remove(data);
                    db.SaveChanges();
                    // return RedirectToAction("User", "Home");
                }
                return RedirectToAction("Property", "Home");
                //else
                //{
                //    return RedirectToAction("User", "Home");
                //}
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        #endregion
    }
}