using GE = GestToDo.Api.Models.Global.Entities;
using GS = GestToDo.Api.Models.Global.Services;
using GestToDo.Api.Models.Client.Entities;
using GestToDo.Api.Models.Client.Services;
using GestToDo.Api.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Tools.Connections.Database;


namespace GestToDo.MVC.Infrastructure
{
    public class ResourceLocator : LocatorBase
    {
        #region Singleton
        private static ResourceLocator _instance;

        public static ResourceLocator Instance
        {
            get
            {
                return _instance ?? (_instance = new ResourceLocator());
            }
        }

        private ResourceLocator()
        {

        }
        #endregion

        /// <summary>
        /// Configure les services pour l'injection de dépendances
        /// </summary>
        /// <param name="services">Collection de services à partir de laquelle on va générer notre fournisseur de service</param>
        protected override void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(sp => new Connection(SqlClientFactory.Instance, @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GestToDo;Integrated Security=True;"));
            services.AddSingleton<IAuthRepository<GE.User>, GS.AuthService>();
            services.AddSingleton<IAuthRepository<User>, AuthService>();
            services.AddSingleton<IToDoRepository<GE.ToDo>, GS.ToDoService>();
            services.AddSingleton<IToDoRepository<ToDo>, ToDoService>();
        }        

        public IAuthRepository<User> AuthRepository 
        {
            get { return Container.GetService<IAuthRepository<User>>(); }        
        }

        public IToDoRepository<ToDo> ToDoRepository
        {
            get { return Container.GetService<IToDoRepository<ToDo>>(); }
        }
    }
}