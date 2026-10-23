using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Presentation.Mountain.Policies;
using Celeste.Game.Presentation.Mountain.Rendering;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Geometry.ThreeD.Billboards;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Entities;

namespace Celeste.Game.Presentation.Mountain.Characters
{
    public sealed class Maddy3DState : SceneEntityState, ISourceEngineContextEntity
    {
        public MountainRendererState Renderer;
        public BillboardState Image;
        public WigglerComponent Wiggler;
        public Vector2 Scale = Vector2.One;
        public new Vector3 Position;
        public bool Show = true;
        public bool Disabled;
        private List<AtlasEntry> frames;
        private float frame, frameSpeed, alpha = 1f;
        private int hideDown;

        private bool running;

        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        public bool IsRunning => running;
        private readonly ISourceEngineContext engine;
        ISourceEngineContext ISourceEngineContextEntity.EngineContext => engine;

        public Maddy3DState(MountainRendererState renderer)
            : base(((ISourceEntitySourceDataEnvironment)renderer.EngineContext).EntitySourceDataRegistration)
        {
            engine = renderer.EngineContext;
            Renderer = renderer;
            Add(Image = new(null, Vector3.Zero));
            Image.BeforeRender = delegate
            {
                if (Disabled)
                {
                    Image.Color = PackedColor.Transparent;
                }
                else
                {
                    Image.Position = Position + hideDown * Vector3.UnitY *
                        (1f - ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeOut(alpha)) * .25f;
                    Image.Scale = Scale + Vector2.One * Wiggler.Value * Scale * .2f;
                    Image.Scale *= ((ISourceVectorEnvironment)engine).VectorArithmetic.Length(
                        Renderer.Model.Camera.Position - Position) / 20f;
                    Image.Color = PackedColor.White * alpha;
                }
            };
            Add(Wiggler = ((ISourceWigglerPoolScope)engine).WigglerPool.Create(.5f, 3f));
            Running(renderer.Area < 7);
        }

        public void Running(bool backpack = true)
        {
            running = true;
            Show = true;
            hideDown = -1;
            SetRunAnim();
            frameSpeed = 8f;
            frame = 0f;
            Image.Size = ((ISourceVectorEnvironment)engine).VectorArithmetic.Divide(
                new Vector2(frames[0].ClipRect.Width, frames[0].ClipRect.Height), frames[0].ClipRect.Width);
        }

        public void Falling()
        {
            running = false;
            Show = true;
            hideDown = -1;
            frames =
                ((IOriginalMountainEnvironment)engine).MountainResources.Mountain.GetAtlasSubtextures("marker/Fall");
            frameSpeed = 2f;
            frame = 0f;
            Image.Size = ((ISourceVectorEnvironment)engine).VectorArithmetic.Divide(
                new Vector2(frames[0].ClipRect.Width, frames[0].ClipRect.Height), frames[0].ClipRect.Width);
        }

        public void Hide(bool down = true)
        {
            running = false;
            Show = false;
            hideDown = !down ? 1 : -1;
        }

        private void SetRunAnim()
        {
            frames = ((IOriginalMountainPresentationEnvironment)engine)
                .MountainPresentationPolicy.GetMaddyRunFrames(Renderer);
        }

        public override void Update()
        {
            base.Update();
            if (IsRunning) SetRunAnim();
            if (frames != null && frames.Count > 0)
            {
                frame += engine.DeltaTime * frameSpeed;
                if (frame >= frames.Count) frame -= frames.Count;
                Image.Texture = frames[(int)frame];
            }

            alpha = ScalarMath.Approach(alpha, Show ? 1 : 0, engine.DeltaTime * 4f,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
        }
    }
}
