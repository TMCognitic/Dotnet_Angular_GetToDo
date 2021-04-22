using System;
using System.Collections.Generic;
using System.Text;

namespace GestToDo.Api.Models.Client.Entities
{
    public class User
    {
        public int Id { get; private set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Passwd { get; set; }

        public User(string lastName, string firstName, string email, string passwd)
        {
            LastName = lastName;
            FirstName = firstName;
            Email = email;
            Passwd = passwd;
        }

        internal User(int id, string lastName, string firstName, string email)
            : this(lastName, firstName, email, null)
        {
            Id = id;
        }
    }
}
