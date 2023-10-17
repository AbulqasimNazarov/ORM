using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using BlogAPP.ChangePicture;
using BlogAPP.Commands.Base;
using BlogAPP.Mediators.Base;
using BlogAPP.Messages;
using BlogAPP.Models;
using BlogAPP.Repositories;
using BlogAPP.ViewModels.Base;
using Microsoft.Win32;

namespace BlogAPP.ViewModels
{

    public class UserRegistrationMessage
    {
        public User User { get; set; }

        public UserRegistrationMessage(User user)
        {
            User = user;
        }
    }

    public class RegistrationViewModel : ViewModelBase
    {

        private readonly IMessenger _messenger;



        private string? name;

        public string Name
        {
            get => name;
            set => base.PropertyChangeMethod(out name, value);
        }

        private string? surname;

        public string Surname
        {
            get => surname;
            set => base.PropertyChangeMethod(out surname, value);
        }

        



        private string? email;

        public string Email
        {
            get => email;
            set => base.PropertyChangeMethod(out email, value);
        }

        private string? password;

        public string Password
        {
            get => password;
            set => base.PropertyChangeMethod(out password, value);
        }


        private BitmapImage? imagePath = new BitmapImage();

        public BitmapImage ImagePath
        {
            get => imagePath;
            set => base.PropertyChangeMethod(out imagePath, value);
        }

        private Gender? selectedGender;
        public Gender SelectedGender
        {
            get { return selectedGender; }
            set{base.PropertyChangeMethod(out selectedGender, value);}
        }

        private CommandBase? loginCommand;
        
        public CommandBase LoginCommand => loginCommand ??= new CommandBase(
            () =>
            {
                

                App.Container.GetInstance<MainViewModel>().ActiveViewModel = App.Container.GetInstance<LoginViewModel>();



            },
            () => true);

        //public BitmapImage bitmapImage = new BitmapImage();


        private CommandBase? pictureDownloadCommand;

        public CommandBase PictureDownloadCommand => pictureDownloadCommand ??= new CommandBase(
            () =>
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All Files|*.*";

                if (openFileDialog.ShowDialog() == true)
                {

                    this.ImagePath = new BitmapImage(new Uri(openFileDialog.FileName, UriKind.RelativeOrAbsolute));
                }
            },
            () => true);


            //private User? registeredUser;

        private CommandBase? userCreateCommand;
        public CommandBase UserCreateCommand => userCreateCommand ??= new CommandBase(
            () => 
            {
                try
                {

                    if (this.Name == null || this.Email == null || this.Password == null
                        || this.Name == string.Empty || this.Surname == string.Empty || this.Email == string.Empty
                        || this.Password == string.Empty)
                    {
                        throw new Exception("Empty boxes!");
                    }

                    
                    
                    var uRep = new UserDapperRepository();
                    var u = new User() {
                        
                        Name = this.Name,
                        Surname = this.Surname,
                        Email = this.Email,
                        Password = this.Password,
                        ImagePath = this.ImagePath.ToString(),
                        Gender = this.selectedGender?.Id
                    };
                    uRep.CreateUser(u);
                   // var userDapperRepo = new UserDapperRepository();

                    var user = uRep.GetUserById(u.Email);
                    var registeredUser = new UserRegistrationMessage(user);

                    //this._messenger.Send(new Navigation(pp.Container.GetInstance<use>())));

                    this._messenger.Send(new Navigation(App.Container.GetInstance<AccaountViewModel>()));
                    //this._messenger.Send(new Navigation(App.Container.GetInstance<AccaountViewModel>()));

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                
                this.Name = string.Empty;
                this.Surname = string.Empty;
                this.Email = string.Empty;
                this.Password = string.Empty;
                




            }, 
                        () => true);
                
        


        public ObservableCollection<Gender> Genders { get; set; } 

        public RegistrationViewModel(IMessenger messenger)
        {
          
            this._messenger = messenger;
            var usersGenderRepository = new UserGenderDapperRepository();
            var genders = usersGenderRepository.GetGenders();
            this.Genders = new ObservableCollection<Gender>(genders);

        }

    }
}
