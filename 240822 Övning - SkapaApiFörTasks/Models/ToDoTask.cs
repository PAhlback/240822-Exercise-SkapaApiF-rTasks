using System.ComponentModel.DataAnnotations;

namespace _240822_Övning___SkapaApiFörTasks.Models
{
    public class ToDoTask
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Title { get; set; }

        [MaxLength(150)]
        public string? Description { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
