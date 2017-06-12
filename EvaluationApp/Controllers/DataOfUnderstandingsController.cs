using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EvaluationApp.Data;
using EvaluationApp.Models;
using EvaluationApp.Models.ViewModels;

namespace EvaluationApp.Controllers
{
    public class DataOfUnderstandingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DataOfUnderstandingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        //[HttpGet]
        //public IActionResult Index()
        //{
        //    return View("InsertUserName");
        //}

        //[HttpPost]
        //public IActionResult Index(string username)
        //{
        //    return View("Index", username);
        //}

        // GET: DataOfUnderstandings
        public async Task<IActionResult> Index(string name, int lectureId)
        {
            // query the database to check if the student exists (going to models)
            var student = _context.Students.FirstOrDefault(f => f.Name == name);
            // if it does not exist, we want to add to the database and pass it the viewmodel (creating if new student)
            if (student == null)
            {
                student = new Students
                {
                    Name = name,
                    LecturesId = lectureId,
                };
                _context.Students.Add(student);
                await _context.SaveChangesAsync();
            }
            var vm = new EvaluatorViewModel
            {
                Students = student, 
                LectureId = lectureId
            };
            return View(vm);
        }

        [HttpPost]
        public ActionResult Up([FromBody][Bind("StudentsId,LecturesId")] DataOfUnderstanding data)
        {
            // student, lecture, time, t/f
            data.Time = DateTime.Now;
            data.UnderstandingYorN = true;
            
            // add to database
            _context.Add(data);
            _context.SaveChanges();
            return Json("successful upvote");
        }

        [HttpPost]
        public ActionResult Down([FromBody][Bind("StudentsId,LecturesId")] DataOfUnderstanding data)
        {
            // student, lecture, time, t/f
            data.Time = DateTime.Now;
            data.UnderstandingYorN = false;

            // add to database
            _context.Add(data);
            _context.SaveChanges();
            return Json("successful downvote");
        }

        //// POST: DataOfUnderstandings/Comment
        //// Create comment without showing view
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Comment([FromBody][Bind("StudentsId,LecturesId")] /*Questions questions,*/ string question)
        //{
        //    //questions.TimeAsked = DateTime.Now;
        //    //questions.QuestionText = question;
        //    var studentquestion = question;
        //    studentquestion = new Questions
        //    {
        //        QuestionText = studentquestion,
        //        TimeAsked = DateTime.Now,
        //    };

        //    _context.Add(studentquestion);
        //    await _context.SaveChangesAsync();
        //    return Json("successful comment made"); //Redirect("/");
        //}

        // POST: DataOfUnderstanding/Comments
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Comments([Bind("Id,Name,School,CourseID")] DataOfUnderstanding comment)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(comment);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    return View(comment);
        //}

    }
}
