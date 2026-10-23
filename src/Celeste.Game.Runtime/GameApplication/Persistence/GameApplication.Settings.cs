using System;
using Celeste.Game.Save.Formats.Original;
using Celeste.Game.Save.IO;
using Celeste.Game.Settings;
using JetBrains.Annotations;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISettingsRuntimeContext,
        IOriginalSettingsAllocationEnvironment
    {
        [UsedImplicitly(ImplicitUseKindFlags.Access)]
        private readonly SettingsRuntime sourceSettingsProcess = new();

        private ISettingsFactory sourceSettingsAllocation;
        private IOriginalSaveXmlFormatPolicy sourceSaveXmlFormat;
        public SettingsRuntime SettingsProcess => sourceSettingsProcess;

        public ISettingsFactory SettingsAllocation => sourceSettingsAllocation ??
                                                      throw new InvalidOperationException(
                                                          "The actual settings allocation is not selected.");

        public IOriginalSaveXmlFormatPolicy SaveXmlFormat => sourceSaveXmlFormat ??
                                                             throw new InvalidOperationException(
                                                                 "The actual save XML format is not selected.");

        public void BindSettingsAllocation(ISettingsFactory actualPolicy)
        {
            if (sourceSettingsAllocation != null)
                throw new InvalidOperationException("Settings allocation is already selected.");
            sourceSettingsAllocation = actualPolicy ?? throw new ArgumentNullException(nameof(actualPolicy));
        }

        public void BindSaveXmlFormat(IOriginalSaveXmlFormatPolicy actualPolicy)
        {
            if (sourceSaveXmlFormat != null)
                throw new InvalidOperationException("Save XML format is already selected.");
            sourceSaveXmlFormat = actualPolicy ?? throw new ArgumentNullException(nameof(actualPolicy));
        }

        public void InitializeSourceSettings()
        {
            SettingsProcess.Initialize(((IOriginalUserIOStorageEnvironment)engine).UserIOStorage,
                SettingsAllocation);
        }
    }
}
