using Celeste.Core.Display;
using System.Numerics;
using Celeste.Core.Audio;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Controls.Source;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Levels;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Player.Collision.Components;
using Celeste.Simulation.Presentation.PostProcessing.Displacement;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;

namespace Celeste.Game.Gameplay.Hazards.TempleEyes
{
    public class OriginalTempleBigEyeballShockwaveState : SceneEntityState
    {
        private readonly ISourceEngineContext engine;
        private AtlasEntry distortionTexture;
        private float distortionAlpha;
        private bool hasHitPlayer;

        public OriginalTempleBigEyeballShockwaveState(ISourceEngineContext engine) : base(
            ((global::Celeste.Core.Components.ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.engine = engine;
            Depth = -1000000;
            Collider = new HitboxColliderGeometry(48f, 200f, -30f, -100f);
            Add(new PlayerColliderComponentState(OnPlayer));
            var texture =
                ((OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics).GameAtlas[
                    "util/displacementcirclehollow"];
            distortionTexture = texture.GetSubtexture(0, 0, texture.FrameWidth / 2, texture.FrameHeight);
            Add(new DisplacementRenderHookState(RenderDisplacement));
        }

        public OriginalTempleBigEyeballShockwaveState Init(Vector2 position)
        {
            Position = position;
            Collidable = true;
            distortionAlpha = 0f;
            hasHitPlayer = false;
            return this;
        }

        public override void Update()
        {
            base.Update();
            X -= 300f * engine.DeltaTime;
            distortionAlpha = ScalarMath.Approach(distortionAlpha, 1f, engine.DeltaTime * 4f,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            if (X < (float)((Scene as OriginalLevelSceneRoot).Bounds.Left - 20)) RemoveSelf();
        }

        private void RenderDisplacement()
            => SourceAtlasDrawing.DrawCentered(((OriginalLevelSceneRoot)Scene).SourceRenderContext, this,
                distortionTexture, Position, PackedColor.White * .8f * distortionAlpha, new Vector2(.9f, 1.5f));

        private void OnPlayer(RoomPlayerSession player)
        {
            if (player.Machine.State != 2)
            {
                player.Data.Motion.Normal.Speed.X = -100f;
                if (player.Data.Motion.Normal.Speed.Y > 30f) player.Data.Motion.Normal.Speed.Y = 30f;
                if (!hasHitPlayer)
                {
                    ((IOriginalGameInputProcessEnvironment)engine).InputSource.Rumble(RumbleStrength.Strong,
                        RumbleLength.Medium);
                    ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play("event:/game/05_mirror_temple/eye_pulse",
                        player.Position);
                    hasHitPlayer = true;
                }
            }
        }
    }
}
