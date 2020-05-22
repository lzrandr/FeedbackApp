using Feedback.Domain;
using Feedback.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Feedback.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Feedback.Data
{
    public class TeacherRepository : ITeacherRepository
    {
        private FeedbackContext _context;

        public TeacherRepository(FeedbackContext context)
        {
            _context = context;
        }

        public IEnumerable<Teacher> GetTeachers()
        {
            return _context.Teachers.ToList();
        }

        public Teacher GetTeacherById(int id)
        {
            return _context.Teachers.SingleOrDefault(c => c.TeacherId == id);
        }

        public void CreateTeacher(TeacherViewModel teacherviewmodel)
        {
            var teacher = new Teacher();
            teacher.TeacherName = teacherviewmodel.TeacherName;
            teacher.TeacherDescription = teacherviewmodel.TeacherDescription;
            teacher.Email = teacherviewmodel.Email;
            _context.Add(teacher);
            _context.SaveChanges();

        }

        public void DeleteTeacher(int id)
        {
            var teacher = _context.Teachers.SingleOrDefault(c => c.TeacherId == id);
            _context.Teachers.Remove(teacher);
            _context.SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }

    public interface ITeacherRepository
    {
        IEnumerable<Teacher> GetTeachers();
        Teacher GetTeacherById(int id);
        void CreateTeacher(TeacherViewModel teacherviewmodel);
        void DeleteTeacher(int id);
        void SaveChanges();

    }
}
