using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Models;
using BlogApp.Repositories.Base;
using Dapper;

namespace BlogApp.Repositories
{
    public class UserDapperRepository : IUsersRepository
    {

        private const string connectionString = $"Server=localhost;Database=Academy;Trusted_Connection=True;";
        private readonly SqlConnection sqlConnection;

        public UserDapperRepository()
        {
            this.sqlConnection = new SqlConnection(connectionString);
            this.sqlConnection.Open();
        }

        public IEnumerable<User> GetAll()
        {
            
            return this.sqlConnection.Query<User>(sql: "select * from Users");
        }

        public void Create(User user)
        {
            //string query = $@"insert into Users([Name], [Price], [Status])
            //                values(@Name, @Price, @Status)";

            //int affectedRowsCount = this.sqlConnection.Execute(query, param: user);

            //if (affectedRowsCount <= 0)
            //    throw new Exception("Insert error!");
        }
    }
}
