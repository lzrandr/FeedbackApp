﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Feedback.Data;
using Feedback.Domain.Entities;
using FeedbackWeb.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FeedbackWeb.Controllers
{
    public class FeedbacksController : Controller
    {


        private readonly IFeedBackRepository _repository;
        private IWebHostEnvironment _environment;
        private readonly IMapper _mapper;

        public FeedbacksController(IFeedBackRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var coursesListFromDb = _repository.GetFeedback();
            var model = _mapper.Map<IEnumerable<FeedbackViewModel>>(coursesListFromDb);
            return View(model);

        }



        [HttpGet]
        public IActionResult Create()
        {
            PopulateCoursesDropDownList();
            return View();
        }

        [HttpPost, ActionName("Create")]
        public IActionResult CreatePost(FeedBack feedback)
        {
            if (ModelState.IsValid)
            {
                _repository.CreateFeedback(feedback);
              //  return RedirectToAction(nameof(Index));
            }

            _repository.CreateFeedback(feedback);
            var model = _mapper.Map<FeedbackViewModel>(feedback);
            return View(model);

            //if (ModelState.IsValid)
            //{
            //    _repository.CreateFeedback(feedback);
            //  //  return RedirectToAction(nameof(Index));
            //}
            //PopulateCoursesDropDownList(feedback.CourseId);
            //return View(feedback);
        }

        private void PopulateCoursesDropDownList(int? selectedCourse = null)
        {

            var courses = _repository.PopulateCoursesDropDownList();
            ViewBag.CourseId = new SelectList(courses.AsNoTracking(), "CourseId", "CourseName", selectedCourse);
        }

    }

}
