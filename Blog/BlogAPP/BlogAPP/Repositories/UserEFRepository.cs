using BlogAPP.DBContext;
using BlogAPP.Models;
using BlogAPP.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAPP.Repositories
{
    public class UserEFRepository : IUserRepository
    {
        private readonly MyDbContext dbContext;

        //public UserEFRepository(MyDbContext dbContext) => this.dbContext = dbContext;
        public UserEFRepository() => this.dbContext = new MyDbContext();

        public void CreateUser(User user)
        {
            var created = this.dbContext.Users.Add(user);
            this.dbContext.SaveChanges();

            
        }

        public void Delete(int id)
        {
            var userToDelete = this.dbContext.Users.FirstOrDefault(u => u.Id == id);

            if (userToDelete != null)
            {
                this.dbContext.Remove(userToDelete);
                this.dbContext.SaveChanges();
            }
        }

        public IEnumerable<User>? GetUsers()
        {
            return this.dbContext.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return this.dbContext.Users.FirstOrDefault(u => u.Id == id);
        }

        public void Update(int id, User user)
        {
            if (user.Id == default)
                user.Id = id;

            this.dbContext.Users.Update(user);
            this.dbContext.SaveChanges();
        }
    }
}
