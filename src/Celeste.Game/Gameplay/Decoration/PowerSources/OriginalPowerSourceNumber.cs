using Celeste.Core.Display;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Scene.Entities;
using Celeste.Graphics.Content;
using Celeste.Graphics.Animation;
using Celeste.Game.Execution.Levels;
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

        private bool gotKey;

        public OriginalPowerSourceNumber(Vector2 position, int index, bool gotCollectables,
            IOriginalPowerSourceNumberProcess engine)
            : base(engine.EntitySourceDataRegistration)
        {
            this.engine = engine;
            Position = position;
            base.Depth = -10010;
            OwnedComponents.Add(image =
                new SpriteImage(engine.GameGraphics.GameAtlas["scenery/powersource_numbers/1"]));
            OwnedComponents.Add(glow =
                new SpriteImage(engine.GameGraphics.GameAtlas["scenery/powersource_numbers/1_glow"]));
            glow.Color = Color.Transparent;
            gotKey = gotCollectables;
        }

        public override void Update()
        {
            base.Update();
            if ((base.Scene as OriginalLevelSceneRoot).Session.GetFlag("disable_lightning") && !gotKey)
            {
                timer += engine.DeltaTime;
                ease = global::Celeste.Core.Mathematics.ScalarMath.Approach(ease, 1f, engine.DeltaTime * 4f,
                    engine.ExtremaArithmetic);
                glow.Color = Color.White * ease *
                             global::Celeste.Core.Mathematics.ScalarMath.Map((float)System.Math.Sin(timer * 2f), -1f,
                                 1f,
                                 0.5f, 0.9f);
            }
        }
    }
}
