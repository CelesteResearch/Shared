using Celeste.Scene.Scheduling;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation.Rendering;
using Celeste.Simulation;

namespace Celeste.Game.Menus.Overworld
{
    public abstract class OuiState : global::Celeste.Scene.Entities.SceneEntityState
    {
        public bool Focused;

        protected OuiState(global::Celeste.Core.Scheduling.ISourceEngineContext engine)
            : base(((global::Celeste.Core.Components.ISourceEntitySourceDataEnvironment)engine)
                .EntitySourceDataRegistration)
        {
            Tags = ((global::Celeste.Game.Execution.Startup.IOriginalGameTagsEnvironment)engine).Tags.HUD.Value;
        }

        public global::Celeste.Game.Menus.Overworld.OverworldSequence Overworld =>
            Scene as global::Celeste.Game.Menus.Overworld.OverworldSequence;

        public bool Selected => Overworld != null && ReferenceEquals(Overworld.Current, this);
        public virtual bool IsTitleScreen => false;
        public virtual bool IsMainMenu => false;

        public virtual bool IsStart(global::Celeste.Game.Menus.Overworld.OverworldSequence overworld,
            global::Celeste.Game.Menus.Overworld.OverworldStartMode start) => false;

        public abstract IEnumerator Enter(global::Celeste.Game.Menus.Overworld.OuiState from);
        public abstract IEnumerator Leave(global::Celeste.Game.Menus.Overworld.OuiState next);
    }
}
