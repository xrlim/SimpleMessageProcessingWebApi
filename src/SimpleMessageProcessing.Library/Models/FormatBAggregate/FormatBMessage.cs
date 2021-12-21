using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMessageProcessing.Library.Models.FormatBAggregate {
    public class FormatBMessage {
        public string Type { get; set; }
        public string Id { get; set; }
        public string Text { get; set; }
    }
}
