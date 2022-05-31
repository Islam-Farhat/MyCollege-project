using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using DataModels;

namespace DAL
{
    interface IDepartmentReposatoriy
    {
        IEnumerable<DepartmentViewModel> DropdownlistDepartment();
    }
   public class DepartmentReposatoriy: IDepartmentReposatoriy
    {
        MyCollegeEntities context = new MyCollegeEntities();
        //Dropdownlist Department in a page
        public IEnumerable<DepartmentViewModel> DropdownlistDepartment()
        {
            List<DepartmentViewModel> depts = new List<DepartmentViewModel>();
            foreach (var item in context.Departments)
            {
                DepartmentViewModel obj = new DepartmentViewModel();
                obj.id = item.id;
                obj.department1 = item.department1;
                depts.Add(obj);
            }
            return depts;
        }
    }
}
