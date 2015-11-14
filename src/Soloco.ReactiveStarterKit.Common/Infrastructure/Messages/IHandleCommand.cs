﻿namespace Soloco.ReactiveStarterKit.Common.Infrastructure.Messages
{
    public interface IHandleCommand<in TMessage> : IHandleMessage<TMessage, CommandResult>
        where TMessage : IMessage<CommandResult>
    {
    }
}