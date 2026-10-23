using System;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Game.Execution.Levels;
using Celeste.Graphics.Animation;
using Celeste.Scene.Entities;
using Color = Celeste.Core.Display.PackedColor;

namespace Celeste.Game.Gameplay.Decoration.PowerSources
{
    public class OriginalPowerSourceNumber : SceneEntityState
    {
        private readonly IOriginalPowerSourceNumberProcess engine;

        private readonly SpriteImage image;

        private readonly SpriteImage glow;

        private float ease;

        private float timer;

        private readonly bool gotKey;

        public OriginalPowerSourceNumber(Vector2 position, int index, bool gotCollectables,
            IOriginalPowerSourceNumberProcess engine)
            : base(engine.EntitySourceDataRegistration)
        {
            this.engine = engine;
            Position = position;
            Depth = -10010;
            OwnedComponents.Add(image =
                new(engine.GameGraphics.GameAtlas["scenery/powersource_numbers/1"]));
            OwnedComponents.Add(glow =
                new(engine.GameGraphics.GameAtlas["scenery/powersource_numbers/1_glow"]));
            glow.Color = Color.Transparent;
            gotKey = gotCollectables;
        }

        public override void Update()
        {
            base.Update();
            if ((Scene as OriginalLevelSceneRoot).Session.GetFlag("disable_lightning") && !gotKey)
            {
                timer += engine.DeltaTime;
                ease = ScalarMath.Approach(ease, 1f, engine.DeltaTime * 4f,
                    engine.ExtremaArithmetic);
                glow.Color = Color.White * ease *
                             ScalarMath.Map((float)Math.Sin(timer * 2f), -1f,
                                 1f,
                                 0.5f, 0.9f);
            }
        }
    }
}
