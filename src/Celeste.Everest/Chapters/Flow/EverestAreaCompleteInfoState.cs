using Celeste.Core.Display;
using System;
using Jdenticon;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Core.Rendering;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering.States;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Settings;
using Celeste.Game.Execution.Processes;
using Celeste.Simulation.Runtime.Session;
using Celeste.Simulation.Presentation.Hud.Speedrun;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Graphics.Rendering.Textures;
using Celeste.Graphics.Display;
using Celeste.Graphics.Display.Colors;
using Celeste.Game.Chapters.Flow;
using global::Celeste.Game.Execution;

namespace Celeste.Everest.Chapters.Flow
{
    public sealed class EverestAreaCompleteInfoState : OriginalAreaCompleteInfoState
    {
        // These are the actual installed AreaComplete static fields, one holder per process.
        private string versionFull;
        private float versionOffset;
        private SourceTexture2DResource identicon;
        private float everestTime;
        private bool isPieScreen;

        public EverestAreaCompleteInfoState(ISourceEngineContext engine) : base(engine)
        {
        }

        public override void InitializePie(ChapterCompletionSession session) => InitializeInstalled(true, session);
        public override void DisposePie() => DisposeInstalled();

        public void InitializeInstalled(bool pieScreen, ChapterCompletionSession session)
        {
            versionOffset = 0f;
            if (((ISettingsContext)engine).Settings.SpeedrunClock > (int)SpeedrunClockMode.Off)
            {
                var installed = (IInstalledAreaCompleteInfoProcess)engine;
                versionFull = $"{GameRuntime.Instance.Version}\n{installed.Build}";
                if (session != null && installed.TryGetMapModule($"Maps/{installed.GetModePath(session)}", out var mod))
                {
                    if (mod != null && mod.Multimeta?.Length >= 1)
                    {
                        versionFull = $"{versionFull}\n{mod.Multimeta[0].Version}";
                        versionOffset -= 32f;
                    }
                }

                identicon?.Dispose();
                using System.IO.Stream stream = Jdenticon.Identicon.FromHash(installed.InstallationHash, 100)
                    .SaveAsPng();
                identicon = SourceTexture2DResource.FromStream(
                    ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice,
                    stream);
            }

            isPieScreen = pieScreen;
            global::Celeste.Core.Scheduling.SourceRuntimeExtensions
                .Get<IOriginalAreaCompleteInfoHooksEnvironment>(engine)
                ?.AfterSourceAreaCompleteInfoInitialized(pieScreen, session);
        }

        public void DisposeInstalled()
        {
            identicon?.Dispose();
            identicon = null;
        }

        public override void VersionNumberAndVariants(ISourceRenderContext context, object owner, string version,
            float ease, float alpha)
        {
            everestTime += engine.RawDeltaTime;
            DrawOriginal(context, owner, versionFull, ease, alpha, versionOffset);
            if (identicon != null)
            {
                _ = everestTime;
                float rotation = MathF.PI / 50f * (float)Math.Sin(everestTime * .8f);
                Vector2 position = new Vector2(1920f * (isPieScreen ? .05f : .5f), 930f);
                var bounds = identicon.Bounds;
                bounds.Height = 2;
                int num = 0;
                while (bounds.Y < identicon.Height)
                {
                    Vector2 origin =
                        new Vector2(
                            identicon.Width * .5f + (float)Math.Round(2.5 + 2.5 * Math.Sin(everestTime + .12f * num)),
                            2 * -num);
                    ((ISourceDrawScope)context).Draw.SpriteBatch.Draw(identicon, position, bounds,
                        (PackedColor.White * ease).PackedValue, rotation, origin, 1f, SourceSpriteEffects.None, 0f);
                    num++;
                    bounds.Y += 2;
                    bounds.Height = Math.Min(2, identicon.Height - bounds.Y);
                }
            }
        }
    }
}
