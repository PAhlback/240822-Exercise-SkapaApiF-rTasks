using _240822_Övning___SkapaApiFörTasks.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using _240822_Övning___SkapaApiFörTasks.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using _240822_Övning___SkapaApiFörTasks.Data.Repos.IRepos;
using _240822_Övning___SkapaApiFörTasks.Services;
using _240822_Övning___SkapaApiFörTasks.Models.DTOs;

namespace _240822_Övning___SkapaApiFörTasks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        readonly ITaskServices _taskService;

        public TasksController(ITaskServices taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("GetTasks")]
        public async Task<IActionResult> GetAllTasks()
        {
            var allTasks = await _taskService.GetAllTasks();

            return Ok(allTasks);
        }

        [HttpGet("GetTaskById")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            ToDoTaskViewModel task = await _taskService.GetTaskById(id);

            return Ok(task);
        }

        [HttpPost("PostTask")]
        public async Task<IActionResult> CreateNewTask(TaskDTO dto)
        {
            await _taskService.CreateNewTask(dto);

            return Created();
        }

        [HttpPut("UpdateTask")]
        public async Task<IActionResult> UpdateTask(int id, TaskDTO dto)
        {
            await _taskService.UpdateTask(id, dto);

            return Ok();
        }

        [HttpDelete("DeleteTask")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            await _taskService.DeleteTask(id);

            return Ok();
        }

    }
}
