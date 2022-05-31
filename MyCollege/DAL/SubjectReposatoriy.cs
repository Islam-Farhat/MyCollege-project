using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using DataModels;

namespace DAL
{
    interface ISubjectReposatoriy
    {
        IEnumerable<SubjectViewModel> LoadData(int id);
        IEnumerable<SubjectViewModel> LoadDataOldSubject(int id);
        bool AddRegister(StudentSubjectViewModel stu);
        bool CheckSubject(int subjectid, int studentid);
        bool Delete(int subjectid, int studentid);
        bool CheckRegister();
    }
    public class SubjectReposatoriy : ISubjectReposatoriy
    {
        MyCollegeEntities context = new MyCollegeEntities();

        //LodaData all subject
        public IEnumerable<SubjectViewModel> LoadData(int id)
        {
            List<SubjectViewModel> depts = new List<SubjectViewModel>();
            var i = context.Students.Where(x => x.id == id).Select(x => x.deptId_FK).FirstOrDefault();
            foreach (var item in context.Subjects.Where(x => x.deptId_FK == i))
            {
                SubjectViewModel obj = new SubjectViewModel();
                obj.id = item.id;
                obj.subject1 = item.subject1;
                obj.creditHours = item.creditHours;
                obj.code = item.code;
                obj.preSubjectId_FK = item.preSubjectId_FK;
                obj.day = item.day;
                obj.fromTime = item.fromTime.ToString();
                obj.toTime = item.toTime.ToString();
                depts.Add(obj);
            }
            return depts;
        }

        //lodaData old subject
        public IEnumerable<SubjectViewModel> LoadDataOldSubject(int id)
        {
            List<SubjectViewModel> depts = new List<SubjectViewModel>();
            //var i = context.Student_Subjects.Where(x => x.id == id).Select(x => x.deptId_FK).FirstOrDefault();
            foreach (var item in context.Student_Subjects.Where(x => x.studentId_FK == id))
            {
                SubjectViewModel obj = new SubjectViewModel();
                obj.id = item.Subject.id;
                obj.subject1 = item.Subject.subject1;
                obj.creditHours = item.Subject.creditHours;
                obj.code = item.Subject.code;
                // obj.preSubjectId_FK = item.preSubjectId_FK;
                obj.day = item.Subject.day;
                obj.fromTime = item.Subject.fromTime.ToString();
                obj.toTime = item.Subject.toTime.ToString();
                depts.Add(obj);
            }
            return depts;

        }

        //ADD data in table [student_subject] using viewmodel
        public bool AddRegister(StudentSubjectViewModel dept)
        {
            Student_Subject check = context.Student_Subjects.FirstOrDefault(x => x.subjectId_FK == dept.subjectId_FK&&x.studentId_FK==dept.studentId_FK);

            if (check == null)
            {
                Student_Subject obj = new Student_Subject();
                try
                {
                    obj.studentId_FK = dept.studentId_FK;
                    obj.subjectId_FK = dept.subjectId_FK;
                    obj.isPassed = false;
                    context.Student_Subjects.Add(obj);
                    context.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }
        
        //Check if subject is there or not
        public bool CheckSubject(int subjectid, int studentid)
        {
            Student_Subject flag = context.Student_Subjects.FirstOrDefault(x => x.subjectId_FK==subjectid);
            if (flag != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete subject 
        public bool Delete(int subjectid ,int studentid)
        {
            try
            {
                if (subjectid > 0 && studentid>0)
                {
                    Student_Subject obj = context.Student_Subjects.FirstOrDefault(x => x.subjectId_FK == subjectid&&x.studentId_FK==studentid);
                    if (obj != null)
                    {
                        context.Student_Subjects.Remove(obj);
                        context.SaveChanges();
                        return true;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Check if register open or not
        public bool CheckRegister()
        {
            try
            {
                bool flag = context.CloseRegisters.Select(x => x.close).FirstOrDefault();
                if (flag == true)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
