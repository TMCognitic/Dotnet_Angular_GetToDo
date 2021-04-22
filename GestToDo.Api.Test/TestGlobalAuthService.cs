using GestToDo.Api.Models.Global.Entities;
using GestToDo.Api.Models.Global.Services;
using GestToDo.Api.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;
using Tools.Connections.Database;

namespace GestToDo.Api.Test
{
    [TestClass]
    public class TestGlobalAuthService
    {
        private Connection _connection;

        [TestInitialize]
        public void TestInitialize()
        {
            _connection = new Connection(SqlClientFactory.Instance, @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GestToDo;Integrated Security=True;");
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
            IAuthRepository<User> authRepository = new AuthService(_connection);
            User user = new User() { LastName = "Person", FirstName = "Michael", Email = "michael.person@cognitic.be", Passwd = "test1234=" };

            bool result = authRepository.Register(user);

            Assert.IsTrue(result);
            Assert.IsNull(user.Passwd);
        }
    }
}
