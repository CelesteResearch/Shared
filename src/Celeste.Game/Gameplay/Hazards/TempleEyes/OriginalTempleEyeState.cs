using Celeste.Core.Display;
using Celeste.Physics.Collision;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Levels;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Scene.Entities;
using Celeste.Game.Gameplay.Holdables.TheoCrystal;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;

namespace Celeste.Game.Gameplay.Hazards.TempleEyes
{
    public class OriginalTempleEyeState : SceneEntityState
    {
        private readonly ISourceEngineContext engine;

        private OriginalGameGraphicsResources Graphics =>
            (OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics;

        private OriginalLevelSceneRoot Level => (OriginalLevelSceneRoot)Scene;
        private ISourceRandom Random => ((ISourceRandomEnvironment)engine).Random;
        private ISourceVectorArithmetic VectorArithmetic => ((ISourceVectorEnvironment)engine).VectorArithmetic;
        private AtlasEntry eyeTexture;

        private AtlasEntry pupilTexture;

        private Sprite eyelid;

        private Vector2 pupilPosition;

        private Vector2 pupilTarget;

        private float blinkTimer;

        private bool bursting;

        private bool isBG;

        public OriginalTempleEyeState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, data.Position + offset)
        {
            this.engine = engine;
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            isBG = SourceSceneCollision.FirstPoint<ISourceEntityCollider>(Level.SourceScene.Entities, "Celeste.Solid",
                Position) == null;
            if (isBG)
            {
                eyeTexture = Graphics.GameAtlas["scenery/temple/eye/bg_eye"];
                pupilTexture = Graphics.GameAtlas["scenery/temple/eye/bg_pupil"];
                Add(eyelid = AtlasSpriteFactory.Create(engine, Graphics.GameAtlas, "scenery/temple/eye/bg_lid"));
                base.Depth = 8990;
            }
            else
            {
                eyeTexture = Graphics.GameAtlas["scenery/temple/eye/fg_eye"];
                pupilTexture = Graphics.GameAtlas["scenery/temple/eye/fg_pupil"];
                Add(eyelid = AtlasSpriteFactory.Create(engine, Graphics.GameAtlas, "scenery/temple/eye/fg_lid"));
                base.Depth = -10001;
            }

            eyelid.AddLoop("open", "", 0f, default(int));
            eyelid.Add("blink", "", 0.08f, "open", 0, 1, 1, 2, 3, 0);
            eyelid.Play("open");
            eyelid.CenterOrigin();
            SetBlinkTimer();
        }

        private void SetBlinkTimer()
        {
            blinkTimer = SourceRandomMath.Range(Random, 1f, 15f);
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            TheoCrystalState entity =
                Level.SourceScene.Entities.GetTrackedEntity<TheoCrystalState>("Celeste.TheoCrystal");
            if (entity != null)
            {
                pupilTarget = VectorArithmetic.SafeNormalize(entity.Center - Position);
                pupilPosition = pupilTarget * 3f;
            }
        }

        public override void Update()
        {
            if (!bursting)
            {
                pupilPosition = VectorArithmetic.Approach(pupilPosition, pupilTarget * 3f, engine.DeltaTime * 16f);
                TheoCrystalState entity =
                    Level.SourceScene.Entities.GetTrackedEntity<TheoCrystalState>("Celeste.TheoCrystal");
                if (entity != null)
                {
                    pupilTarget = VectorArithmetic.SafeNormalize(entity.Center - Position);
                    if (Level.OnInterval(0.25f) && SourceRandomMath.NextFloat(Random) < 0.01f)
                    {
                        eyelid.Play("blink");
                    }
                }

                blinkTimer -= engine.DeltaTime;
                if (blinkTimer <= 0f)
                {
                    SetBlinkTimer();
                    eyelid.Play("blink");
                }
            }

            base.Update();
        }

        public void Burst()
        {
            bursting = true;
            Sprite sprite = AtlasSpriteFactory.Create(engine, Graphics.GameAtlas,
                isBG ? "scenery/temple/eye/bg_burst" : "scenery/temple/eye/fg_burst");
            sprite.Add("burst", "", 0.08f);
            sprite.Play("burst");
            sprite.OnLastFrame = delegate { RemoveSelf(); };
            sprite.CenterOrigin();
            Add(sprite);
            Remove(eyelid);
        }

        public override void Render(ISourceRenderContext context)
        {
            if (!bursting)
            {
                SourceAtlasDrawing.DrawCentered(context, this, eyeTexture, Position, PackedColor.White);
                SourceAtlasDrawing.DrawCentered(context, this, pupilTexture, Position + pupilPosition,
                    PackedColor.White);
            }

            base.Render(context);
        }
    }
}
