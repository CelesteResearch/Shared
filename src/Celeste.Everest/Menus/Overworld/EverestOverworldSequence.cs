using System;
using System.Collections.Generic;
using Celeste.Core.Components.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Everest.Presentation.Mountain.Model;
using Celeste.Game.Menus.Overworld;

namespace Celeste.Everest.Menus.Overworld
{
    public partial class EverestOverworldSequence : OverworldSequence
    {
        private bool customizedChapterSelectMusic;
        public Dictionary<Type, OuiPropertiesAttribute> UIProperties { get; set; }

        public EverestOverworldSequence(ISourceEngineContext engine, OverworldLoaderSequence loader)
            : base(engine, loader)
        {
        }

        public override void End()
        {
            base.End();
            if (!!EnteringPico8)
                return;
            Renderers.Remove(Snow);
            Renderers.UpdateLists();
            Snow = null;
        }

        public override void ReloadMountainStuff()
        {
            base.ReloadMountainStuff();
            foreach (var value in ((IEverestMountainResourceEnvironment)EngineContext).MountainExtension.ObjModelCache
                     .Values)
                value.ReassignVertices();
        }

        public override void BeforeRender()
        {
            foreach (var component in SourceScene.Components.GetTrackedComponents("Celeste.BeforeRenderHook"))
            {
                var hook = (BeforeRenderCallbackComponentState)component;
                if (hook.Visible)
                    hook.Callback();
            }

            base.BeforeRender();
        }

        public bool IsCurrent(Func<OuiState, bool> predicate)
        {
            return Current != null ? predicate(Current) : predicate(Last);
        }

        private void restoreNormalMusicIfCustomized()
        {
            if (!customizedChapterSelectMusic)
                return;
            SetNormalMusic();
            customizedChapterSelectMusic = false;
        }
    }
}
