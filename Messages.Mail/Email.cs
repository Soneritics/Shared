using System;
using Messages.Base;

namespace Messages.Mail
{
    public class Email : BaseMessage
    {
        public string To { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
