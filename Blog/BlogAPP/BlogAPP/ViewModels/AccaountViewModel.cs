using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using BlogAPP.Commands.Base;
using BlogAPP.Mediators.Base;
using BlogAPP.Models;
using BlogAPP.Repositories;
using BlogAPP.ViewModels.Base;
using Microsoft.Win32;

namespace BlogAPP.ViewModels
{
    public class AccaountViewModel : ViewModelBase
    {
        private readonly IMessenger messenger;

        private BitmapImage? imagePathFromBase;
        public BitmapImage ImagePathFromBase
        {
            get => imagePathFromBase;
            set => base.PropertyChangeMethod(out imagePathFromBase, value);
        }


        private string? profName;
        public string ProfName
        {
            get => profName;
            set => base.PropertyChangeMethod(out profName, value);
        }



        private string? profSurname;
        public string ProfSurname
        {
            get => profSurname;
            set => base.PropertyChangeMethod(out profSurname, value);
        }





        private CommandBase? clickAccount;

        public CommandBase ClickAccount => clickAccount ??= new CommandBase(
            () =>
            {
                App.Container.GetInstance<MainViewModel>().ActiveViewModel = new FormViewModel(currentUser);

            },
            () => true);



        private User? currentUser;

        public AccaountViewModel(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            this.currentUser = user;
           
            LoadUserData();
        }

        private void LoadUserData()
        {
           
            var userDapperRepo = new UserDapperRepository();

            var user = userDapperRepo.GetUserById(currentUser?.Id);

           
            if (user != null)
            {
                
                this.ImagePathFromBase = new BitmapImage(new Uri(user.ImagePath, UriKind.RelativeOrAbsolute));
                this.profName = user.Name;
                this.profSurname = user.Surname;
                
                


            }
        }


    }
}
