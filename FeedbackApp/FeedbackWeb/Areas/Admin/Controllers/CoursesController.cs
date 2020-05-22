using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Feedback.Data;
using Feedback.Domain.Entities;
using Feedback.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using static Feedback.Data.CourseRepository;

namespace FeedbackWeb.Controllers
{
    [Area("Admin")]
    public class CoursesController : Controller
    {
        private readonly ICourseRepository _repository;
        private readonly IMapper _mapper;

        public CoursesController(ICourseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var coursesListFromDb = _repository.GetAllCourses();
        
            var model = _mapper.Map<IEnumerable<CourseViewModel>>(coursesListFromDb);

            return View(model);
        }


        [HttpGet]
        public IActionResult Create()
        {
            PopulateTeachersDropDownList();
            return View();
        }
       

        [HttpPost, ActionName("Create")]
        public IActionResult CreatePost(CourseViewModel courseViewModel)
        {
            if (ModelState.IsValid)
            {
                _repository.CreateCourse(courseViewModel);
                return RedirectToAction(nameof(Index));
            }

            _repository.SaveChanges();

            return View(courseViewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var course = _repository.GetCourseById(id);
            if (course == null)
            {
                return NotFound();
            }
            PopulateTeachersDropDownList(course.TeacherId);
            CourseViewModel courseViewModel = _mapper.Map<Course, CourseViewModel>(course);
            return View(courseViewModel);

        }

        [HttpPost, ActionName("Edit")]
        public async Task<IActionResult> EditPost(int id)
        {
            var courseToUpdate = _repository.GetCourseById(id);
            bool isUpdated = await TryUpdateModelAsync<Course>(
                                     courseToUpdate,
                                     "",
                                     c => c.TeacherId,
                                     c => c.CourseId,
                                     c => c.CourseName,
                                     c => c.CourseDescription
                                     );
            if (isUpdated == true)
            {
                _repository.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            var courseViewModel = _mapper.Map<IEnumerable<CourseViewModel>>(courseToUpdate);
            return View(courseViewModel);

        }

        // GET: Courses/Delete/5
        public IActionResult Delete(int id)
        {
            var courseToDelete = _repository.GetCourseById(id);
            if (courseToDelete == null)
            {
                return NotFound();
            }
            CourseViewModel courseViewModel = _mapper.Map<Course, CourseViewModel>(courseToDelete);
            return View(courseViewModel);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
             _repository.DeleteCourse(id);
            return RedirectToAction(nameof(Index));
          
        }

        
        private void PopulateTeachersDropDownList(int? selectedCourse = null)
        {

            var teachers = _repository.PopulateTeachersDropDownList();
            ViewBag.TeacherId = new SelectList(teachers.AsNoTracking(), "TeacherId", "TeacherName", selectedCourse);
        }
    }
}