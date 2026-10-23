using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Xml;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Core.Scheduling;
using Celeste.Core.Serialization.Xml;
using Celeste.Game.Controls.Source;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Presentation.Hud;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Graphics.Rendering.Textures;
using Celeste.Simulation.Presentation.Rendering;

namespace Celeste.Game.Presentation.Completion
{
    public class CompleteRendererState : HiresRendererState, IDisposable
    {
        protected readonly ISourceEngineContext engine;
        protected OriginalGameInputProcess Input => ((IOriginalGameInputProcessEnvironment)engine).InputSource;
        protected ISourceVectorArithmetic Vector => ((ISourceVectorEnvironment)engine).VectorArithmetic;
        protected ISourceScalarArithmetic Scalar => ((ISourceScalarEnvironment)engine).ScalarArithmetic;

        public abstract class Layer
        {
            protected readonly ISourceEngineContext engine;
            public Vector2 Position;

            public Vector2 ScrollFactor;

            public Layer(ISourceEngineContext engine, XmlElement xml)
            {
                this.engine = engine;
                Position = XmlPosition(xml, Vector2.Zero);
                if (xml.HasAttr("scroll"))
                {
                    ScrollFactor.X = ScrollFactor.Y = xml.AttrFloat("scroll");
                    return;
                }

                ScrollFactor.X = xml.AttrFloat("scrollX", 0f);
                ScrollFactor.Y = xml.AttrFloat("scrollY", 0f);
            }

            public virtual void Update(object scene)
            {
            }

            public abstract void Render(ISourceRenderContext context, Vector2 scroll);

            public Vector2 GetScrollPosition(Vector2 scroll)
            {
                var position = Position;
                if (ScrollFactor != Vector2.Zero)
                {
                    position.X =
                        ((ISourceScalarEnvironment)engine).ScalarArithmetic.Lerp(Position.X, Position.X + scroll.X,
                            ScrollFactor.X);
                    position.Y =
                        ((ISourceScalarEnvironment)engine).ScalarArithmetic.Lerp(Position.Y, Position.Y + scroll.Y,
                            ScrollFactor.Y);
                }

                return position;
            }
        }

        public class UILayer : Layer
        {
            private readonly CompleteRendererState renderer;

            public UILayer(CompleteRendererState renderer, XmlElement xml)
                : base(renderer.engine, xml)
            {
                this.renderer = renderer;
            }

            public override void Render(ISourceRenderContext context, Vector2 scroll)
            {
                if (renderer.RenderUI != null) renderer.RenderUI(context, scroll);
            }
        }

        public class ImageLayer : Layer
        {
            public List<AtlasEntry> Images = [];

            public float Frame;

            public float FrameRate;

            public float Alpha;

            public Vector2 Offset;

            protected virtual int ReadImageIndex()
            {
                return (int)(Frame % Images.Count);
            }

            protected virtual SourceTexture2DResource ReadTexture(AtlasEntry entry)
            {
                return entry.Texture.TextureSafe;
            }

            public Vector2 Speed;

            public float Scale;

            public ImageLayer(ISourceEngineContext engine, Vector2 offset, AtlasData atlas, XmlElement xml)
                : base(engine, xml)
            {
                Position += offset;
                var array = xml.Attr("img").Split(',');
                foreach (var id in array)
                    if (atlas.Has(id))
                        Images.Add(atlas[id]);
                    else
                        Images.Add(null);

                FrameRate = xml.AttrFloat("fps", 6f);
                Alpha = xml.AttrFloat("alpha", 1f);
                Speed = new(xml.AttrFloat("speedx", 0f), xml.AttrFloat("speedy", 0f));
                Scale = xml.AttrFloat("scale", 1f);
            }

            public override void Update(object scene)
            {
                Frame += engine.DeltaTime * FrameRate;
                Offset += Speed * engine.DeltaTime;
            }

            public override void Render(ISourceRenderContext context, Vector2 scroll)
            {
                var position = Floor(GetScrollPosition(scroll));
                var mTexture = Images[ReadImageIndex()];
                if (mTexture == null) return;

                var flag = ((IOriginalGameplayProcess)engine).SaveContext.CurrentSave != null &&
                           ((IOriginalGameplayProcess)engine).SaveContext.CurrentSave.Assists.MirrorMode;
                if (flag)
                {
                    position.X = 1920f - position.X - mTexture.DrawOffset.X * Scale -
                                 ReadTexture(mTexture).Width * Scale;
                    position.Y += mTexture.DrawOffset.Y * Scale;
                }
                else
                {
                    position += mTexture.DrawOffset * Scale;
                }

                var value = mTexture.ClipRect;
                int num;
                if (Offset.X == 0f)
                {
                    num = Offset.Y != 0f ? 1 : 0;
                    if (num == 0) goto IL_015b;
                }
                else
                {
                    num = 1;
                }

                value = new((int)((0f - Offset.X) / Scale) + 1, (int)((0f - Offset.Y) / Scale) + 1,
                    mTexture.ClipRect.Width - 2, mTexture.ClipRect.Height - 2);
                EndRender(context);
                OriginalHiresRendererBatch.BeginRender(context, SourceBlendState.AlphaBlend,
                    SourceSamplerState.LinearWrap);
                IL_015b:
                ((ISourceDrawScope)context).Draw.SpriteBatch.Draw(ReadTexture(mTexture), position, value,
                    (PackedColor.White * Alpha).PackedValue, 0f, Vector2.Zero, Scale,
                    flag ? SourceSpriteEffects.FlipHorizontally : SourceSpriteEffects.None, 0f);
                if (num != 0)
                {
                    EndRender(context);
                    OriginalHiresRendererBatch.BeginRender(context, SourceBlendState.AlphaBlend,
                        SourceSamplerState.LinearClamp);
                }
            }
        }

