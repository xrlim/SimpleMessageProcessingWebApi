using SimpleMessageProcessing.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMessageProcessing.Library.Abstractions {
    public interface INormalizeService {
        Task<SimpleMessage> NormalizeMessage(IMessage message);
    }
}
