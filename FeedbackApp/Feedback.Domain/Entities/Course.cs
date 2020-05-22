using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Feedback.Domain.Entities
{
    public partial class Course
    {
        public Course()
        {

        }

        [Key]
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