        private const float ScrollRange = 200f;

        private const float ScrollSpeed = 600f;

        private readonly AtlasData atlas;

        private XmlElement xml;

        private float fadeAlpha = 1f;

        private readonly SimulationCoroutine routine;

        private Vector2 controlScroll;

        private float controlMult;

        public float SlideDuration = 1.5f;

        public List<Layer> Layers = [];

        public Vector2 Scroll;

        public Vector2 StartScroll;

        public Vector2 CenterScroll;

        public Vector2 Offset;

        public float Scale;

        public Action<ISourceRenderContext, Vector2> RenderUI;

        public Action<ISourceRenderContext> RenderPostUI;

        public bool HasUI { get; protected set; }

        public CompleteRendererState(ISourceEngineContext engine, XmlElement xml, AtlasData atlas, float delay,
            Action onDoneSlide = null)
            : base(1920, 1080)
        {
            this.engine = engine;
            this.atlas = atlas;
            this.xml = xml;
            if (xml != null)
            {
                if (xml["start"] != null) StartScroll = XmlPosition(xml["start"]);

                if (xml["center"] != null) CenterScroll = XmlPosition(xml["center"]);

                if (xml["offset"] != null) Offset = XmlPosition(xml["offset"]);

                foreach (var item in xml["layers"])
                    if (item is XmlElement)
                    {
                        var xmlElement = item as XmlElement;
                        if (xmlElement.Name == "layer")
                        {
                            Layers.Add(CreateImageLayer(Offset, atlas, xmlElement));
                        }
                        else if (xmlElement.Name == "ui")
                        {
                            HasUI = true;
                            Layers.Add(new UILayer(this, xmlElement));
                        }
                    }
            }

            Scroll = StartScroll;
            routine = new(engine, SlideRoutine(delay, onDoneSlide));
        }

        public void Dispose()
        {
            if (atlas != null) atlas.Dispose();
        }

        private IEnumerator SlideRoutine(float delay, Action onDoneSlide)
        {
            yield return delay;
            for (var p = 0f; p < 1f; p += engine.DeltaTime / SlideDuration)
            {
                yield return null;
                Scroll = Lerp(StartScroll, CenterScroll,
                    ((ISourceEasingEnvironment)engine).EasingArithmetic.SineOut(p));
                fadeAlpha = ScalarMath.LerpClamp(1f, 0f, p * 2f, Scalar);
            }

            Scroll = CenterScroll;
            fadeAlpha = 0f;
            yield return 0.2f;
            onDoneSlide?.Invoke();
            while (true)
            {
                controlMult = ScalarMath.Approach(controlMult, 1f, 5f * engine.DeltaTime,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                yield return null;
            }
        }

        public override void Update(object scene)
        {
            var value = Input.Aim.Value;
            value += Input.MountainAim.Value;
            if (Vector.Length(value) > 1f) value = Vector.Normalize(value);

            value *= 200f;
            controlScroll = Vector.Approach(controlScroll, value, 600f * engine.DeltaTime);
            foreach (var layer in Layers) layer.Update(scene);

            routine.Update();
        }

        public override void RenderContent(object scene, ISourceRenderContext context)
        {
            OriginalHiresRendererBatch.BeginRender(context, SourceBlendState.AlphaBlend,
                SourceSamplerState.LinearClamp);
            foreach (var layer in Layers) layer.Render(context, -Scroll - controlScroll * controlMult);

            if (RenderPostUI != null) RenderPostUI(context);

            if (fadeAlpha > 0f)
                SourcePrimitiveDrawing.Rect(context, this, -10f, -10f, 1920 + 20, 1080 + 20,
                    PackedColor.Black * fadeAlpha);

            EndRender(context);
        }

        protected virtual ImageLayer CreateImageLayer(Vector2 offset, AtlasData atlas, XmlElement xml)
        {
            return new(engine, offset, atlas, xml);
        }

        private Vector2 Lerp(Vector2 first, Vector2 second, float amount)
        {
            return new(Scalar.Lerp(first.X, second.X, amount), Scalar.Lerp(first.Y, second.Y, amount));
        }

        private static Vector2 Floor(Vector2 value)
        {
            return new((float)Math.Floor(value.X), (float)Math.Floor(value.Y));
        }

        protected static Vector2 XmlPosition(XmlElement xml)
        {
            return new(xml.AttrFloat("x"), xml.AttrFloat("y"));
        }

        protected static Vector2 XmlPosition(XmlElement xml, Vector2 fallback)
        {
            return new(xml.AttrFloat("x", fallback.X), xml.AttrFloat("y", fallback.Y));
        }
    }
}
