using AutoMapper;
using Feedback.Domain;
using Feedback.Domain.Entities;
using Feedback.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Feedback.Data
{

    public class FeedbackRepository : IFeedBackRepository
    {
        private FeedbackContext _context;
        private  IMapper _mapper;

        public FeedbackRepository(FeedbackContext context)
        {
            _context = context;
        }

        public IEnumerable<FeedBack> GetFeedback()
        {
            return _context.Feedbacks.Include(c => c.Course).ToList();
        }

        //public FeedBack GetFeedbackById(int id)
        //{
        //    return _context.Feedbacks.Include(b => b.Course)
        //         .SingleOrDefault(c => c.Id == id);
        //}

        public void CreateFeedback(FeedbackViewModel feedbackViewModel)
        {
            var feedback = new FeedBack();
            feedback.CourseId = feedbackViewModel.CourseId;
            feedback.TheFeedback = feedbackViewModel.TheFeedback;
            feedback.FeedbackWriterName = feedbackViewModel.FeedbackWriterName;
            feedback.FeedbackWriterEmail = feedbackViewModel.FeedbackWriterEmail;
            _context.Add(feedback);
            _context.SaveChanges();

        }

      
        public void SaveChanges()
        {
            _context.SaveChanges();
            
        }

        public IQueryable<Course> PopulateCoursesDropDownList()
        {
            var coursesQuery = from b in _context.Courses
                                orderby b.CourseName
                                select b;
            return coursesQuery;
        }

       
    }
}

