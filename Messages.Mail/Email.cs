using System;
using Messages.Base;

namespace Messages.Mail
{
    public class Email : BaseMessage
    {
        public string To { get; set; }
        public string From { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public string BodyPlain { get; set; }
    }
}
