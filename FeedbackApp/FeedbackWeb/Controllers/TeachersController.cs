using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Feedback.Domain;
using Feedback.Domain.Entities;
using AutoMapper;
using Feedback.Domain.Models;
using Feedback.Data;

namespace FeedbackWeb.Controllers
{
    
    public class TeachersController : Controller
    {
        private readonly ITeacherRepository _repository;
        private readonly IMapper _mapper;
    

        public TeachersController(ITeacherRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }




        // GET: Teachers
        public async Task<IActionResult> Index()
        {
            var teacher = _repository.GetTeachers();
            //    var model = new List<CourseViewModel>();

            var teacherviewmodel = _mapper.Map<IEnumerable<TeacherViewModel>>(teacher);

            return View(teacherviewmodel);
        }

        // GET: Teachers/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var teacher = _repository.GetTeacherById(id);
            if (teacher == null)
            {
                return NotFound();
            }
            var teacherviewmodel = _mapper.Map<Teacher, TeacherViewModel>(teacher);
            return View(teacherviewmodel);
        }

        [HttpGet]
        //public IActionResult Create()
        //{

        //    return View();
        //}

        [HttpPost, ActionName("Create")]
        public IActionResult Create(TeacherViewModel teacherViewModel)
        {
            if (ModelState.IsValid)
            {
                _repository.CreateTeacher(teacherViewModel);
                //    return RedirectToAction(nameof(Index));
            }

            _repository.SaveChanges();

            return View(teacherViewModel);


        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var teacher = _repository.GetTeacherById(id);
            if (teacher == null)
            {
                return NotFound();
            }
            TeacherViewModel teacherviewmodel = _mapper.Map<Teacher, TeacherViewModel>(teacher);
            return View(teacherviewmodel);

        }

        [HttpPost, ActionName("Edit")]
        public async Task<IActionResult> EditPost(int id)
        {
            var teacherToUpdate = _repository.GetTeacherById(id);
            bool isUpdated = await TryUpdateModelAsync<Teacher>(
                                     teacherToUpdate,
                                     "",
                                     c => c.TeacherId,
                                     c => c.TeacherName,
                                     c => c.Email
                                     );
            if (isUpdated == true)
            {
                _repository.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            var teacherviewmodel = _mapper.Map<IEnumerable<TeacherViewModel>>(teacherToUpdate);
            return View(teacherviewmodel);

        }

        // GET: Teachers/Delete/5
        public IActionResult Delete(int id)
        {
            var teacher = _repository.GetTeacherById(id);
            if (teacher == null)
            {
                return NotFound();
            }
            return View(teacher);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _repository.DeleteTeacher(id);
            return RedirectToAction(nameof(Index));
        }
    }
}