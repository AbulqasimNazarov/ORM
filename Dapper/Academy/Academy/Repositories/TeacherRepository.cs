using Academy.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Academy.Repositories
{
    public class TeacherRepository
    {

        private readonly SqlConnection sqlConnection;
        private const string connectionString = $"Server=localhost;Database=Academy;Trusted_Connection=True;";


        public TeacherRepository()
        {
            this.sqlConnection = new SqlConnection(connectionString);
            this.sqlConnection.Open();
        }
        public IEnumerable<Teachers> GetAll()
        {
            return this.sqlConnection.Query<Teachers>(sql: @$"SELECT t.*, g.[GroupName] 
                                                     FROM Teachers t
                                                     JOIN Groups g ON g.TeacherId = t.TeacherId");
        }
    }
}
