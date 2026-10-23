using System.Collections;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Startup;
using Celeste.Scene.Entities;

namespace Celeste.Game.Menus.Overworld
{
    public abstract class OuiState : SceneEntityState
    {
        public bool Focused;

        protected OuiState(ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine)
                .EntitySourceDataRegistration)
        {
            Tags = ((IOriginalGameTagsEnvironment)engine).Tags.HUD.Value;
        }

        public OverworldSequence Overworld =>
            Scene as OverworldSequence;

        public bool Selected => Overworld != null && ReferenceEquals(Overworld.Current, this);
        public virtual bool IsTitleScreen => false;
        public virtual bool IsMainMenu => false;

        public virtual bool IsStart(OverworldSequence overworld,
            OverworldStartMode start)
        {
            return false;
        }

        public abstract IEnumerator Enter(OuiState from);
        public abstract IEnumerator Leave(OuiState next);
    }
}
