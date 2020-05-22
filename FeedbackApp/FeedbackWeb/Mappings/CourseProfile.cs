using AutoMapper;
using Feedback.Domain.Entities;
using Feedback.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackWeb.Mappings
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseViewModel>();
        }

   
    }
}
