using System;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Session;
using Celeste.Game.Input.Gui;
using Celeste.Game.Menus.Title;
using Celeste.Game.Save.Runtime;
using Celeste.Simulation.Presentation.Scene.Transitions;

namespace Celeste.Game.Menus.Overworld
{
    public partial class OverworldSequence
    {
        public override void Update()
        {
            var engine = EngineContext;
            if (Mountain.Area >= 0 && !Mountain.Animating)
            {
                var mountainCursor = ((IOriginalSessionConstructionProcess)engine).AreaTable.Areas[Mountain.Area]
                    .MountainCursor;
                if (mountainCursor != Vector3.Zero)
                    Maddy.Position = mountainCursor + new Vector3(0f, (float)Math.Sin(TimeActive * 2f) * .02f, 0f);
            }

            if (Overlay != null)
            {
                if (Overlay.XboxOverlay)
                {
                    Mountain.Update(this);
                    Snow3D.Update();
                }

                Overlay.Update();
                SourceScene.CommitQueuedEntityLists();
                if (Snow != null)
                    Snow.Update(this);
            }
            else
            {
                if (!Transitioning || !ShowInputUI)
                    inputEase = ScalarMath.Approach(inputEase,
                        ShowInputUI && !((IOriginalInputGuiProcess)engine).InputGui.GuiInputController() ? 1 : 0,
                        engine.Frame.DeltaTime * 4f, ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                base.Update();
            }

            if (((IOriginalGameplayProcess)engine).SaveContext.CurrentSave != null
                && ((IOriginalSaveSessionSelectionEnvironment)engine).SaveSessionSelection.GetLastAreaSafe(
                    ((IOriginalGameplayProcess)engine).SaveContext.CurrentSave).ID == 10
                && 10 <= ((IOriginalSaveProgressionEnvironment)engine).SaveProgression.GetUnlockedAreasSafe(
                    ((IOriginalGameplayProcess)engine).SaveContext.CurrentSave)
                && !IsCurrent<MainMenuSequence>())
                ((IOriginalGameplayProcess)engine).AudioSession.SetMusicParam("moon", 1f);
            else
                ((IOriginalGameplayProcess)engine).AudioSession.SetMusicParam("moon", 0f);
            var duration = 1f;
            var hasWipe = false;
            // ReSharper disable once ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
            foreach (var renderer in Renderers.Renderers)
                if (renderer is ScreenWipePresentation)
                {
                    hasWipe = true;
                    duration = (renderer as ScreenWipePresentation).Duration;
                }

            var title = (Current is TitleScreenSequence && Next == null) || Next is TitleScreenSequence;
            if (Snow != null)
                Snow.ParticleAlpha = ScalarMath.Approach(Snow.ParticleAlpha,
                    title || hasWipe || (Overlay != null && !Overlay.XboxOverlay) ? 1 : 0,
                    engine.Frame.DeltaTime / duration, ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
        }
    }
}
