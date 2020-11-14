using System;
using System.Collections.Generic;
using System.Linq;
using Dashboard.Models;

namespace Dashboard.Data
{
    public class ProjectRepo : IProjectRepo
    {
        private readonly DashboardContext _context;

        public ProjectRepo(DashboardContext context)
        {
            _context = context;
        }


        public Project GetProjectById(int id)
        {
            return _context.Projects.FirstOrDefault(project => project.Id == id);
        }

        public IEnumerable<Project> GetProjects()
        {
            return _context.Projects.ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void CreateProject(Project project)
        {

            if (project == null)
            {
                throw new ArgumentNullException(nameof(project));
            }

            _context.Projects.Add(project);
        }

    }
}
