﻿namespace Misana.Network
{
    public interface INetworkClient
    {
        void SendMessage<T>(uint messageType,ref T message)
            where T : struct ;

        bool TryGetMessage<T>(uint messageType,out T? message)
            where T : struct ;
    }
}