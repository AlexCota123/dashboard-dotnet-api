using System;
using System.ComponentModel.DataAnnotations;

namespace Dashboard.Dtos
{
    public class TaskCreateDto
    {

        [Required(AllowEmptyStrings = false)]
        public string Tittle { get; set; }

        public bool IsDone { get; set; } = false;
    }
}
