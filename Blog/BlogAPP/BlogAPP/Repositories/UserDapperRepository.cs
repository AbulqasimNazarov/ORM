﻿using BlogAPP.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using BlogAPP.Repositories.Base;
using Dapper;
using System.Data;

namespace BlogAPP.Repositories
{
    public class UserDapperRepository : IUserRepository
    {
        private readonly SqlConnection sqlConnection;
        private const string connectionString = $"Server=localhost;Database=BlogApp;Trusted_Connection=True;";
        public UserDapperRepository()
        {
            this.sqlConnection = new SqlConnection(connectionString);
            this.sqlConnection.Open();
        }

        public IEnumerable<User> GetUsers()
        {
            return this.sqlConnection.Query<User>(@$"select * from Users");
        }

       


        public User GetUserById(string? email)
        {
            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
             
                string query = "SELECT * FROM Users WHERE email = @Email";
                User user = dbConnection.QueryFirstOrDefault<User>(query, new { Email = email });

                return user;
            }
        }

        public void CreateUser(User user)
        {
            try
            {
                if (user.Password.Length < 8 && !user.Password.Any(char.IsDigit) && !user.Password.Any(char.IsLetter))
                {
                    throw new Exception("Password must be at least 8 characters long and contain at least one letter and one digit.");
                }

                var query = $@"insert into Users([Name], [Surname], [Email], [Password], [ImagePath], [Gender])
                            values(@Name, @Surname, @Email, @Password, @ImagePath, @Gender)";

                int AffectedRowsCount = this.sqlConnection.Execute(query, user);

                if (AffectedRowsCount <= 0)
                {
                    throw new Exception("Insert Error!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        

        public void Update(int id, User user)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
