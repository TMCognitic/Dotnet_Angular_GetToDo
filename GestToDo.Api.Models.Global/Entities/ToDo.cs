using System;
using System.Collections.Generic;
using System.Text;

namespace GestToDo.Api.Models.Global.Entities
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Ended { get; set; }
        public DateTime CreationDate { get; set; }
        public int UserId { get; set; }
    }
}
