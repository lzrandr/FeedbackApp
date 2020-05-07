using Feedback.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackWeb.Models
{
    public class CourseViewModel
    {

        public int Id { get; set; }
        [Required]
        public string CourseName { get; set; }

        public virtual ICollection<FeedBack> FeedBacks { get; set; }
    }
}
