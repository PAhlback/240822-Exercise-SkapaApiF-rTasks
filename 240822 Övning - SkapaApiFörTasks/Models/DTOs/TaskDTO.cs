using System.ComponentModel.DataAnnotations;

namespace _240822_Övning___SkapaApiFörTasks.Models.DTOs
{
    public class TaskDTO
    {
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Title { get; set; }

        [MaxLength(150)]
        public string? Description { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
