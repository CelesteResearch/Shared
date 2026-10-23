using System;
using System.Collections.Generic;

namespace Celeste.Everest.Content.Registry
{
    public sealed partial class EverestContentRegistry : IDisposable
    {
        private bool disposed;

        public void Dispose()
        {
            if (disposed) return;
            disposed = true;
            List<Exception> failures = null;
            foreach (var source in Mods)
            {
                try
                {
                    source.Dispose();
                }
                catch (Exception error)
                {
                    (failures ??= new List<Exception>()).Add(error);
                }
            }

            Mods.Clear();
            Map.Clear();
            if (failures != null)
                throw new AggregateException("Everest content source cleanup failed.", failures);
        }
    }
}
