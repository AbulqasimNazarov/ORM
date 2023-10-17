using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BlogAPP.Commands.Base;
using BlogAPP.Mediators.Base;
using BlogAPP.Models;
using BlogAPP.Repositories;
using BlogAPP.ViewModels.Base;

namespace BlogAPP.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly IMessenger messenger;


        private string? loginEmail;

        public string LoginEmail
        {
            get => loginEmail;
            set => base.PropertyChangeMethod(out loginEmail, value);
        }


        private string? loginPassword;

        public string LoginPassword
        {
            get => loginPassword;
            set => base.PropertyChangeMethod(out loginPassword, value);
        }


        private CommandBase? logInCommand;

        public CommandBase LogInCommand => logInCommand ??= new CommandBase(
            () =>
            {
                bool cap = false;
                var uRep = new UserDapperRepository();
                var users = uRep.GetUsers();
                foreach (var user in users)
                {
                    if (this.LoginEmail == user.Email && this.loginPassword == user.Password)
                    {
                        string userImagePath = user.ImagePath.ToString(); 
                        App.Container.GetInstance<MainViewModel>().ActiveViewModel = new AccaountViewModel(user);
                        cap = true;
                    }

                }

                if (cap == false)
                {
                    MessageBox.Show("Incorrect input!");
                    
                }





            },
            () => true);


        

        public LoginViewModel(IMessenger messenger)
        {
            this.messenger = messenger;
            var UserRepo = new UserDapperRepository();
            var genders = UserRepo.GetUsers();
            
        }
    }
}
