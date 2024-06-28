using BlogAPP.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogAPP.Messages.Base;

namespace BlogAPP.Messages
{
    public class Navigation : IMessage
    {
        public readonly ViewModelBase DestinationViewModel;

        public Navigation(ViewModelBase destinationViewModel)
        {
            this.DestinationViewModel = destinationViewModel;
        }
    }
}
