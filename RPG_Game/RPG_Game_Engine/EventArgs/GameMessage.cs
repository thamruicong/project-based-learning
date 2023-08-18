using System;

namespace Engine.EventArgs
{
    public static class GameMessage
    {
        public static event EventHandler<GameMessageEventArgs>? OnMessageRaised;

        internal static void RaiseMessage(object source, string message)
        {
            OnMessageRaised?.Invoke(source, new GameMessageEventArgs(message));
        }
    }
}