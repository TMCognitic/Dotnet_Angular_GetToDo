using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestToDo.MVC.Models.Forms
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
        [DataType(DataType.Password)]
        [MinLength(8)]
        [DisplayName("Password")]
        public string Passwd { get; set; }
        [Compare(nameof(Passwd))]
        [DataType(DataType.Password)]
        [DisplayName("Confirmation")]
        public string Confirm { get; set; }
    }
}