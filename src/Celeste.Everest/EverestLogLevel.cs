using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Celeste.Simulation;
using YamlDotNet.Serialization;

namespace Celeste.Everest
{
    public enum EverestLogLevel
    {
        Verbose,
        Debug,
        Info,
        Warn,
        Error
    }
}
