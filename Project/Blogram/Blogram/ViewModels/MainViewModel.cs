using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blogram.ViewModels.Base;

namespace Blogram.ViewModels
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
