using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GetToDo.Api.Models.Forms
{
    public class RegisterForm
    {
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required] 
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Passwd { get; set; }
    }
}
