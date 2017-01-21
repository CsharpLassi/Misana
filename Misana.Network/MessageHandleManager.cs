﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using Misana.Network.Messages;

namespace Misana.Network
{
    public static class MessageHandleManager
    {
        private static int maxIndex = 0;

        private static Dictionary<Type,MessageIdPair> SystemPairs = new Dictionary<Type, MessageIdPair>();



        static MessageHandleManager()
        {
            RegisterType<GetMessageIDMessageRequest>();
            RegisterType<GetMessageIDMessageResponse>();
        }

        public static int RegisterType<T>()
            where T : struct
        {
            return RegisterType(typeof(T));
        }

        public static int RegisterType(Type type)
        {

            if (SystemPairs.ContainsKey(type))
                throw new ArgumentException("SystemId already");

            var systemId =  Interlocked.Increment(ref maxIndex) -1;

            SystemPairs.Add(type, new MessageIdPair(systemId,type));


            return systemId;
        }


        public static int RegisterType<T>(int index)
            where T : struct
        {
            return RegisterType(typeof(T),index);
        }

        public static int RegisterType(Type type,int index)
        {

            if (SystemPairs.ContainsKey(type))
                throw new ArgumentException("SystemId already");

            SystemPairs.Add(type, new MessageIdPair(index,type));

            if (maxIndex < index)
                maxIndex = index;

            return index;
        }

        public static int? GetId<T>()
            where T : struct
        {
            return GetId(typeof(T));
        }

        public static int? GetId(Type type)
        {
            if (SystemPairs.ContainsKey(type))
            {
                return SystemPairs[type].SystemId;
            }

            return null;
        }

        internal static MessageHandle[] CreateHandleArray()
        {
            MessageHandle[] array = new MessageHandle[SystemPairs.Count];
            int i = 0;
            foreach (var pair in SystemPairs)
            {
                array[i++] = new VirtualMessageHandle(pair.Value.MessageType,pair.Value.SystemId);
            }

            return array;
        }
    }
}