using Celeste.Core.Display;
using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Components.Animation;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Controls.Source;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Graphics;
using Celeste.Scene.Components.Oscillation;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Display;

namespace Celeste.Game.Presentation.Hud.Collectibles
{
    public class HeartGemDisplayState : SourceComponentState
    {
        private readonly ISourceEngineContext engine;

        private OriginalGameGraphicsResources Graphics =>
            (OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics;

        public Vector2 Position;

        public Sprite[] Sprites;

        public Vector2 TargetPosition;

        private SpriteImage bg;

        private WigglerComponent rotateWiggler;

        private SimulationCoroutine routine;

        private Vector2 bounce;

        private SourceTweenState tween;

        private PackedColor SpriteColor
        {
            get { return Sprites[0].Color; }
            set
            {
                for (int i = 0; i < Sprites.Length; i++)
                {
                    Sprites[i].Color = value;
                }
            }
        }

        public HeartGemDisplayState(ISourceEngineContext engine, int heartgem, bool hasGem)
            : base(true, true)
        {
            this.engine = engine;
            Sprites = new Sprite[3];
            for (int i = 0; i < Sprites.Length; i++)
            {
                Sprites[i] = Graphics.GuiSpriteBank.Create("heartgem" + i);
                Sprites[i].Visible = heartgem == i && hasGem;
                Sprites[i].Play("spin");
            }

            bg = new SpriteImage(Graphics.GuiAtlas["collectables/heartgem/0/spin00"]);
            bg.Color = PackedColor.Black;
            bg.CenterOrigin();
            rotateWiggler = ((ISourceWigglerPoolScope)engine).WigglerPool.Create(0.4f, 6f);
            rotateWiggler.UseRawDeltaTime = true;
            SimpleCurve curve = new SimpleCurve(Vector2.UnitY * 80f, Vector2.Zero, Vector2.UnitY * -160f);
            tween = SourceTweenState.Create(engine.TweenPool, SourceTweenState.TweenMode.Oneshot, null, 0.4f);
            tween.OnStart = delegate { SpriteColor = PackedColor.Transparent; };
            tween.OnUpdate = delegate(SourceTweenState t)
            {
                bounce = ((ISourceCurveEnvironment)engine).CurveArithmetic.GetPoint(curve, t.Eased);
                SpriteColor = PackedColor.White * ScalarMath.Lerp(0f, 1f, ScalarMath.Clamp(t.Percent * 1.5f, 0f, 1f),
                    ((ISourceScalarEnvironment)engine).ScalarArithmetic);
            };
        }

        public void Wiggle()
        {
            rotateWiggler.Start();
            for (int i = 0; i < Sprites.Length; i++)
            {
                if (Sprites[i].Visible)
                {
                    Sprites[i].Play("spin", restart: true);
                    Sprites[i].SetAnimationFrame(19);
                }
            }
        }

        public void Appear(OriginalAreaMode mode)
        {
            tween.Start();
            routine = new SimulationCoroutine(engine, AppearSequence(Sprites[(int)mode]));
            routine.UseRawDeltaTime = true;
        }

        public void SetCurrentMode(OriginalAreaMode mode, bool has)
        {
            for (int i = 0; i < Sprites.Length; i++)
            {
                Sprites[i].Visible = i == (int)mode && has;
            }

            if (!has)
            {
                routine = null;
            }
        }

        public override void Update()
        {
            base.Update();
            if (routine != null && routine.Active)
            {
                routine.Update();
            }

            if (rotateWiggler.Active)
            {
                rotateWiggler.Update();
            }

            for (int i = 0; i < Sprites.Length; i++)
            {
                if (Sprites[i].Active)
                {
                    Sprites[i].Update();
                }
            }

            if (tween != null && tween.Active)
            {
                tween.Update();
            }

            Position = ((ISourceVectorEnvironment)engine).VectorArithmetic.Approach(Position, TargetPosition,
                200f * engine.DeltaTime);
            for (int j = 0; j < Sprites.Length; j++)
            {
                Sprites[j].Scale.X = ScalarMath.Approach(Sprites[j].Scale.X, 1f, 2f * engine.DeltaTime,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                Sprites[j].Scale.Y = ScalarMath.Approach(Sprites[j].Scale.Y, 1f, 2f * engine.DeltaTime,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            }
        }

        public override void Render(ISourceRenderContext context)
        {
            base.Render(context);
            bg.Position = ((ISourceEntityPosition)Entity).Position + Position;
            for (int i = 0; i < Sprites.Length; i++)
            {
                if (Sprites[i].Visible)
                {
                    Sprites[i].Rotation = rotateWiggler.Value * 30f * ((float)Math.PI / 180f);
                    Sprites[i].Position = ((ISourceEntityPosition)Entity).Position + Position + bounce;
                    Sprites[i].Render(context);
                }
            }
        }

        private IEnumerator AppearSequence(Sprite sprite)
        {
            sprite.Play("idle");
            sprite.Visible = true;
            sprite.Scale = new Vector2(0.8f, 1.4f);
            yield return tween.Wait();
            ((IOriginalGameInputProcessEnvironment)engine).InputSource.Rumble(RumbleStrength.Strong,
                RumbleLength.Medium);
            sprite.Scale = new Vector2(1.4f, 0.8f);
            yield return 0.4f;
            sprite.CenterOrigin();
            rotateWiggler.Start();
            ((IOriginalGameInputProcessEnvironment)engine).InputSource.Rumble(RumbleStrength.Light,
                RumbleLength.Medium);
            sprite.Play("spin");
            routine = null;
        }
    }
}
