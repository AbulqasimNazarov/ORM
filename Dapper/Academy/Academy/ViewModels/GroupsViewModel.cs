using Academy.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Models;
using Academy.Repositories;

namespace Academy.ViewModels
{
    public class GroupsViewModel : ViewModelBase
    {
        public GroupsRepository repository;
        public ObservableCollection<Groups> GroupsList { get; set; }

        public GroupsViewModel(GroupsRepository repository)
        {
            this.repository = repository;
            this.GroupsList = new ObservableCollection<Groups>();


            this.RefreshAllProducts();
        }


        private void RefreshAllProducts()
        {
            this.GroupsList.Clear();

            var result = this.repository.GetAll();

            foreach (var item in result)
            {
                this.GroupsList.Add(item);
            }
        }

    }
}
