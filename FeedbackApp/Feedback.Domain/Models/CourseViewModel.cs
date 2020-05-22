using Feedback.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Feedback.Domain.Models
{
    public class CourseViewModel
    { 
        public int CourseId { get; set; }
        [Required]
        [Display(Name = "Course Name")]
        [MaxLength(50)]
        public string CourseName { get; set; }
        [Display(Name = "Course Description")]
        [MaxLength(200)]
        public string CourseDescription { get; set; }
        [Required]
        [ForeignKey("Teacher")]
        public int? TeacherId { get; set; }

        public virtual Teacher Teacher { get; set; }

        public virtual ICollection<FeedBack> FeedBacks { get; set; }


    }
}
