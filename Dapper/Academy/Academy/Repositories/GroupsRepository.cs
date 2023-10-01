using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Models;

namespace Academy.Repositories
{
    public class GroupsRepository
    {
        private readonly SqlConnection sqlConnection;
        private const string connectionString = $"Server=localhost;Database=Academy;Trusted_Connection=True;";


        public GroupsRepository()
        {
            this.sqlConnection = new SqlConnection();
            this.sqlConnection.Open();
        }
        public IEnumerable<Groups> GetAll()
        {
            throw new NotImplementedException();
        }

    }

    
}
