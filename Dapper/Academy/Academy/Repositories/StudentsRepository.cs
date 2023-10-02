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
    public class StudentsRepository
    {
        private readonly SqlConnection sqlConnection;
        private const string connectionString = $"Server=localhost;Database=Academy;Trusted_Connection=True;";


        public StudentsRepository()
        {
            this.sqlConnection = new SqlConnection(connectionString);
            this.sqlConnection.Open();
        }
        public IEnumerable<Students> GetAll()
        {
            return this.sqlConnection.Query<Students>(sql: @$"SELECT s.[StudentId], s.[StudentName], t.[TeacherName] 
                                                     FROM Students s
                                                     JOIN Teachers t ON s.TeacherId = t.TeacherId");
        }
    }
}
