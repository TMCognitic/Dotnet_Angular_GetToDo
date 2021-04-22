using System;
using System.Collections.Generic;
using System.Text;

namespace GestToDo.Api.Repositories
{
    public interface IToDoRepository<TToDo>
    {
        IEnumerable<TToDo> Get(int userId);
    }
}
