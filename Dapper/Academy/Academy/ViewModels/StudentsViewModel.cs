using Academy.Models;
using Academy.Repositories;
using Academy.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.ViewModels
{
    public class StudentsViewModel : ViewModelBase
    {
        public StudentsRepository repository;
        public ObservableCollection<Students> StudentsList { get; set; }

        public StudentsViewModel(StudentsRepository repository)
        {
            this.repository = repository;
            this.StudentsList = new ObservableCollection<Students>();


            this.RefreshAllProducts();
        }


        private void RefreshAllProducts()
        {
            this.StudentsList.Clear();

            var result = this.repository.GetAll();

            foreach (var item in result)
            {
                this.StudentsList.Add(item);
            }
        }
    }
}
