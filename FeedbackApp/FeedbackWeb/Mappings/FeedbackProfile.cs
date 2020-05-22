using AutoMapper;
using Feedback.Domain.Entities;
using Feedback.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackWeb.Mappings
{
    public class FeedbackProfile : Profile
    {
        public FeedbackProfile()
        {
            CreateMap<FeedBack, FeedbackViewModel>();
            CreateMap<FeedbackViewModel, FeedBack>();
        }


    }
}
