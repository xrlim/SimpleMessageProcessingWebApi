using SimpleMessageProcessing.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMessageProcessing.Library.Abstractions {
    public interface ISimpleMessageRepositories {
        Task<bool> SaveSimpleMessage(SimpleMessage simpleMessage);
    }
}
