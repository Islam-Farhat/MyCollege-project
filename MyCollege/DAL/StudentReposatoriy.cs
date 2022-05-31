using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using DataModels;

namespace DAL
{
    interface IStudentReposatoriy
    {
        bool AddStudent(StudentViewModel dept,string path);
        bool Login(StudentViewModel dept);
    }

    public class StudentReposatoriy : IStudentReposatoriy
    {
        MyCollegeEntities context = new MyCollegeEntities();

        //Add new student in table using viewmodel in register page
        public bool AddStudent(StudentViewModel dept,string path)
        {
            try
            {
                //var check1 = context.Students.Select(x => x.nationalId).Contains(dept.nationalId);
                //if (check1)
                //{
                //    return false;
                //}
                //var check2 = context.Students.Select(x => x.mobile).Contains(dept.mobile);
                //if (check2)
                //{
                //    return false;
                //}
                Student obj = new Student();
                obj.firstName = dept.firstName;
                obj.middleName = dept.middleName;
                obj.lastName = dept.lastName;
                obj.surName = dept.surName;
                obj.nationalId = dept.nationalId;
                obj.mobile = dept.mobile;
                //string img = "F:\Projects\MyCollege\UI\Files\" 
                //string m= Path.GetFileName(dept.image);
                //string path = img + m;
                //obj.image = path;
                // string path = Path.Combine(Server.MapPath("~/Files"), Path.GetFileName(dept.image));
                obj.image = path;
                obj.levelId_Fk = dept.levelId_Fk;
                obj.deptId_FK = dept.deptId_FK;
                obj.genderId_FK = dept.genderId_FK;
                string myString = dept.nationalId.ToString();
                obj.password = myString;
                obj.isActive = true;
                context.Students.Add(obj);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Page student login
        public bool Login(StudentViewModel log)
        {
            try
            {
                var obj = context.Students.Where(x => x.nationalId == log.nationalId && x.password == log.password).FirstOrDefault();

                if (obj.nationalId == log.nationalId && obj.password == log.password)
                {


                    return true;

                }
                return false;
            }
            catch
            {

                return false;
            }

        }
    }
}
