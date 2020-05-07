using Feedback.Domain.Entities;
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
        void CreateFeedback(FeedBack feedback);
        void SaveChanges();
        IQueryable<Course> PopulateCoursesDropDownList();

    }
}
