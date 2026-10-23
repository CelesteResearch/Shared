using System;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Gameplay.Effects.Slashes
{
    public class OriginalSlashFxState : SceneEntityState
    {
        private readonly ISourceEngineContext engine;
        public Sprite Sprite;
        public Vector2 Direction;

        public OriginalSlashFxState(ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.engine = engine;
            OwnedComponents.Add(Sprite = new(engine,
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas,
                "effects/slash/"));
            Sprite.Add("play", "", 0.1f, 0, 1, 2, 3);
            Sprite.CenterOrigin();
            Sprite.OnFinish = delegate { RemoveSelf(); };
            Depth = -100;
        }

        public override void Update()
        {
            Position += Direction * 8f * engine.DeltaTime;
            base.Update();
        }

        public static OriginalSlashFxState Burst(ISourceEngineContext engine, Vector2 position, float direction)
        {
            var scene = engine.Frame.Scenes.CurrentScene;
            var slashFx = engine.EntityPools.Create<OriginalSlashFxState>();
            ((ISourceScene)scene).SourceScene.QueueSourceEntity(slashFx);
            slashFx.Position = position;
            slashFx.Direction = Vector2Geometry.AngleToVector(direction, 1f);
            slashFx.Sprite.Play("play", true);
            slashFx.Sprite.Scale = Vector2.One;
            slashFx.Sprite.Rotation = 0f;
            if (Math.Abs(direction - (float)Math.PI) > 0.01f)
                slashFx.Sprite.Rotation = direction;
            slashFx.Visible = slashFx.Active = true;
            return slashFx;
        }
    }
}
