namespace SimpleMessageProcessing.Library.Models {
    public class SimpleMessage {
        public int Id { get; set; }
        /// <summary>
        /// Format B message > userId <br/>
        /// Format C - msisdn
        /// </summary>
        public string From { get; set; }
        public string To { get; set; }
        /// <summary>
        /// Format B - message > type
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Format B - message > text <br/>
        /// Format C - message > msgText
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Format B - timestamp <br/>
        /// Format C - message > msgTime
        /// </summary>
        public string SendTime { get; set; }


        // Format B Unique Field
        public string  MessageId { get; set; }
        public string SourceType { get; set; }

        public string Format { get; set; }



    }
}
