using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace task.Models
{
    public class Grade
    {
        [Key]

        public int GID { get; set; }
        public string GName { get; set; }
        
    }
}
