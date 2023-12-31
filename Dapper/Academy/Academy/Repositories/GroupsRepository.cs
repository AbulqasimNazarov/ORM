﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Models;
using Dapper;

namespace Academy.Repositories
{
    public class GroupsRepository
    {
        private readonly SqlConnection sqlConnection;
        private const string connectionString = $"Server=localhost;Database=Academy;Trusted_Connection=True;";


        public GroupsRepository()
        {
            this.sqlConnection = new SqlConnection(connectionString);
            this.sqlConnection.Open();
        }
        public IEnumerable<Groups> GetAll()
        {
            return this.sqlConnection.Query<Groups>(sql: @$"SELECT g.Id, g.[GroupName], g.[StudentsCount], t.TeacherName
                                                         FROM Groups g
                                                         JOIN Teachers t ON g.TeacherId = t.TeacherId");
        }

    }

    
}
