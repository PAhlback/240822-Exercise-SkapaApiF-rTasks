using _240822_Övning___SkapaApiFörTasks.Data.Repos.IRepos;
using _240822_Övning___SkapaApiFörTasks.Models;
using _240822_Övning___SkapaApiFörTasks.Models.DTOs;
using _240822_Övning___SkapaApiFörTasks.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace _240822_Övning___SkapaApiFörTasks.Data.Repos
{
    public class TaskRepo : ITaskRepo
    {
        private readonly TasksDbContext _context;

        public TaskRepo(TasksDbContext context)
        {
            _context = context;
        }

        public async Task CreateNewTask(ToDoTask newTask)
        {
            await _context.Tasks.AddAsync(newTask);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTask(int id)
        {
            ToDoTask? task = await _context.Tasks.SingleOrDefaultAsync(t => t.Id == id);

            if (task != null)
            {
                _context.Remove(task);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<List<ToDoTask>> GetAllTasks()
        {
            List<ToDoTask> allTasks = await _context.Tasks.ToListAsync();

            return allTasks;
        }

        public async Task<ToDoTask> GetTaskById(int id)
        {
            ToDoTask? task = await _context.Tasks.SingleOrDefaultAsync(t => t.Id == id);

            return task;
        }

        public async Task UpdateTask(int id, ToDoTask task)
        {
            ToDoTask updateTask = await GetTaskById(id);

            updateTask.Title = task.Title;
            updateTask.Description = task.Description;
            updateTask.Status = task.Status;

            _context.Update(updateTask);
            await _context.SaveChangesAsync();
        }
    }
}
