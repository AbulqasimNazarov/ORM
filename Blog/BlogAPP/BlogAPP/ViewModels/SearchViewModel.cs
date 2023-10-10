using BlogAPP.Commands.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BlogAPP.DBContext;
using BlogAPP.Models;
using BlogAPP.ViewModels.Base;

namespace BlogAPP.ViewModels
{
    public class SearchViewModel : ViewModelBase
    {

        private string? text;
        public string Text
        {
            get { return text; }
            set { base.PropertyChangeMethod(out text, value); }
        }


        private ObservableCollection<User> users;
        public ObservableCollection<User> Users
        {
            get { return users; }
            set { base.PropertyChangeMethod(out users, value); }
        }


        private CommandBase? searchingCommand;

       
        public CommandBase SearchingCommand => searchingCommand ??= new CommandBase(
            () =>
            {
                using (var dbContext = new MyDbContext()) 
                {
                    Users = new ObservableCollection<User>(
                        dbContext.Users.Where(u => u.Name.Contains(Text, StringComparison.OrdinalIgnoreCase))
                            .ToList());
                }
            },
            () => !string.IsNullOrWhiteSpace(Text));

        public SearchViewModel()
        {
            Users = new ObservableCollection<User>();
        }
    }
}
