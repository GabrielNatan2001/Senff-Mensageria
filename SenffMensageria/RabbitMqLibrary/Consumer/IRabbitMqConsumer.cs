using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMqLibrary.Consumer
{
    public interface IRabbitMqConsumer
    {
        void QueueListener(string queue, Action<string> onMessageReceived);
    }
}
