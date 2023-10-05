using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BlogApplication.Models;
using BlogApplication.Repositories;
using BlogApplication.ViewModels;

namespace BlogApplication.Commands
{
    public class EnterCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private LogInViewModel loginViewModel;
        private UserDapperRepository userRepository;

        public EnterCommand(LogInViewModel loginViewModel, UserDapperRepository userRepository)
        {
            this.loginViewModel = loginViewModel;
            this.userRepository = userRepository;
        }

        public bool CanExecute(object? parameter)
        {
            
            return true;
        }

        public void Execute(object? parameter)
        {
            string email = loginViewModel.Email;
            bool emailExists = userRepository.DoesEmailExist(email);

            if (emailExists)
            {
                
                MainViewModel mainViewModel = new MainViewModel();
                mainViewModel.ActiveViewModel = new MainViewModel();
            }
            else
            {
                return;
                
            }
        }
    }

}

