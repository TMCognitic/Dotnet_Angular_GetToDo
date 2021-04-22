using System;

namespace GestToDo.Api.Repositories
{
    public interface IAuthRepository<TUser>
    {
        bool Register(TUser user);
        TUser Login(string email, string passwd);
    }
}
