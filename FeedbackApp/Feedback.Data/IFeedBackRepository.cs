using Feedback.Domain.Entities;
using Feedback.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Feedback.Data
{
    public interface IFeedBackRepository
    {
        IEnumerable<FeedBack> GetFeedback();
        //Course GetFeedbackById(int id);
        void CreateFeedback(FeedbackViewModel feedbackViewModel);
        void SaveChanges();
        IQueryable<Course> PopulateCoursesDropDownList();

    }
}
