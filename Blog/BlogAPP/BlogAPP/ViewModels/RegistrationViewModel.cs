using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogAPP.Commands.Base;
using BlogAPP.Models;
using BlogAPP.Repositories;
using BlogAPP.ViewModels.Base;

namespace BlogAPP.ViewModels
{
    public class RegistrationViewModel : ViewModelBase
    {

        private string name;

        public string Name
        {
            get => name;
            set => base.PropertyChangeMethod(out name, value);
        }

        private string surname;

        public string Surname
        {
            get => surname;
            set => base.PropertyChangeMethod(out surname, value);
        }

        
        


        private string email;

        public string Email
        {
            get => email;
            set => base.PropertyChangeMethod(out email, value);
        }

        private string password;

        public string Password
        {
            get => password;
            set => base.PropertyChangeMethod(out password, value);
        }

        private Gender selectedGender;
        public Gender SelectedGender
        {
            get { return selectedGender; }
            set{base.PropertyChangeMethod(out selectedGender, value);}
        }


        
        private CommandBase? userCreateCommand;

        public CommandBase UserCreateCommand
        {
            get
            {
                if (userCreateCommand == null)
                {
                    userCreateCommand = new CommandBase(() =>
                        {
                            var uRep = new UserDapperRepository();
                            uRep.CreateUser(new User()
                            {
                                Name = this.Name,
                                Surname = this.Surname,
                                Email = this.Email,
                                Password = this.Password,
                                Gender = this.selectedGender?.Id
                            });
                        }, 
                        () => true);
                }
                return userCreateCommand;
            }
            
        }



        public ObservableCollection<Gender> Genders { get; set; } 

        public RegistrationViewModel()
        {
            var usersGenderRepository = new UserGenderDapperRepository();
            var genders = usersGenderRepository.GetGenders();
            this.Genders = new ObservableCollection<Gender>(genders);

        }

    }
}
