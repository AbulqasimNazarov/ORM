using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BlogApplication.Models;
using Dapper;

namespace BlogApplication.Repositories
{
    public class UserDapperRepository
    {
        private readonly SqlConnection sqlConnection;
        private const string connectionString = $"Server=localhost;Database=BlogApp;Trusted_Connection=True;";


        public UserDapperRepository()
        {
            this.sqlConnection = new SqlConnection(connectionString);
            this.sqlConnection.Open();
        }
        public IEnumerable<User> GetAll()
        {
            return this.sqlConnection.Query<User>(sql: @$"select * from Users");
        }


        public void Create(User user)
        {
            string query = $@"insert into Users([Name], [Email], [Password])
                            values(@Name, @Email, @Password)";

            int affectedRowsCount = this.sqlConnection.Execute(query, param: user);

            if (affectedRowsCount <= 0)
                throw new Exception("Insert error!");
        }


        public bool DoesEmailExist(string email)
        {
            // Выполните запрос к базе данных для проверки существования Email.
            var userWithEmail = this.sqlConnection.QuerySingleOrDefault<User>(sql: "SELECT * FROM Users WHERE Email = @Email", new { Email = email });

            return userWithEmail != null;
        }
    }
}
