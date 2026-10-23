using System;
using System.Threading;
using Celeste.Everest;

namespace Celeste.Everest.Modules.Settings
{
    public static class EverestSettingsPersistence
    {
        private static int pending;
        public static bool IsSaving => Volatile.Read(ref pending) != 0;
        public static IDisposable BeginSave() => new SaveScope();

        public static void Save(Action save)
        {
            if (save == null) return;
            using (BeginSave()) save();
        }

        private sealed class SaveScope : IDisposable
        {
            private int disposed;

            public SaveScope()
            {
                Interlocked.Increment(ref pending);
            }

            public void Dispose()
            {
                if (Interlocked.Exchange(ref disposed, 1) == 0) Interlocked.Decrement(ref pending);
            }
        }
    }
}
