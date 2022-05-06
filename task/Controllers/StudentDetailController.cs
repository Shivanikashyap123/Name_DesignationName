using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task.Models;

namespace task.Controllers
{
    public class StudentDetailController : Controller
    {
        private readonly DbCntx _context;

        public StudentDetailController(DbCntx context)
        {
            _context = context;
        }
        //public void Populatesubjects()
        //{
        //    List<Subject> dl = new List<Subject>();
        //    dl = (from d in _context.Subjects select d).ToList();
        //    dl.Insert(0, new Subject { ID = 0, SubjectName = "--Select Subject Name--" });
        //    ViewBag.subject = dl;
        //}
        private void PopulateSubjectsddl(object selectedSubject = null)
        {
            try
            {
                List<Subject> subjectsQuery = new List<Subject>();
                subjectsQuery = (from d in _context.Subjects
                                 orderby d.SubName
                                 select d).ToList();
                subjectsQuery.Insert(0, new Subject { SID = 0, SubName = "" });
                //    ViewBag.subject = dl
                ViewBag.subjectID =
                new SelectList(subjectsQuery.AsReadOnly(), "SID", "SubName", selectedSubject);
            }
            catch (Exception e)
            {
                throw;
            }
        }
        private void PopulateGradesddl(object selectedGrade = null)
        {
            try
            {
                List<Grade> subjectsQuery = new List<Grade>();
                var gradesQuery = (from d in _context.Grades
                                   orderby d.GName
                                   select d).ToList();
                gradesQuery.Insert(0, new Grade { GID = 0, GName = "" });

                ViewBag.GradeID = new SelectList(gradesQuery.AsReadOnly(), "GID", "GName", selectedGrade);
            }
            catch (Exception e)
            {
                throw;
            }
        }


        // GET: StudentDetailController
        public async Task<IActionResult> Index(string SearchString, string SelectGrade,string selectSubject)
        {
            PopulateGradesddl();
            PopulateSubjectsddl();

            var Students = from s in _context.students
                           select s;
            if (!String.IsNullOrEmpty(SelectGrade))
            {
                Students = Students.Where(s => s.GradeNames.GName.Contains(SelectGrade));
            }
            if (!String.IsNullOrEmpty(selectSubject))
            {
                Students = Students.Where(s => s.SubjectNames.SubName.Contains(selectSubject));
            }
            if (!String.IsNullOrEmpty(SearchString))
            {
                Students = Students.Where(s => s.LastName.Contains(SearchString));
               
            }
            return View(await Students.AsTracking().ToListAsync());
            
            //studentDet = await _context.students.Contains(LastName == SearchString).ToListAsync();

        }

        // GET: StudentDetailController/Details/5
        public async Task<IActionResult> Details(int? studentId)
        {
            if (studentId == null)
            {
                return NotFound();
            }

            var stu = await _context.students.FirstOrDefaultAsync(m => m.StudentId == studentId);
            PopulateGradesddl(stu.GradeId);
            PopulateSubjectsddl(stu.SubjectId);
            if (stu == null)
            {
                return NotFound();
            }
            return View(stu);
        }

        // GET: StudentDetailController/AddOrEdit
        public async Task<IActionResult> AddOrEdit(int? studentId)
        {


            ViewBag.PageName = studentId == null ? "Create Student" : "Edit Student";
            ViewBag.IsEdit = studentId == null ? false : true;
            if (studentId == null)
            {
                try
                {

                    PopulateGradesddl();
                    PopulateSubjectsddl();
                    return View();
                }
                catch (Exception e)
                {
                    return NotFound();
                }

            }
            else
            {
                Student stu = await _context.students.AsNoTracking().FirstOrDefaultAsync(m => m.StudentId == studentId);
                PopulateGradesddl(stu.GradeId);
                PopulateSubjectsddl(stu.StudentId);
                if (stu == null)
                {
                    return NotFound();
                }

                return View(stu);
            }
        }



        // POST: StudentDetailController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int studentId, [Bind("StudentId,FirstName,LastName,GradeId,GradeName,SubjectId,SubjectName,Marks")] Student studentData)
        {



            Student stu = await _context.students.AsNoTracking().FirstOrDefaultAsync(m => m.StudentId == studentId);

            if (stu == null)
            {
                if (ModelState.IsValid)
                {

                    _context.Add(studentData);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }


            }
            else
            {

                _context.Update(studentData);
                PopulateGradesddl(studentData.GradeId);
                PopulateSubjectsddl(studentData.SubjectId);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }


            return View(studentData);





        }



        // GET: StudentDetailController/Delete/5
        public async Task<IActionResult> Delete(int? studentId)
        {
            if (studentId == null)
            {
                return NotFound();
            }
            var stu = await _context.students.FirstOrDefaultAsync(m => m.StudentId == studentId);
            PopulateGradesddl(stu.GradeId);
            PopulateSubjectsddl(stu.SubjectId);
            return View(stu);
        }

        // POST: StudentDetailController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int studentId)
        {
            var stu = await _context.students.FindAsync(studentId);
            _context.students.Remove(stu);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}
