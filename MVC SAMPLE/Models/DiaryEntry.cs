using System.ComponentModel.DataAnnotations;

namespace MVC_SAMPLE.Models
{
    public class DiaryEntry
    {
        
        public int ID { get; set; }
        [Required(ErrorMessage = "Please Enter a Title!")]
        [StringLength(100, MinimumLength = 3, ErrorMessage ="Title must be between 3 and 100 Character")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please Enter a Content!")]
        public string Content { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please Enter a Created!")]
        public required DateTime Created { get; set; } = DateTime.Now;


    }
}
