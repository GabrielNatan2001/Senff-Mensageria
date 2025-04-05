using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMqLibrary.Enum
{
    public enum EExchangeType
    {
        FANOUT,
        HEADERS,
        TOPIC,
        DIRECT
    }
}
