using System;
using System.IO;
using Celeste.Everest.Content.Serialization;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Everest.IO;
using Celeste.Everest.Modules.Persistence;
using Celeste.Everest.Modules.Settings;
using Celeste.Game.Save.IO;
using Celeste.Game.Save.Runtime;

namespace Celeste.Everest.Modules.Runtime
{
    public abstract partial class SourceEverestModule
    {
        /// <summary>
        ///     Load the mod settings. Loads the settings from {UserIO.GetSavePath("Saves")}/modsettings-{Metadata.Name}.celeste by
        ///     default.
        /// </summary>
        public virtual void LoadSettings()
        {
            if (SettingsType == null) return;

            _Settings = (EverestModuleSettings)SettingsType.GetConstructor(Type.EmptyTypes).Invoke(null);
            var path =
                ((IOriginalUserIOStorageEnvironment)SourceEngine).UserIOStorage.GetSaveFilePath("modsettings-" +
                    Metadata.Name);
            if (!File.Exists(path))
                path = Path.Combine(((IEverestModuleRuntimeEnvironment)SourceEngine).PathEverest,
                    "ModSettings-OBSOLETE",
                    Metadata.Name + ".yaml");

            if (!File.Exists(path)) return;

            try
            {
                using Stream stream = File.OpenRead(path);
                if (_Settings is EverestModuleBinarySettings)
                {
                    using var reader = new BinaryReader(stream);
                    ((EverestModuleBinarySettings)_Settings).Read(reader);
                }
                else
                {
                    using var input = new StreamReader(stream);
                    ((IEverestYamlEnvironment)SourceEngine).Yaml.DeserializerUsing(_Settings)
                        .Deserialize(input, SettingsType);
                }
            }
            catch (Exception e)
            {
                ((IEverestLoggerProcessEnvironment)SourceEngine).Logger.LogModuleSourceSite2(this);
                ((IEverestLoggerProcessEnvironment)SourceEngine).Logger.LogDetailed(e);
            }

            if (_Settings == null)
                _Settings = (EverestModuleSettings)SettingsType.GetConstructor(Type.EmptyTypes).Invoke(null);
        }

        /// <summary>
        ///     Save the mod settings. Saves the settings to {UserIO.GetSavePath("Saves")}/modsettings-{Metadata.Name}.yaml by
        ///     default.
        /// </summary>
        public virtual void SaveSettings()
        {
            var flag = ForceSaveDataFlush > 0;
            if (flag) ForceSaveDataFlush--;

            if (SettingsType == null || _Settings == null) return;

            var saveFilePath =
                ((IOriginalUserIOStorageEnvironment)SourceEngine).UserIOStorage.GetSaveFilePath("modsettings-" +
                    Metadata.Name);
            if (File.Exists(saveFilePath)) File.Delete(saveFilePath);

            Directory.CreateDirectory(Path.GetDirectoryName(saveFilePath));
            try
            {
                using var fileStream = File.OpenWrite(saveFilePath);
                if (_Settings is EverestModuleBinarySettings everestModuleBinarySettings)
                {
                    using var binaryWriter = new BinaryWriter(fileStream);
                    everestModuleBinarySettings.Write(binaryWriter);
                    if (flag ||
                        ((((IEverestCurrentCoreSettingsEnvironment)SourceEngine).CurrentCoreSettings.SaveDataFlush ??
                          true) && !((IEverestModuleRuntimeEnvironment)SourceEngine).MainThread.IsMainThread))
                    {
                        binaryWriter.Flush();
                        fileStream.Flush(true);
                    }

                    return;
                }

                using var streamWriter = new StreamWriter(fileStream);
                ((IEverestYamlEnvironment)SourceEngine).Yaml.Serializer.Serialize(streamWriter, _Settings,
                    SettingsType);
                if (flag ||
                    ((((IEverestCurrentCoreSettingsEnvironment)SourceEngine).CurrentCoreSettings.SaveDataFlush ??
                      true) && !((IEverestModuleRuntimeEnvironment)SourceEngine).MainThread.IsMainThread))
                {
                    streamWriter.Flush();
                    fileStream.Flush(true);
                }
            }
            catch (Exception e)
            {
                ((IEverestLoggerProcessEnvironment)SourceEngine).Logger.LogModuleSourceSite3(this);
                ((IEverestLoggerProcessEnvironment)SourceEngine).Logger.LogDetailed(e);
            }
        }

