using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace BLL
{
   public class SubjectViewModel
    {
        [Key]
        public int id { get; set; }
        public string subject1 { get; set; }
        public double creditHours { get; set; }
        public string code { get; set; }
        public bool isActive { get; set; }
        public Nullable<int> deptId_FK { get; set; }
        public Nullable<int> preSubjectId_FK { get; set; }
        public string day { get; set; }
        public string fromTime { get; set; }
        public string toTime { get; set; }
    }
}
