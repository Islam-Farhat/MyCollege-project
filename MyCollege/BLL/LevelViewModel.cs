using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BLL
{
   public class LevelViewModel
    {
        [Key]
        public int id { get; set; }
        public string level1 { get; set; }
        public bool isActive { get; set; }
    }
}
