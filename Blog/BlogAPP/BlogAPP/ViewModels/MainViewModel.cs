using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogAPP.Mediators;
using BlogAPP.Mediators.Base;
using BlogAPP.Messages;
using BlogAPP.ViewModels.Base;

namespace BlogAPP.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase activeViewModel;
        private readonly IMessenger messenger;

        public ViewModelBase ActiveViewModel
        {
            get => activeViewModel;
            set => base.PropertyChangeMethod(out activeViewModel, value);
        }

        public MainViewModel(IMessenger messenger)
        {
            this.messenger = messenger;



            this.messenger.Subscribe<Navigation>((message) =>
            {
                if (message is Navigation navigationMessage)
                {
                    this.ActiveViewModel = navigationMessage.DestinationViewModel;
                }
            });
        }
    }
}
