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
        public readonly MyDbContext dbContext;

        //public IUserRepository userRepository;
        public IUserRepository userRepository;


        private CommandBase? deleteCommand;

        public CommandBase DeleteCommand => deleteCommand ??= new CommandBase(
            () =>
            {
                

                
                userRepository.Delete(User.Id);
                App.Container.GetInstance<MainViewModel>().ActiveViewModel = App.Container.GetInstance<RegistrationViewModel>();
                MessageBox.Show("Your Account deleted");

            },
            () => true);




        public FormViewModel(User user)
        {
            this.dbContext = new MyDbContext();
            
            User = user;
            userRepository = new UserEFRepository();




            LoadUserData();
        }


        private void LoadUserData()
        {
            var userEFRepo = new UserEFRepository();

            
            var allUsers = userEFRepo.GetUsers()?.ToList();

            if (allUsers != null)
            {
                var user = allUsers.FirstOrDefault(u => u.Id == User.Id);

                if (user != null)
                {
                   
                    User.Id = user.Id;
                }
                
            }
            else
            {
                MessageBox.Show("Error loading users.");
            }
        }

    }
}
