using Feedback.Domain;
using Feedback.Domain.Entities;
using Feedback.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Feedback.Data;

namespace Feedback.Data
{

    public  class CourseRepository : ICourseRepository
    {
        private  FeedbackContext _dbcontext;
        public CourseRepository(FeedbackContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public IEnumerable<Course> GetAllCourses()
        {
            return _dbcontext.Courses.Include(c => c.Teacher).ToList();
        }
        public Course GetCourseById(int id)
        {
            return _dbcontext.Courses.SingleOrDefault(c => c.CourseId == id);
        }

        public void CreateCourse(CourseViewModel courseViewModel)
        {
            var course = new Course();
            course.CourseName = courseViewModel.CourseName;
            course.CourseDescription = courseViewModel.CourseDescription;
            course.TeacherId = courseViewModel.TeacherId;
            _dbcontext.Add(course);
            _dbcontext.SaveChanges();

        }

        public Teacher GetTeacherById(int id)
        {
            return _dbcontext.Teachers.SingleOrDefault(c => c.TeacherId == id);
        }

        public void DeleteCourse(int id)
        {
            var course = _dbcontext.Courses.SingleOrDefault(c => c.CourseId == id);
            _dbcontext.Courses.Remove(course);
            _dbcontext.SaveChanges();
        }

        public void SaveChanges()
        {
            _dbcontext.SaveChanges();
        }
        public IQueryable<Teacher> PopulateTeachersDropDownList()
        {
            var teachersQuery = from b in _dbcontext.Teachers
                               orderby b.TeacherName
                               select b;
            return teachersQuery;
        }
    }
}
