using GE = GestToDo.Api.Models.Global.Entities;
using GS = GestToDo.Api.Models.Global.Services;
using GestToDo.Api.Models.Client.Entities;
using GestToDo.Api.Models.Client.Services;
using GestToDo.Api.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;
using Tools.Connections.Database;

namespace GestToDo.Api.Test
{
    [TestClass]
    public class TestClientAuthService
    {
        private Connection _connection;
        private IAuthRepository<GE.User> _globalAuthRepository;
        private IAuthRepository<User> _authRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            _connection = new Connection(SqlClientFactory.Instance, @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GestToDo;Integrated Security=True;");
            _globalAuthRepository = new GS.AuthService(_connection);
            _authRepository = new AuthService(_globalAuthRepository);
        }

        //[TestCleanup]
        //public void TestCleanup()
        //{
        //    _connection = new Connection(SqlClientFactory.Instance, @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GestToDo;Integrated Security=True;");
        //    Command command = new Command("Truncate Table [User];");
        //    _connection.ExecuteNonQuery(command);
        //}

        [TestMethod]
        public void TestRegister()
        {
            User user = new User("Lorent", "Steve", "steve.lorent@bstorm.be", "test1234=");

            bool result = _authRepository.Register(user);

            Assert.IsTrue(result);
            Assert.IsNull(user.Passwd);
        }
    }
}
