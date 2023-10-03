using OrmModuleProject.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrmModuleProject.Commands.CommandBase;

namespace OrmModuleProject.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase activeViewModel;

        public ViewModelBase ActiveViewModel
        {
            get => activeViewModel;
            set => base.PropertyChangeMethod(out activeViewModel, value);
        }

        private CommandBase startCommand;
        public CommandBase StartCommand => this.startCommand ??= new CommandBase(
            execute: () => this.ActiveViewModel = App.Container.GetInstance<StartAppViewModel>(),
            canExecute: () => true);

    }
}
