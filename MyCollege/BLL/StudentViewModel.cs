using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BLL
{
   public class StudentViewModel
    {
        [Key]
        public int id { get; set; }
        public Nullable<int> levelId_Fk { get; set; }
        public decimal nationalId { get; set; }
        public string mobile { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string surName { get; set; }
        public Nullable<int> deptId_FK { get; set; }
        public int genderId_FK { get; set; }
        public string image { get; set; }
        public bool isActive { get; set; }
    }
}
