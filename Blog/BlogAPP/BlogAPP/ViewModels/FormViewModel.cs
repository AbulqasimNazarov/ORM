using BlogAPP.Commands.Base;
using BlogAPP.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using BlogAPP.Models;
using Microsoft.Win32;
using BlogAPP.DBContext;
using BlogAPP.Repositories.Base;
using BlogAPP.Repositories;
using System.Windows;

namespace BlogAPP.ViewModels
{
    public class FormViewModel : ViewModelBase
    {
        public User User { get; set; }


        private string? email;

        public string Email
        {
            get => email;
            set => base.PropertyChangeMethod(out email, value);
        }

        private CommandBase? deleteCommand;

        public CommandBase DeleteCommand => deleteCommand ??= new CommandBase(
            () =>
            {
                var context = new MyDbContext();

                // Получить пользователя по его идентификатору
                var userToDelete = context.Users.FirstOrDefault(u => u.Id == User.Id);

                if (userToDelete != null)
                {
                    // Удалить пользователя
                    context.Users.Remove(userToDelete);
                    context.SaveChanges();
                }
            },
            () => true);




        public FormViewModel(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            User = user;

            LoadUserData();
        }


        private void LoadUserData()
        {
            var userEFRepo = new UserEFRepository();

            
            
            
            var allUsers = userEFRepo.GetUsers().ToList(); 

            
            var user = allUsers.FirstOrDefault(u => u.Id == User.Id);

            if (user != null)
            {
                
                this.User.Id = user.Id;
            }
            else
            {
                
                MessageBox.Show("User doesnt founded.");
            }
        }
    }
}
