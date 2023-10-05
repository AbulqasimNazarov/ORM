using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApplication.Commands;
using BlogApplication.Repositories;
using BlogApplication.ViewModels.Base;

namespace BlogApplication.ViewModels
{
    public class LogInViewModel : BaseViewModel
    {
        public string? email;
        public string? Email
        {
            get => email;
            set => base.PropertyChangeMethod(out email, value);
        }

        public EnterCommand EnterCommand { get; set; }

        public LogInViewModel(UserDapperRepository userRepository)
        {
            EnterCommand = new EnterCommand(this, userRepository);
        }
    }
}
