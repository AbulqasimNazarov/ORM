using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApplication.ViewModels.Base;

namespace BlogApplication.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel activeViewModel;

        public BaseViewModel ActiveViewModel
        {
            get => activeViewModel;
            set => base.PropertyChangeMethod(out activeViewModel, value);
        }

    }
}
