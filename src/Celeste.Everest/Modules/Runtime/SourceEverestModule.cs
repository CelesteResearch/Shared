using Celeste.Input.Devices.Keyboard;
using Celeste.Input.Devices.GamePads;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Celeste.Core.Scheduling;
using Celeste.Everest.Modules.Settings;
using Celeste.Everest.Modules.Persistence;
using Celeste.Everest.Content.Serialization;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Everest.IO;
using Celeste.Game.Save.IO;
using Celeste.Game.Save.Runtime;
using Celeste.Everest.Input;
using Celeste.Everest.Input.Bindings;
using Celeste.Input.Gameplay;
using Keys = Celeste.Input.Devices.Keyboard.SourceKeys;
using Buttons = Celeste.Input.Devices.GamePads.SourceGamePadButtonFlags;

namespace Celeste.Everest.Modules.Runtime
{
    public abstract partial class SourceEverestModule
    {
        protected readonly ISourceEngineContext SourceEngine;

        private bool ForceSaveDataAsync;

        internal int ForceSaveDataFlush;

        private Type _PrevSettingsType;

        private PropertyInfo[] _PrevSettingsProps;

        /// <summary>
        ///        Used by Everest itself to store any module metadata.
        ///
        ///        The metadata is usually parsed from meta.yaml in the archive.
        ///
        ///        You can override this property to provide dynamic metadata at runtime.
        ///        Doing so isn't advised though unless you absolutely know what you're doing.
        ///        Note that this doesn't affect mod loading.
        ///        </summary>
        public virtual EverestModuleMetadata Metadata { get; set; }

        /// <summary>
        ///       The type used for the settings object. Used for serialization, among other things.
        ///       </summary>
        public virtual Type SettingsType => null;

        /// <summary>
        ///       Any settings stored across runs. Everest loads this before Load gets invoked.
        ///       Define your custom property returning _Settings typecasted as your custom settings type.
        ///       </summary>
        public virtual EverestModuleSettings _Settings { get; set; }

        /// <summary>
        ///       The type used for the save data object. Used for serialization, among other things.
        ///       </summary>
        public virtual Type SaveDataType => null;

        /// <summary>
        ///       Any save data stored across runs.
        ///       Define your custom property returning _SaveData typecasted as your custom save data type.
        ///       </summary>
        public virtual EverestModuleSaveData _SaveData { get; set; }

        /// <summary>
        ///       Whether the save and session data can be saved asynchronously and separately by Everest.
        ///       Doing so will use [Read,Write,Deserialize,Serialize][SaveData,Session].
        ///       Otherwise, the obsolete and forcibly synchronous [Load,Save,Delete] methods will be used.
        ///       Defaults to true; automatically gets set to false if you override an old method without overriding any new one.
        ///       </summary>
        public virtual bool SaveDataAsync { get; set; }

        /// <summary>
        ///       The type used for the session object. Used for serialization, among other things.
        ///       </summary>
        public virtual Type SessionType => null;

        /// <summary>
        ///       Any save data stored for the current session.
        ///       Define your custom property returning _Session typecasted as your custom session type.
        ///       </summary>
        public virtual EverestModuleSession _Session { get; set; }

        public SourceEverestModule(ISourceEngineContext engine)
        {
            SourceEngine = engine;
            SaveDataAsync |= typeof(SourceEverestModule) == GetType().GetMethod("LoadSaveData").DeclaringType &&
                             typeof(SourceEverestModule) == GetType().GetMethod("SaveSaveData").DeclaringType &&
                             typeof(SourceEverestModule) == GetType().GetMethod("DeleteSaveData").DeclaringType &&
                             typeof(SourceEverestModule) == GetType().GetMethod("LoadSession").DeclaringType &&
                             typeof(SourceEverestModule) == GetType().GetMethod("SaveSession").DeclaringType &&
                             typeof(SourceEverestModule) == GetType().GetMethod("DeleteSession").DeclaringType;
            SaveDataAsync |= typeof(SourceEverestModule) != GetType().GetMethod("ReadSaveData").DeclaringType ||
                             typeof(SourceEverestModule) != GetType().GetMethod("DeserializeSaveData").DeclaringType ||
                             typeof(SourceEverestModule) != GetType().GetMethod("SerializeSaveData").DeclaringType ||
                             typeof(SourceEverestModule) != GetType().GetMethod("WriteSaveData").DeclaringType ||
                             typeof(SourceEverestModule) != GetType().GetMethod("ReadSession").DeclaringType ||
                             typeof(SourceEverestModule) != GetType().GetMethod("DeserializeSession").DeclaringType ||
                             typeof(SourceEverestModule) != GetType().GetMethod("SerializeSession").DeclaringType ||
                             typeof(SourceEverestModule) != GetType().GetMethod("WriteSession").DeclaringType;
            if (!SaveDataAsync)
            {
                ((IEverestLoggerProcessEnvironment)SourceEngine).Logger.LogModuleSourceSite1(this);
            }
        }
    }
}
