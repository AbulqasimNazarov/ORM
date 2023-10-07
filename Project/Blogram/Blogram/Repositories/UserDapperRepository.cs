using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blogram.Models;
using Dapper;

namespace Blogram.Repositories
{
    public class UserDapperRepository
    {
        private readonly SqlConnection sqlConnection;
        private const string connectionString = $"Server=localhost;Database=Blogram;Trusted_Connection=True;";
        public UserDapperRepository()
        {
            this.sqlConnection = new SqlConnection(connectionString);
            this.sqlConnection.Open();
        }

        public IEnumerable<User> GetUsers()
        {
            return this.sqlConnection.Query<User>(@$"select *from Users");
        }

        public void CreateUser(User user)
        {
            var query = $@"insert into Users([Name], [Surname], [Email], [Password])
                            values(@Name, @Surname, @Email, @Password)";

            int AffectedRowsCount = this.sqlConnection.Execute(query, user);

            if (AffectedRowsCount <= 0)
            {
                throw new Exception("Insert Error!");
            }
        }
    }
}
