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
    public class TeachersViewModel : ViewModelBase
    {
        public TeacherRepository repository;
        public ObservableCollection<Teachers> TeacherList { get; set; }

        public TeachersViewModel(TeacherRepository repository)
        {
            this.repository = repository;
            this.TeacherList = new ObservableCollection<Teachers>();


            this.RefreshAllProducts();
        }


        private void RefreshAllProducts()
        {
            this.TeacherList.Clear();

            var result = this.repository.GetAll();

            foreach (var item in result)
            {
                this.TeacherList.Add(item);
            }   
        }
    }
}
