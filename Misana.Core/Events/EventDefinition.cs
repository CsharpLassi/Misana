﻿using System;
using System.IO;
using Misana.Core.Ecs;

namespace Misana.Core.Events
{
    public abstract class EventDefinition
    {
        public abstract void Serialize(Version version,BinaryWriter bw);
        public abstract void Deserialize(Version version, BinaryReader br);
    }
}