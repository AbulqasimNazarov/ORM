using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Models;

namespace BlogApp.Repositories.Base
{
    public interface IUsersRepository
    {
        IEnumerable<User> GetAll();
        void Create(User product);
    }
}