        /// <summary>
        ///     Load the mod save data. Loads the save data from
        ///     {UserIO.GetSavePath("Saves")}/{((IOriginalSaveInitializationEnvironment)SourceEngine).SaveInitialization.GetFilename(index)}-modsave-{Metadata.Name}.celeste
        ///     by default.
        /// </summary>
        [Obsolete("Override DeserializeSaveData and ReadSaveData instead.")]
        public virtual void LoadSaveData(int index)
        {
            ForceSaveDataAsync = true;
            DeserializeSaveData(index, ReadSaveData(index));
            ForceSaveDataAsync = false;
        }

        /// <summary>
        ///     Save the mod save data. Saves the save data to
        ///     {UserIO.GetSavePath("Saves")}/{((IOriginalSaveInitializationEnvironment)SourceEngine).SaveInitialization.GetFilename(index)}-modsave-{Metadata.Name}.celeste
        ///     by default.
        /// </summary>
        [Obsolete("Override SerializeSaveData and WriteSaveData instead.")]
        public virtual void SaveSaveData(int index)
        {
            ForceSaveDataAsync = true;
            WriteSaveData(index, SerializeSaveData(index));
            ForceSaveDataAsync = false;
        }

        /// <summary>
        ///     Delete the mod save data. Deletes the save data at
        ///     {UserIO.GetSavePath("Saves")}/{((IOriginalSaveInitializationEnvironment)SourceEngine).SaveInitialization.GetFilename(index)}-modsave-{Metadata.Name}.celeste
        ///     by default.
        /// </summary>
        [Obsolete("Override WriteSaveData and handle null data instead.")]
        public virtual void DeleteSaveData(int index)
        {
            ForceSaveDataAsync = true;
            WriteSaveData(index, null);
            ForceSaveDataAsync = false;
        }

        /// <summary>
        ///     Read the mod save data bytes from a file,
        ///     {UserIO.GetSavePath("Saves")}/{((IOriginalSaveInitializationEnvironment)SourceEngine).SaveInitialization.GetFilename(index)}-modsave-{Metadata.Name}.celeste
        ///     by default.
        /// </summary>
        public virtual byte[] ReadSaveData(int index)
        {
            if (!SaveDataAsync && !ForceSaveDataAsync)
                throw new(Metadata.Name +
                          " overrides old methods or otherwise disabled async save data support.");

            if (SaveDataType == null) return null;

            var saveFilePath = ((IOriginalUserIOStorageEnvironment)SourceEngine).UserIOStorage.GetSaveFilePath(
                ((IOriginalSaveInitializationEnvironment)SourceEngine).SaveInitialization.GetFilename(index) +
                "-modsave-" +
                Metadata.Name);
            if (!File.Exists(saveFilePath)) return null;

            try
            {
                return File.ReadAllBytes(saveFilePath);
            }
            catch (Exception e)
            {
                ((IEverestLoggerProcessEnvironment)SourceEngine).Logger.LogModuleSourceSite4(this);
                ((IEverestLoggerProcessEnvironment)SourceEngine).Logger.LogDetailed(e);
                return null;
            }
        }

