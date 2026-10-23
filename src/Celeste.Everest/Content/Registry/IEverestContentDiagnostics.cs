using System;

namespace Celeste.Everest.Content.Registry
{
    public interface IEverestContentDiagnostics
    {
        void Warning(string category, string message);
        void Verbose(string category, string message);
        void Error(string category, string message);
        void Detailed(Exception exception);
    }
}
