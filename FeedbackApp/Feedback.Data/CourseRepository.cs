using Feedback.Domain.Entities;
using Feedback.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Feedback.Data
{
    public interface ICourseRepository
    {
        List<Course> GetAllCourses();
    }
    public class CourseRepository : ICourseRepository
    {
        private readonly FeedbackContext _dbcontext;
        public CourseRepository(FeedbackContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public List<Course> GetAllCourses()
        {
            return _dbcontext.Courses.ToList();
        }
    }
}
