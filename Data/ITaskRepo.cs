using System;
using System.Collections.Generic;
using Dashboard.Dtos;
using Dashboard.Models;

namespace Dashboard.Data
{
    public interface ITaskRepo
    {
        bool SaveChanges();
        IEnumerable<Task> GetTasks();
        TaskReadDto GetTaskById(int id);
        void CreateTask(Task task);
        void UpdateTask(Task task);
        void DeleteTask(Task task);
    }
}
