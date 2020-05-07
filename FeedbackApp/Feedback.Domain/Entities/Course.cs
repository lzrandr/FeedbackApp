using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Feedback.Domain.Entities
{
    public partial class Course
    {

        [Key]
        public int CourseId { get; set; }
        [Required]
        public string CourseName { get; set; }

        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }
        [Required]
        public virtual Teacher Teacher { get; set; }

        public virtual ICollection<FeedBack> FeedBacks { get; set; }
    }
}
