using System;
using System.Collections.Generic;
using System.Text;

namespace GestToDo.Api.Models.Client.Entities
{
    public class ToDo
    {
        public ToDo(string title, int userId, string description = "")
        {
            Title = title;
            Description = description;
            UserId = userId;
        }

        internal ToDo(int id, string title, string description, bool ended, int userId)
            : this (title, userId, description)
        {
            Id = id;
            Ended = ended;
        }

        public int Id { get; private set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Ended { get; set; }
        public int UserId { get; set; }
    }
}
