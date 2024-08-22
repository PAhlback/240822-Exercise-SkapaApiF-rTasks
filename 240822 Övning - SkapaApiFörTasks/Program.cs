
using _240822_Övning___SkapaApiFörTasks.Data;
using _240822_Övning___SkapaApiFörTasks.Data.Repos;
using _240822_Övning___SkapaApiFörTasks.Data.Repos.IRepos;
using _240822_Övning___SkapaApiFörTasks.Services;
using Microsoft.EntityFrameworkCore;

namespace _240822_Övning___SkapaApiFörTasks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<TasksDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<ITaskRepo, TaskRepo>();
            builder.Services.AddScoped<ITaskServices, TaskServices>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
