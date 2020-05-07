using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Feedback.Data;
using Feedback.Domain.Entities;
using FeedbackWeb.Models;
using Microsoft.AspNetCore.Mvc;

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
         //    var model = new List<CourseViewModel>();
        
            var model = _mapper.Map<IEnumerable<CourseViewModel>>(coursesListFromDb);
            //foreach (var course in coursesListFromDb)
            //{
            //    var courseModelItem = new CourseViewModel();
            //    courseModelItem.Id = course.Id;
            //    courseModelItem.CourseName = course.CourseName;
            //    model.Add(courseModelItem);
            //}
            return View(model);
        }
    }
}