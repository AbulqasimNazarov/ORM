using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogAPP.Models;

namespace BlogAPP.Repositories.Base
{
    interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        void CreateUser(User product);
    }
}
