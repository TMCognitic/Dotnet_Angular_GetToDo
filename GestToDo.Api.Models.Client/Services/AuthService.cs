using GE = GestToDo.Api.Models.Global.Entities;
using GestToDo.Api.Models.Client.Entities;
using GestToDo.Api.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

using Tools.Connections.Database;
using GestToDo.Api.Models.Client.Mappers;

namespace GestToDo.Api.Models.Client.Services
{
    public class AuthService : IAuthRepository<User>
    {
        public IAuthRepository<GE.User> _globalAuthRepository;

        public AuthService(IAuthRepository<GE.User> globalAuthRepository)
        {
            _globalAuthRepository = globalAuthRepository;
        }

        public User Login(string email, string passwd)
        {
            return _globalAuthRepository.Login(email, passwd)?.ToClient();
        }

        public bool Register(User user)
        {
            bool result = _globalAuthRepository.Register(user.ToGlobal());
            user.Passwd = null;
            return result;
        }
    }
}
