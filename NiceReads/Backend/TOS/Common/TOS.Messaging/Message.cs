using System;

namespace TOS.Messaging
{
    public class Message : IMessage
    {
        public Message(BinaryData body)
        {
            Body = body;
        }

        public Message(string body)
        {
            Body = BinaryData.FromString(body);
        }

        public BinaryData Body { get; set; }
        public TimeSpan TimeToLive { get; set; }
    }
}
