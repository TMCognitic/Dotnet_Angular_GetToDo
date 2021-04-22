using GestToDo.Api.Models.Global.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace GestToDo.Api.Models.Global.Mappers
{
    internal static class DataRecordExtensions
    {
        internal static User ToUser(this IDataRecord dataRecord)
        {
            return new User() { Id = (int)dataRecord["Id"], LastName = (string)dataRecord["LastName"], FirstName = (string)dataRecord["FirstName"], Email = (string)dataRecord["Email"] };
        }

        internal static ToDo ToToDo(this IDataRecord dataRecord)
        {
            return new ToDo() { Id = (int)dataRecord["Id"], Title = (string)dataRecord["Title"], Description = (string)dataRecord["Description"], Ended = (bool)dataRecord["Ended"], UserId = (int)dataRecord["UserId"], CreationDate = (DateTime)dataRecord["CreatedDate"] };
        }
    }
}
