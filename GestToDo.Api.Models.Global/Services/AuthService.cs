using GestToDo.Api.Models.Global.Entities;
using GestToDo.Api.Models.Global.Mappers;
using GestToDo.Api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tools.Connections.Database;

namespace GestToDo.Api.Models.Global.Services
{
    public class AuthService : IAuthRepository<User>
    {
        private Connection _connection;

        public AuthService(Connection connection)
        {
            _connection = connection;
        }

        public User Login(string email, string passwd)
        {
            Command command = new Command("CSP_AuthUser", true);
            command.AddParameter("Email", email);
            command.AddParameter("Passwd", passwd);

            return _connection.ExecuteReader(command, (dr) => dr.ToUser()).SingleOrDefault();
        }

        public bool Register(User user)
        {
            Command command = new Command("CSP_RegisterUser", true);
            command.AddParameter("LastName", user.LastName);
            command.AddParameter("FirstName", user.FirstName);
            command.AddParameter("Email", user.Email);
            command.AddParameter("Passwd", user.Passwd);

            int rows = _connection.ExecuteNonQuery(command);
            user.Passwd = null;
            return rows == 1;
        }
    }
}
