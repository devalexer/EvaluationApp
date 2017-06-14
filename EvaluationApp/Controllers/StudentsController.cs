using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EvaluationApp.Data;
using EvaluationApp.Models;

namespace EvaluationApp.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // Student Portal: Requests student name
        public IActionResult Portal(int id)
        {
            ViewData["lecturesId"] = id;
            return View();
        }

        //Student Attendance Page
        public async Task<IActionResult> Attendance(int id)
        {
            var studentsNames = _context.Students.Where(s => s.LecturesId == id);
            ViewData["lecturesId"] = id;
            var vm = await studentsNames.ToListAsync();
            return View(vm);
        }
    }
}
