using SimpleMessageProcessing.Library.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMessageProcessing.Library.Models.FormatCAggregate {
    public class FormatC : IMessage {
        public string Msisdn { get; set; }
        public FormatCMessage Message { get; set; }
    }
}
