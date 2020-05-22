using Feedback.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using Feedback.Domain.Models;


namespace Feedback.Data
{


        public interface ICourseRepository
        {
            IEnumerable<Course> GetAllCourses();
            Course GetCourseById(int id);
            void CreateCourse(CourseViewModel courseViewModel);
            void DeleteCourse(int id);
            void SaveChanges();
        IQueryable<Teacher> PopulateTeachersDropDownList();

        }
    
}
