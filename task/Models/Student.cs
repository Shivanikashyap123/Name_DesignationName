using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace task.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GradeId { get; set; }
        [ForeignKey("GradeId")]
        public Grade GradeNames { get; set; }
       
        public int SubjectId { get; set; }
        [ForeignKey("SubjectId")]
        public Subject SubjectNames { get; set; }


        public string Marks { get; set; }
       


    }
    
    
}
