using System;
using System.ComponentModel.DataAnnotations;

namespace Dashboard.Dtos
{
    public class UserCreateDto
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
