using SimpleMessageProcessing.Library.Abstractions;
using System;

namespace SimpleMessageProcessing.Library.Models.FormatAAggregate {
    public class FormatA : IMessage {
        public string From { get; set; }
        public string To { get; set; }
        public string Type { get; set; }
        public string Text { get; set; }
        public string SendTime { get; set; }
    }
}
