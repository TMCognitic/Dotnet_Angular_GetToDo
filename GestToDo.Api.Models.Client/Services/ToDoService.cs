using GE = GestToDo.Api.Models.Global.Entities;
using GestToDo.Api.Models.Client.Entities;
using GestToDo.Api.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using GestToDo.Api.Models.Client.Mappers;

namespace GestToDo.Api.Models.Client.Services
{
    public class ToDoService : IToDoRepository<ToDo>
    {
        private readonly IToDoRepository<GE.ToDo> _globalRepository;

        public ToDoService(IToDoRepository<GE.ToDo> globalRepository)
        {
            _globalRepository = globalRepository;
        }

        public IEnumerable<ToDo> Get(int userId)
        {
            return _globalRepository.Get(userId).Select(t => t.ToClient());
        }
    }
}
