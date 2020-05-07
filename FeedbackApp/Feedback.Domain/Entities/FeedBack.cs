using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Feedback.Domain.Entities
{
    public partial class FeedBack
    {
    
        [Key]
        public int FeedbackId { get; set; }

        [Required]
        [ForeignKey("Course")]
        public int? CourseId { get; set; }
        public virtual Course Course { get; set; }

        [Required]
        public string FeedbackWriterName { get; set; }
        [Required]
        [EmailAddress]
        public string FeedbackWriterEmail { get; set; }
        [Required(ErrorMessage = "Please enter a feedback")]
        [MaxLength(1500)]
        [Display(Name = "Feedback:")]
        public string TheFeedback { get; set; }
        [Required]
        public DateTime Date { get { return DateTime.Now; } }
    }
}
