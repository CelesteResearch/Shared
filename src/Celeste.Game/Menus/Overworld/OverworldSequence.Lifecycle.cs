using Celeste.Core.Display;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Processes;
using Celeste.Simulation.Presentation.Scene.Transitions;

namespace Celeste.Game.Menus.Overworld
{
    public partial class OverworldSequence
    {
        public override void Begin()
        {
            base.Begin();
            SetNormalMusic();
            ((ISourceScreenWipeEnvironment)EngineContext).ProcessWipe.WipeColor = PackedColor.Black;
            new FadeWipePresentation(this, true);
            Renderers.UpdateLists();
            if (!EnteringPico8)
            {
                Renderers.MoveToFront(Snow);
                Renderers.UpdateLists();
            }

            EnteringPico8 = false;
            ReloadMountainStuff();
        }

        public override void End()
        {
            if (!EnteringPico8)
                Mountain.Dispose();
            base.End();
        }

        public void SetNormalMusic()
        {
            ((IOriginalGameplayProcess)EngineContext).AudioSession.SetMusic("event:/music/menu/level_select");
            ((IOriginalGameplayProcess)EngineContext).AudioSession.SetAmbience("event:/env/amb/worldmap");
        }

        public virtual void ReloadMountainStuff()
        {
            ((IOriginalMountainEnvironment)EngineContext).MountainResources.MountainBird.ReassignVertices();
            ((IOriginalMountainEnvironment)EngineContext).MountainResources.MountainMoon.ReassignVertices();
            ((IOriginalMountainEnvironment)EngineContext).MountainResources.MountainTerrain.ReassignVertices();
            ((IOriginalMountainEnvironment)EngineContext).MountainResources.MountainBuildings.ReassignVertices();
            ((IOriginalMountainEnvironment)EngineContext).MountainResources.MountainCoreWall.ReassignVertices();
            Mountain.Model.DisposeBillboardBuffers();
            Mountain.Model.ResetBillboardBuffers();
        }

        public override void HandleGraphicsReset()
        {
            ReloadMountainStuff();
            base.HandleGraphicsReset();
        }
    }
}
