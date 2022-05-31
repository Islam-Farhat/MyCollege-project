using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using BLL;
using DAL;
using DataModels;
using System.Net;
using System.Text;
using System.Web.Security;

namespace UI.Controllers
{
    public class FacultyController : Controller
    {
        //Create object from Database
        MyCollegeEntities db = new MyCollegeEntities();
        //Create object from rebosatoriy
        StudentReposatoriy student = new StudentReposatoriy();
        LevelReposatoriy level = new LevelReposatoriy();
        DepartmentReposatoriy depart = new DepartmentReposatoriy();
        SubjectReposatoriy subject = new SubjectReposatoriy();

        //Action of Page login
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult LoginStudent(StudentViewModel dept)
        {
            var id = db.Students.Where(x => x.nationalId == dept.nationalId).Select(x => x.id).FirstOrDefault();
            bool flag = student.Login(dept);
            if (flag)
            {
                return Json(id, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("error", JsonRequestBehavior.AllowGet);
            }

        }

        //Actions of page Register
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult DropdownlistLevel()
        {
            IEnumerable<LevelViewModel> levels = level.DropdownlistLevel();
            return Json(levels, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DropdownlistDepartment()
        {
            IEnumerable<DepartmentViewModel> dept =depart.DropdownlistDepartment ();
            return Json(dept, JsonRequestBehavior.AllowGet);
        }
        public JsonResult uploadFile()
        {
            // check if the user selected a file to upload
            if (Request.Files.Count > 0)
            {
                try
                {
                    HttpFileCollectionBase files = Request.Files;

                    HttpPostedFileBase file = files[0];
                    string fileName = file.FileName;

                    // create the uploads folder if it doesn't exist
                    Directory.CreateDirectory(Server.MapPath("~/Files/"));
                    string path = Path.Combine(Server.MapPath("~/Files/"), fileName);
                    //string path = Path.Combine(Server.MapPath("~/Files/"), Path.GetFileName(file.FileName));

                    // save the file
                    file.SaveAs(path);
                    return Json("File uploaded successfully");
                }

                catch (Exception e)
                {
                    return Json("error" + e.Message);
                }
            }

            return Json("no files were selected !");
        }
        public ActionResult ValidNationalID(long national)
        {
            // var check = db.FatherDatas.Where(x => x.Father_Identity == fatheridentity).FirstOrDefault();
            var check = db.Students.Select(x => x.nationalId).Contains(national);
            if (check)
            {
                return Json("false", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Success", JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult ValidMobile(string mobile)
        {
            var check = db.Students.Select(x => x.mobile).Contains(mobile);
            if (check)
            {
                return Json("false", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Success", JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult AddNewStudent(StudentViewModel stud)
        {
            string path = Path.Combine(Server.MapPath("~/Files"), Path.GetFileName(stud.image));
            bool flag = student.AddStudent(stud,path);
            if (flag)
            {
                return Json("Success", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("error", JsonRequestBehavior.AllowGet);
            }

        }

        //Activation your email
        public JsonResult EmailUser()
        {
            bool result = false;
            result = SendEmail("islamfarhat100@gmail.com", "Hello islam this is a activation massege!!", "<p>Hi Islam,<br />this Text to Test yhe activation of email<br />Good Bay</p>");
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public bool SendEmail(string toemail, string subje, string emailbody)
        {
            try
            {
                string senderemail = System.Configuration.ConfigurationManager.AppSettings["senderemail"].ToString();
                string senderpassword = System.Configuration.ConfigurationManager.AppSettings["senderpassword"].ToString();
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Timeout = 100000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(senderemail, senderpassword);
                MailMessage mailMessage = new MailMessage(senderemail, toemail, subje, emailbody);
                mailMessage.IsBodyHtml = true;
                mailMessage.BodyEncoding = UTF8Encoding.UTF8;
                client.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        //Register subject
        public ActionResult RegisterSubject(int id)
        {
            ViewBag.id = id;
            return View();
        }
        public ActionResult LoadDataSubject(int id)
        {
            IEnumerable<SubjectViewModel> sub = subject.LoadData(id);
            return Json(sub, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddRegister(StudentSubjectViewModel Studentsubj)
        {
            bool flag = subject.AddRegister(Studentsubj);
            if (flag)
            {
                return Json("Success", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult CheckSubject(int subjectid, int studentid)
        {
            bool flag = subject.CheckSubject(subjectid, studentid);
            if (flag == false)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult CloseRegister()
        {
            bool flag = subject.CheckRegister();
            if (flag)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
        
        //My subject and delete it
        public ActionResult MySubject(int id)
        {
            ViewBag.id = id;
            return View();
        }
        public ActionResult LoadDataOldSubject(int id)
        {
            IEnumerable<SubjectViewModel> sub = subject.LoadDataOldSubject(id);
            return Json(sub, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeleteSubject(int subjectid,int studentid)
        {
            bool flag = subject.Delete(subjectid, studentid);
            if (flag)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult Action()
        {
            return View();
        }
        public ActionResult LogOut()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
           return Redirect("http://localhost:54395/Faculty/Login/");
        }
    }
}