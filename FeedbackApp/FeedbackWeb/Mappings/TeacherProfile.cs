using AutoMapper;
using Feedback.Domain.Entities;
using Feedback.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackWeb.Mappings
{
    public class TeacherProfile : Profile
    {
        public TeacherProfile()
        {
            CreateMap<Teacher, TeacherViewModel>();
            CreateMap<TeacherViewModel, Teacher>();
        }

    }

}


