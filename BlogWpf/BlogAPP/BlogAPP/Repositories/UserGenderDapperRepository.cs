using BlogAPP.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogAPP.Repositories.Base;

namespace BlogAPP.Repositories
{
    public class UserGenderDapperRepository : IGenderRepository
    {
        private readonly SqlConnection sqlConnection;
        private const string connectionString = $"Server=localhost;Database=BlogApp;Trusted_Connection=True;";

        public UserGenderDapperRepository()
        {
            this.sqlConnection = new SqlConnection(connectionString);
            this.sqlConnection.Open();
        }

        public IEnumerable<Gender> GetGenders()
        {
            return this.sqlConnection.Query<Gender>(@$"select * from Genders");

        }
    }
}
