using System;
using System.ComponentModel.DataAnnotations;

namespace Dashboard.Models
{
    public class Task
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Tittle { get; set; }

        [Required]
        public bool IsDone { get; set; }

        
    }
}
