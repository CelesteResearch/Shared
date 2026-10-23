using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Gameplay.Holdables.TheoCrystal;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Rendering;
using Celeste.Physics.Collision;
using Celeste.Scene.Entities;

namespace Celeste.Game.Gameplay.Hazards.TempleEyes
{
    public class OriginalTempleEyeState : SceneEntityState
    {
        private readonly ISourceEngineContext _engine;

        private OriginalGameGraphicsResources Graphics =>
            (OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)_engine).GameGraphics;

        private OriginalLevelSceneRoot Level => (OriginalLevelSceneRoot)Scene;
        private ISourceRandom Random => ((ISourceRandomEnvironment)_engine).Random;
        private ISourceVectorArithmetic VectorArithmetic => ((ISourceVectorEnvironment)_engine).VectorArithmetic;
        private AtlasEntry _eyeTexture;

        private AtlasEntry _pupilTexture;

        private Sprite _eyelid;

        private Vector2 _pupilPosition;

        private Vector2 _pupilTarget;

        private float _blinkTimer;

        private bool _bursting;

        private bool _isBg;

        public OriginalTempleEyeState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, data.Position + offset)
        {
            _engine = engine;
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            _isBg = SourceSceneCollision.FirstPoint<ISourceEntityCollider>(Level.SourceScene.Entities, "Celeste.Solid",
                Position) == null;
            if (_isBg)
            {
                _eyeTexture = Graphics.GameAtlas["scenery/temple/eye/bg_eye"];
                _pupilTexture = Graphics.GameAtlas["scenery/temple/eye/bg_pupil"];
                Add(_eyelid = AtlasSpriteFactory.Create(_engine, Graphics.GameAtlas, "scenery/temple/eye/bg_lid"));
                Depth = 8990;
            }
            else
            {
                _eyeTexture = Graphics.GameAtlas["scenery/temple/eye/fg_eye"];
                _pupilTexture = Graphics.GameAtlas["scenery/temple/eye/fg_pupil"];
                Add(_eyelid = AtlasSpriteFactory.Create(_engine, Graphics.GameAtlas, "scenery/temple/eye/fg_lid"));
                Depth = -10001;
            }

            _eyelid.AddLoop("open", "", 0f, default(int));
            _eyelid.Add("blink", "", 0.08f, "open", 0, 1, 1, 2, 3, 0);
            _eyelid.Play("open");
            _eyelid.CenterOrigin();
            SetBlinkTimer();
        }

        private void SetBlinkTimer()
        {
            _blinkTimer = SourceRandomMath.Range(Random, 1f, 15f);
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            var entity =
                Level.SourceScene.Entities.GetTrackedEntity<TheoCrystalState>("Celeste.TheoCrystal");
            if (entity != null)
            {
                _pupilTarget = VectorArithmetic.SafeNormalize(entity.Center - Position);
                _pupilPosition = _pupilTarget * 3f;
            }
        }

        public override void Update()
        {
            if (!_bursting)
            {
                _pupilPosition = VectorArithmetic.Approach(_pupilPosition, _pupilTarget * 3f, _engine.DeltaTime * 16f);
                var entity =
                    Level.SourceScene.Entities.GetTrackedEntity<TheoCrystalState>("Celeste.TheoCrystal");
                if (entity != null)
                {
                    _pupilTarget = VectorArithmetic.SafeNormalize(entity.Center - Position);
                    if (Level.OnInterval(0.25f) && SourceRandomMath.NextFloat(Random) < 0.01f) _eyelid.Play("blink");
                }

                _blinkTimer -= _engine.DeltaTime;
                if (_blinkTimer <= 0f)
                {
                    SetBlinkTimer();
                    _eyelid.Play("blink");
                }
            }

            base.Update();
        }

        public void Burst()
        {
            _bursting = true;
            var sprite = AtlasSpriteFactory.Create(_engine, Graphics.GameAtlas,
                _isBg ? "scenery/temple/eye/bg_burst" : "scenery/temple/eye/fg_burst");
            sprite.Add("burst", "", 0.08f);
            sprite.Play("burst");
            sprite.OnLastFrame = delegate { RemoveSelf(); };
            sprite.CenterOrigin();
            Add(sprite);
            Remove(_eyelid);
        }

        public override void Render(ISourceRenderContext context)
        {
            if (!_bursting)
            {
                SourceAtlasDrawing.DrawCentered(context, this, _eyeTexture, Position, PackedColor.White);
                SourceAtlasDrawing.DrawCentered(context, this, _pupilTexture, Position + _pupilPosition,
                    PackedColor.White);
            }

            base.Render(context);
        }
    }
}
