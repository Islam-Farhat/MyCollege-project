using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BLL
{
    public class DepartmentViewModel
    {
        [Key]
        public int id { get; set; }
        public string department1 { get; set; }
        public int headId_FK { get; set; }
        public bool isActive { get; set; }
    }
}
