using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace task.Models
{
    public class Subject
    {
        [Key]
        public int SID { get; set; }
        public string SubName { get; set; }
      
    }
}
