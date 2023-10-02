using Academy.Commands.Base;
using Academy.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase activeViewModel;

        public ViewModelBase ActiveViewModel
        {
            get => activeViewModel;
            set => base.PropertyChangeMethod(out activeViewModel, value);
        }

        private CommandBase groupsCommand;
        public CommandBase GroupsCommand => this.groupsCommand ??= new CommandBase(
            execute: () => this.ActiveViewModel = App.Container.GetInstance<GroupsViewModel>(),
            canExecute: () => true);

    }



}
