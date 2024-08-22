using System.ComponentModel.DataAnnotations;

namespace _240822_Övning___SkapaApiFörTasks.Models.ViewModels
{
    public class ToDoTaskViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string? Description { get; set; }

        public string Status { get; set; }
    }
}