        /// <summary>
        ///     Write the mod save data bytes into a file,
        ///     {UserIO.GetSavePath("Saves")}/{((IOriginalSaveInitializationEnvironment)SourceEngine).SaveInitialization.GetFilename(index)}-modsave-{Metadata.Name}.celeste
        ///     by default.
        /// </summary>
        public virtual void WriteSaveData(int index, byte[] data)
        {
            var flag = ForceSaveDataFlush > 0;
            if (flag) ForceSaveDataFlush--;

            if (!SaveDataAsync && !ForceSaveDataAsync)
                throw new(Metadata.Name +
                          " overrides old methods or otherwise disabled async save data support.");

            if (SaveDataType == null) return;

            var saveFilePath = ((IOriginalUserIOStorageEnvironment)SourceEngine).UserIOStorage.GetSaveFilePath(
                ((IOriginalSaveInitializationEnvironment)SourceEngine).SaveInitialization.GetFilename(index) +
                "-modsave-" +
                Metadata.Name);
            if (File.Exists(saveFilePath)) File.Delete(saveFilePath);

            if (data == null) return;

            Directory.CreateDirectory(Path.GetDirectoryName(saveFilePath));
            try
            {
                using var fileStream = File.OpenWrite(saveFilePath);
                fileStream.Write(data, 0, data.Length);
                if (flag || (SaveDataAsync &&
                             (((IEverestCurrentCoreSettingsEnvironment)SourceEngine).CurrentCoreSettings
                              .SaveDataFlush ??
                              true) && !((IEverestModuleRuntimeEnvironment)SourceEngine).MainThread.IsMainThread))
                    fileStream.Flush(true);
            }
            catch (Exception e)
            {
                ((IEverestLoggerProcessEnvironment)SourceEngine).Logger.LogModuleSourceSite5(this);
                ((IEverestLoggerProcessEnvironment)SourceEngine).Logger.LogDetailed(e);
            }
        }

        /// <summary>
        ///     Deserialize the mod save data from its raw bytes, fed with data from ReadSaveData either immediately or async.
        /// </summary>
        public virtual void DeserializeSaveData(int index, byte[] data)
        {
            if (!SaveDataAsync && !ForceSaveDataAsync)
                throw new(Metadata.Name +
                          " overrides old methods or otherwise disabled async save data support.");

            if (SaveDataType == null) return;

            _SaveData = (EverestModuleSaveData)SaveDataType.GetConstructor(Type.EmptyTypes).Invoke(null);
            _SaveData.Index = index;
            if (data == null) return;

            try
            {
                using (var memoryStream = new MemoryStream(data))
                {
                    if (_SaveData is EverestModuleBinarySaveData everestModuleBinarySaveData)
                    {
                        using var reader = new BinaryReader(memoryStream);
                        everestModuleBinarySaveData.Read(reader);
                    }
                    else
                    {
                        using var input = new StreamReader(memoryStream);
                        ((IEverestYamlEnvironment)SourceEngine).Yaml.DeserializerUsing(_SaveData)
                            .Deserialize(input, SaveDataType);
                    }
                }

                _SaveData.Index = index;
            }
            catch (Exception e)
            {
                ((IEverestLoggerProcessEnvironment)SourceEngine).Logger.LogModuleSourceSite6(this);
                ((IEverestLoggerProcessEnvironment)SourceEngine).Logger.LogDetailed(e);
            }
        }

        /// <summary>
        ///     Serialize the mod save data into its raw bytes, to be fed into WriteSaveData immediately or async.
        /// </summary>
        public virtual byte[] SerializeSaveData(int index)
        {
            if (!SaveDataAsync && !ForceSaveDataAsync)
                throw new(Metadata.Name +
                          " overrides old methods or otherwise disabled async save data support.");

            if (SaveDataType == null) return null;

            try
            {
                using var memoryStream = new MemoryStream();
                if (_SaveData is EverestModuleBinarySaveData everestModuleBinarySaveData)
                {
                    using var writer = new BinaryWriter(new SourceUndisposableStream(memoryStream));
                    everestModuleBinarySaveData.Write(writer);
                }
                else
                {
                    using var writer2 = new StreamWriter(new SourceUndisposableStream(memoryStream));
                    ((IEverestYamlEnvironment)SourceEngine).Yaml.Serializer.Serialize(writer2, _SaveData, SaveDataType);
                }

                memoryStream.Seek(0L, SeekOrigin.Begin);
                return memoryStream.ToArray();
            }
            catch (Exception e)
            {
                ((IEverestLoggerProcessEnvironment)SourceEngine).Logger.LogModuleSourceSite7(this);
                ((IEverestLoggerProcessEnvironment)SourceEngine).Logger.LogDetailed(e);
                return null;
            }
        }

