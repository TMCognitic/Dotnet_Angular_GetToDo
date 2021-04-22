using GE = GestToDo.Api.Models.Global.Entities;
using GestToDo.Api.Models.Client.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestToDo.Api.Models.Client.Mappers
{
    internal static class Mappers
    {
        public static GE.User ToGlobal(this User entity)
        {
            return new GE.User()
            {
                Id = entity.Id,
                LastName = entity.LastName,
                FirstName = entity.FirstName,
                Email = entity.Email,
                Passwd = entity.Passwd
            };
        }

        public static User ToClient(this GE.User entity)
        {
            return new User(entity.Id, entity.LastName, entity.FirstName, entity.Email);
        }

        public static GE.ToDo ToGlobal(this ToDo entity)
        {
            return new GE.ToDo()
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                Ended = entity.Ended,
                UserId = entity.UserId
            };
        }

        public static ToDo ToClient(this GE.ToDo entity)
        {
            return new ToDo(entity.Id, entity.Title, entity.Description, entity.Ended, entity.UserId);
        }
    }
}
