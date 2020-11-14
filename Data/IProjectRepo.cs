using System;
using System.Collections.Generic;
using Dashboard.Models;

namespace Dashboard.Data
{
    public interface IProjectRepo
    {
        bool SaveChanges();
        void CreateProject(Project project);
        IEnumerable<Project> GetProjects();
        Project GetProjectById(int id);
    }
}
