using SimpleMessageProcessing.Library.Abstractions;
using System;
using System.Text.Json.Serialization;

namespace SimpleMessageProcessing.Library.Models.FormatBAggregate {
    public class FormatB : IMessage {
        public FormatBMessage Message { get; set; }
        public FormatBSource Source { get; set; }

        public string TimeStamp { get; set; }
    }
}
