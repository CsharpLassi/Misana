using System;

namespace Misana.Core.Ecs
{
    public class SystemConfigurationAttribute : Attribute
    {
        public string[] Replaces;
        public string[] Before;
        public string[] After;
        public string[] ConcurrentlyWith;
        public SystemConfigurationAttribute() { }
    }
}