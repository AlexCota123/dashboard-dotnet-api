using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dashboard.Dtos
{
    public class ProjectReadDto
    {
        public int Id { get; set; }


        public string Name { get; set; }

        public string Description { get; set; }

        public List<Task> Tasks { get; set; }

    }
}
