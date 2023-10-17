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
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.SqlClient;
using Dapper;

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


       // private ObservableCollection<User> users;
        public ObservableCollection<User> Users { get; set; }


        private CommandBase? searchingCommand;

       
        public CommandBase SearchingCommand => searchingCommand ??= new CommandBase(
            () =>
            {
                using (IDbConnection dbConnection = new SqlConnection("Server=localhost;Database=BlogApp;Trusted_Connection=True;"))
                {
                    var us = new ObservableCollection<User>(
                        dbConnection.Query<User>("SELECT * FROM Users WHERE Name LIKE @Text", new { Text = "%" + Text + "%" })
                    );
                    foreach (var u in us)
                    {
                        this.Users.Add(u);
                    }
                }
            },
            () => !string.IsNullOrWhiteSpace(Text));





        private CommandBase? backCommand;

        public CommandBase BackCommand => backCommand ??= new CommandBase(
            () =>
            {


                App.Container.GetInstance<MainViewModel>().ActiveViewModel = App.Container.GetInstance<AccaountViewModel>();

            },
            () => true);

        public SearchViewModel()
        {
            Users = new ObservableCollection<User>();
        }
    }
}
