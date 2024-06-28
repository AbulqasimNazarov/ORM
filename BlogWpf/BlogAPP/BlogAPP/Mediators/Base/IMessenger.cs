using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogAPP.Messages.Base;

namespace BlogAPP.Mediators.Base
{
    public interface IMessenger
    {
        void Subscribe<T>(Action<IMessage> action) where T : IMessage;
        void Send<T>(T message) where T : IMessage;
    }
}
