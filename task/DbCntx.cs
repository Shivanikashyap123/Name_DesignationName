using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task.Models;
using Microsoft.EntityFrameworkCore;



namespace task
{
    public class DbCntx:DbContext
    {
        public DbCntx(DbContextOptions<DbCntx> options) : base(options)
        {

        }
        public DbSet<Student> students { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Subject> Subjects { get; set; }

    }
}