        /// <summary>
        ///     Load the mod session. Loads the session from
        ///     {UserIO.GetSavePath("Saves")}/{((IOriginalSaveInitializationEnvironment)SourceEngine).SaveInitialization.GetFilename(index)}-modsession-{Metadata.Name}.celeste
        ///     by default.
        /// </summary>
        [Obsolete("Override DeserializeSession and ReadSession instead.")]
        public virtual void LoadSession(int index, bool forceNew)
        {
            ForceSaveDataAsync = true;
            DeserializeSession(index, forceNew ? null : ReadSession(index));
            ForceSaveDataAsync = false;
        }

        /// <summary>
        ///     Save the mod session. Saves the session to
        ///     {UserIO.GetSavePath("Saves")}/{((IOriginalSaveInitializationEnvironment)SourceEngine).SaveInitialization.GetFilename(index)}-modsession-{Metadata.Name}.celeste
        ///     by default.
        /// </summary>
        [Obsolete("Override SerializeSession and WriteSession instead.")]
        public virtual void SaveSession(int index)
        {
            ForceSaveDataAsync = true;
            WriteSession(index, SerializeSession(index));
            ForceSaveDataAsync = false;
        }

        /// <summary>
        ///     Delete the mod session. Deletes the session at
        ///     {UserIO.GetSavePath("Saves")}/{((IOriginalSaveInitializationEnvironment)SourceEngine).SaveInitialization.GetFilename(index)}-modsession-{Metadata.Name}.celeste
        ///     by default.
        /// </summary>
        [Obsolete("Override WriteSession and handle null data instead.")]
        public virtual void DeleteSession(int index)
        {
            ForceSaveDataAsync = true;
            WriteSession(index, null);
            ForceSaveDataAsync = false;
        }

        /// <summary>
        ///     Read the mod session bytes from a file,
        ///     {UserIO.GetSavePath("Saves")}/{((IOriginalSaveInitializationEnvironment)SourceEngine).SaveInitialization.GetFilename(index)}-modsession-{Metadata.Name}.celeste
        ///     by default.
        /// </summary>
        public virtual byte[] ReadSession(int index)
        {
            if (!SaveDataAsync && !ForceSaveDataAsync)
                throw new(Metadata.Name +
                          " overrides old methods or otherwise disabled async save data support.");

            if (SessionType == null) return null;

            var saveFilePath = ((IOriginalUserIOStorageEnvironment)SourceEngine).UserIOStorage.GetSaveFilePath(
                ((IOriginalSaveInitializationEnvironment)SourceEngine).SaveInitialization.GetFilename(index) +
                "-modsession-" + Metadata.Name);
            if (!File.Exists(saveFilePath)) return null;

            try
            {
                return File.ReadAllBytes(saveFilePath);
            }
            catch (Exception e)
            {
                ((IEverestLoggerProcessEnvironment)SourceEngine).Logger.LogModuleSourceSite8(this);
                ((IEverestLoggerProcessEnvironment)SourceEngine).Logger.LogDetailed(e);
                return null;
            }
        }

