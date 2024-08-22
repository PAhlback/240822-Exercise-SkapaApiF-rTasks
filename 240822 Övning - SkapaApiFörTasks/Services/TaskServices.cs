using _240822_Övning___SkapaApiFörTasks.Data.Repos.IRepos;
using _240822_Övning___SkapaApiFörTasks.Models;
using _240822_Övning___SkapaApiFörTasks.Models.DTOs;
using _240822_Övning___SkapaApiFörTasks.Models.ViewModels;

namespace _240822_Övning___SkapaApiFörTasks.Services
{
    public interface ITaskServices
    {
        Task CreateNewTask(TaskDTO dto);
        Task DeleteTask(int id);
        Task<List<ToDoTaskViewModel>> GetAllTasks();
        Task<ToDoTaskViewModel> GetTaskById(int id);
        Task UpdateTask(int id, TaskDTO dto);
    }
    
    public class TaskServices : ITaskServices
    {
        readonly ITaskRepo _taskRepo;

        public TaskServices(ITaskRepo taskRepo)
        {
            _taskRepo = taskRepo;
        }

        public async Task CreateNewTask(TaskDTO dto)
        {
            ToDoTask newTask = new ToDoTask
            {
                Title = dto.Title,
                Description = dto.Description,
                Status = dto.Status,
            };

            await _taskRepo.CreateNewTask(newTask);
        }

        public async Task DeleteTask(int id)
        {
            await _taskRepo.DeleteTask(id);
        }

        public async Task<List<ToDoTaskViewModel>> GetAllTasks()
        {
            List<ToDoTask> tasks = await _taskRepo.GetAllTasks();

            List<ToDoTaskViewModel> toDoTaskViewModels = tasks
                .Select(t => new ToDoTaskViewModel
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    Status = t.Status
                })
                .ToList();

            return toDoTaskViewModels;
        }

        public async Task<ToDoTaskViewModel> GetTaskById(int id)
        {
            ToDoTask task = await _taskRepo.GetTaskById(id);

            ToDoTaskViewModel taskViewModel = new ToDoTaskViewModel
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Status = task.Status
            };

            return taskViewModel;
        }

        public async Task UpdateTask(int id, TaskDTO dto)
        {
            ToDoTask task = await _taskRepo.GetTaskById(id);

            task.Title = dto.Title;
            task.Description = dto.Description;
            task.Status = dto.Status;

            await _taskRepo.UpdateTask(id, task);
        }
    }
}
