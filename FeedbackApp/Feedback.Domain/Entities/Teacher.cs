using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Feedback.Domain.Entities
{
    public partial class Teacher
    {
        public Teacher()
        {

        }
        [Key]
        public int TeacherId { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Teacher Name")]

        public string TeacherName { get; set; }
        [MaxLength(200)]
        [Display(Name = "Teacher Description")]
        public string TeacherDescription { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Teacher Email")]
        [MaxLength(50)]
        public string Email { get; set; }
    }
}
