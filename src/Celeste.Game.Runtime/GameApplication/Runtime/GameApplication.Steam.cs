using System;
using Celeste.Core.Platform.Steam;
using Celeste.Game.Profiles;
using Celeste.Game.Execution.Engine.Update;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalSteamCallbacks
    {
        private ISourceSteamApplicationState sourceSteamApplication;

        public ISourceSteamApplicationState SteamApplication => sourceSteamApplication ??
                                                                throw new InvalidOperationException(
                                                                    "The source Steam application state is not constructed.");

        internal void ConstructSourceSteamApplication()
        {
            if (sourceSteamApplication != null)
                throw new InvalidOperationException("The source Steam application state is already constructed.");
            sourceSteamApplication = SourceProfile == GameProfile.Original
                ? (ISourceSteamApplicationState)new Celeste.Game.Platform.Steam.OriginalSteamApplicationState()
                : new Celeste.Everest.Platform.Steam.EverestSteamApplicationState();
        }

        internal bool InitializeSourceSteamStartup()
        {
            if (PhysicalIO.SteamRuntime.RestartAppIfNecessary(SteamApplication.ApplicationId)) return false;
            if (!PhysicalIO.SteamRuntime.Initialize())
            {
                ErrorLog.Write("Steam not found!");
                ErrorLog.Open();
                return false;
            }

            if (!SettingsProcess.Existed)
                SettingsProcess.Instance.LanguageId = PhysicalIO.SteamRuntime.GetCurrentGameLanguage();
            return true;
        }

        void IOriginalSteamCallbacks.RunCallbacks()
        {
            PhysicalIO.SteamRuntime?.RunCallbacks();
        }
    }
}
