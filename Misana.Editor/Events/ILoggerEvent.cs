﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misana.Editor.Events
{
    public interface ILoggerEvent
    {
        string Name { get; set; }
        string Description { get; set; }
    }
}
