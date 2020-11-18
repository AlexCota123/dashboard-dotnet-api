using System;
using System.Collections.Generic;
using System.Linq;
using Dashboard.Dtos;
using Dashboard.Models;

namespace Dashboard.Data
{
    public class TaskRepo : ITaskRepo
    {
        private readonly DashboardContext _context;

        public TaskRepo(DashboardContext context)
        {
            _context = context;
        }

        public IEnumerable<Task> GetTasks()
        {
            //var tasks = new List<Task>
            //{
            //    new Task{Id = 0, Name = "Alejandro", LastName = "Cota", Age = 23},
            //    new Task{Id = 1, Name = "Luci", LastName = "Diamonds", Age = 24 },
            //    new Task{Id=2, Name="Jose", LastName="Aguirre", Age =26}
            //};
           

            return _context.Tasks.ToList();
        }

        public TaskReadDto GetTaskById(int id)
        {
            var tasking = _context.Tasks.Where(t => t.Id == id).Select(t => new TaskReadDto(t,
                _context.Projects.FirstOrDefault(p => true)
            ));

            return tasking.FirstOrDefault();

            //return _context.Tasks.FirstOrDefault(task => task.Id == id);
        }

        public bool SaveChanges()
        {
            return ( _context.SaveChanges() >= 0 );
        }

        public void CreateTask(Task task)
        {
            if(task == null)
            {
                throw new ArgumentNullException(nameof(task));
            }

            _context.Tasks.Add(task);
        }

        public void UpdateTask(Task task)
        {
            _context.Tasks.Update(task);

        }

        public void DeleteTask(Task task)
        {
            _context.Tasks.Remove(task);
        }
    }
}
