using System;
using System.Collections.Generic;
using Dashboard.Models;

namespace Dashboard.Dtos
{
    public class TaskReadDto : Task
    {
        public TaskReadDto() : base()
        { }

        public TaskReadDto(Task task, Project p) : base()
        {
            Id = task.Id;
            Tittle = task.Tittle;
            IsDone = task.IsDone;
            Project = p;
            Console.WriteLine(p.Name);
        }

        public Project Project { get; set; }
    }
}
