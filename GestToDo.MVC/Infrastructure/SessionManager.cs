using GestToDo.Api.Models.Client.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestToDo.MVC.Infrastructure
{
    public static class SessionManager
    {
        public static User User 
        {
            get { return (User)HttpContext.Current.Session[nameof(User)]; } 
            set { HttpContext.Current.Session[nameof(User)] = value; }
        }

        public static bool? IsAdmin
        {
            get { return (bool?)HttpContext.Current.Session[nameof(IsAdmin)]; }
            set { HttpContext.Current.Session[nameof(IsAdmin)] = value; }
        }
    }
}