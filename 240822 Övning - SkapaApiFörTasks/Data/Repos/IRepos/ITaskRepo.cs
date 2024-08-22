using _240822_Övning___SkapaApiFörTasks.Models;
using _240822_Övning___SkapaApiFörTasks.Models.DTOs;
using _240822_Övning___SkapaApiFörTasks.Models.ViewModels;

namespace _240822_Övning___SkapaApiFörTasks.Data.Repos.IRepos
{
    public interface ITaskRepo
    {
        Task CreateNewTask(ToDoTask newTask);
        Task DeleteTask(int id);
        Task<List<ToDoTask>> GetAllTasks();
        Task<ToDoTask> GetTaskById(int id);
        Task UpdateTask(int id, ToDoTask task);
    }
}
