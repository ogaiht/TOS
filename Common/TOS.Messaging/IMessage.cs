using System;

namespace TOS.Messaging
{
    public interface IMessage
    {
        BinaryData Body { get; }
        TimeSpan TimeToLive { get; set; }
    }
}