        /// <summary>
        ///     Write the mod session bytes into a file,
        ///     {UserIO.GetSavePath("Saves")}/{((IOriginalSaveInitializationEnvironment)SourceEngine).SaveInitialization.GetFilename(index)}-modsession-{Metadata.Name}.celeste
        ///     by default.
        /// </summary>
        public virtual void WriteSession(int index, byte[] data)
        {
            var flag = ForceSaveDataFlush > 0;
            if (flag) ForceSaveDataFlush--;

            if (!SaveDataAsync && !ForceSaveDataAsync)
                throw new(Metadata.Name +
                          " overrides old methods or otherwise disabled async save data support.");

            if (SessionType == null) return;

            var saveFilePath = ((IOriginalUserIOStorageEnvironment)SourceEngine).UserIOStorage.GetSaveFilePath(
                ((IOriginalSaveInitializationEnvironment)SourceEngine).SaveInitialization.GetFilename(index) +
                "-modsession-" + Metadata.Name);
            if (File.Exists(saveFilePath)) File.Delete(saveFilePath);

            if (data == null) return;

            Directory.CreateDirectory(Path.GetDirectoryName(saveFilePath));
            try
            {
                using var fileStream = File.OpenWrite(saveFilePath);
                fileStream.Write(data, 0, data.Length);
                if (flag || (SaveDataAsync &&
                             (((IEverestCurrentCoreSettingsEnvironment)SourceEngine).CurrentCoreSettings
                              .SaveDataFlush ??
                              true) && !((IEverestModuleRuntimeEnvironment)SourceEngine).MainThread.IsMainThread))
                    fileStream.Flush(true);
            }
            catch (Exception e)
            {
                ((IEverestLoggerProcessEnvironment)SourceEngine).Logger.LogModuleSourceSite9(this);
                ((IEverestLoggerProcessEnvironment)SourceEngine).Logger.LogDetailed(e);
            }
        }

        /// <summary>
        ///     Deserialize the mod session from its raw bytes, fed with data from ReadSession either immediately or async.
        /// </summary>
        public virtual void DeserializeSession(int index, byte[] data)
        {
            if (!SaveDataAsync && !ForceSaveDataAsync)
                throw new(Metadata.Name +
                          " overrides old methods or otherwise disabled async save data support.");

            if (SessionType == null) return;

            _Session = (EverestModuleSession)SessionType.GetConstructor(Type.EmptyTypes).Invoke(null);
            _Session.Index = index;
            if (data == null) return;

            try
            {
                using (var memoryStream = new MemoryStream(data))
                {
                    if (_Session is EverestModuleBinarySession everestModuleBinarySession)
                    {
                        using var reader = new BinaryReader(memoryStream);
                        everestModuleBinarySession.Read(reader);
                    }
                    else
                    {
                        using var input = new StreamReader(memoryStream);
                        ((IEverestYamlEnvironment)SourceEngine).Yaml.DeserializerUsing(_Session)
                            .Deserialize(input, SessionType);
                    }
                }

                _Session.Index = index;
            }
            catch (Exception e)
            {
                ((IEverestLoggerProcessEnvironment)SourceEngine).Logger.LogModuleSourceSite10(this);
                ((IEverestLoggerProcessEnvironment)SourceEngine).Logger.LogDetailed(e);
            }
        }

        /// <summary>
        ///     Serialize the mod session into its raw bytes, to be fed into WriteSession immediately or async.
        /// </summary>
        public virtual byte[] SerializeSession(int index)
        {
            if (!SaveDataAsync && !ForceSaveDataAsync)
                throw new(Metadata.Name +
                          " overrides old methods or otherwise disabled async save data support.");

            if (SessionType == null) return null;

            try
            {
                using var memoryStream = new MemoryStream();
                if (_Session is EverestModuleBinarySession everestModuleBinarySession)
                {
                    using var writer = new BinaryWriter(new SourceUndisposableStream(memoryStream));
                    everestModuleBinarySession.Write(writer);
                }
                else
                {
                    using var writer2 = new StreamWriter(new SourceUndisposableStream(memoryStream));
                    ((IEverestYamlEnvironment)SourceEngine).Yaml.Serializer.Serialize(writer2, _Session, SessionType);
                }

                memoryStream.Seek(0L, SeekOrigin.Begin);
                return memoryStream.ToArray();
            }
            catch (Exception e)
            {
                ((IEverestLoggerProcessEnvironment)SourceEngine).Logger.LogModuleSourceSite11(this);
                ((IEverestLoggerProcessEnvironment)SourceEngine).Logger.LogDetailed(e);
                return null;
            }
        }
    }
}
