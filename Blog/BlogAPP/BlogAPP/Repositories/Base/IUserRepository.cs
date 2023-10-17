using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogAPP.Models;

namespace BlogAPP.Repositories.Base
{
    public interface IUserRepository
    {
        public IEnumerable<User> GetUsers();
        void CreateUser(User product);
        public User GetUserById(string? email);
        public void Update(int id, User user);
        public void Delete(int id);
    }
}
