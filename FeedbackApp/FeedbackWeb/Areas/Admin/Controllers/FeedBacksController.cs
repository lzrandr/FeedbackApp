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

namespace FeedbackWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeedBacksController : Controller
    {
        private readonly IFeedBackRepository _repository;
        private readonly IMapper _mapper;

        public FeedBacksController(IFeedBackRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: Admin/FeedBacks
        public async Task<IActionResult> Index()
        {
            var courses = _repository.PopulateCoursesDropDownList();
            ViewBag.CourseId = new SelectList(courses.AsNoTracking(), "CourseId", "CourseName");
            var feedback = _repository.GetFeedback();

            var model = _mapper.Map<IEnumerable<FeedbackViewModel>>(feedback);
            return View(model.ToList());
        }

        private void PopulateCoursesDropDownList(int? selectedCourse = null)
        {
            var courses = _repository.PopulateCoursesDropDownList();
            ViewBag.CourseId = new SelectList(courses.AsNoTracking(), "CourseId", "CourseName", selectedCourse);
        }
    }
}
