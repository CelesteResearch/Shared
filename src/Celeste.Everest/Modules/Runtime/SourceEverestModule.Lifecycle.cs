using System;
using System.Collections.Generic;
using Celeste.Everest.Content.Maps.Processing;
using Celeste.Everest.Diagnostics.Logging;

namespace Celeste.Everest.Modules.Runtime
{
    public abstract partial class SourceEverestModule
    {
        /// <summary>
        ///     Perform any initializing actions after all mods have been loaded.
        ///     Do not depend on any specific order in which the mods get initialized.
        /// </summary>
        public abstract void Load();

        /// <summary>
        ///     Perform any initializing actions after Celeste.Initialize has been called.
        ///     Do not depend on any specific order in which the mods get initialized.
        /// </summary>
        public virtual void Initialize()
        {
        }

        /// <summary>
        ///     Perform any content loading actions after Celeste.LoadContent has been called.
        /// </summary>
        [Obsolete("Override LoadContent(bool firstLoad) instead.")]
        public virtual void LoadContent()
        {
        }

        /// <summary>
        ///     Perform any content loading actions after Celeste.LoadContent has been called.
        /// </summary>
        /// <param name="firstLoad">Is this the first load?</param>
        public virtual void LoadContent(bool firstLoad)
        {
#pragma warning disable CS0618 // Preserve original legacy module override dispatch.
            LoadContent();
#pragma warning restore CS0618
        }

        /// <summary>
        ///     Unload any unmanaged resources allocated by the mod (f.e. textures) and
        ///     undo any changes performed by the mod.
        /// </summary>
        public abstract void Unload();

        /// <summary>
        ///     Parse the current command-line argument and any follow-ups.
        /// </summary>
        /// <param name="arg">The current command line argument.</param>
        /// <param name="args">Any further arguments the mod may want to dequeue and parse.</param>
        /// <returns>True if the argument "belongs" to the mod, false otherwise.</returns>
        public virtual bool ParseArg(string arg, Queue<string> args)
        {
            return false;
        }

        /// <summary>
        ///     Create and add any map data processors to the given context, if any are needed.
        /// </summary>
        /// <param name="context">The context to add the processors to.</param>
        public virtual void PrepareMapDataProcessors(
            EverestMapDataFixup context)
        {
        }

        public virtual void LogRegistration()
        {
            ((IEverestLoggerProcessEnvironment)SourceEngine).Logger.LogModuleSourceSite12(this);
        }

        public virtual void LogUnregistration()
        {
            ((IEverestLoggerProcessEnvironment)SourceEngine).Logger.LogModuleSourceSite13(this);
        }
    }
}
