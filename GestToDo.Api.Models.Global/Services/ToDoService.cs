using GestToDo.Api.Models.Global.Entities;
using GestToDo.Api.Models.Global.Mappers;
using GestToDo.Api.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Tools.Connections.Database;

namespace GestToDo.Api.Models.Global.Services
{
    public class ToDoService : IToDoRepository<ToDo>
    {
        private Connection _connection;

        public ToDoService(Connection connection)
        {
            _connection = connection;
        }

        public IEnumerable<ToDo> Get(int userId)
        {
            Command command = new Command("Select Id, Title, [Description], Ended, UserId, CreatedDate FROM ToDo Where UserId = @UserId");
            command.AddParameter("UserId", userId);
            return _connection.ExecuteReader(command, (dr) => dr.ToToDo());
        }
    }
}
