using System;
using System.ComponentModel.DataAnnotations;

namespace Dashboard.Dtos
{
    public class ProjectCreateDto
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
