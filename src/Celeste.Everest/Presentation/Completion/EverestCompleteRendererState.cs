using System;
using System.Numerics;
using System.Xml;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Core.Serialization.Xml;
using Celeste.Everest.Content.Atlases;
using Celeste.Everest.Content.Maps.Metadata.Completion;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Game.Presentation.Completion;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Everest.Presentation.Completion
{
    public class EverestCompleteRendererState : CompleteRendererState
    {
        private MapMetaCompleteScreen meta;
        private static XmlElement _FakeXML;

        public static XmlElement FakeXML
        {
            get
            {
                if (_FakeXML != null) return _FakeXML;
                _FakeXML = new XmlDocument().CreateElement("layer");
                _FakeXML.SetAttribute("img", "");
                return _FakeXML;
            }
        }

        public class InstalledImageLayer : ImageLayer
        {
            public bool Loop;
            private bool loopDone;

            public InstalledImageLayer(ISourceEngineContext engine, Vector2 offset, AtlasData atlas, XmlElement xml)
                : base(engine, offset, atlas, xml)
            {
                Loop = xml.AttrBool("loop", true);
            }

            protected override SourceTexture2DResource ReadTexture(AtlasEntry entry)
            {
                return entry.ReadTextureForSpriteBatch();
            }

            protected override int ReadImageIndex()
            {
                return ImageIndex;
            }

            public int ImageIndex
            {
                get
                {
                    if (Loop) return (int)(Frame % Images.Count);
                    if (loopDone) return Images.Count - 1;
                    var num = (int)(Frame % Images.Count);
                    if (num == Images.Count - 1) loopDone = true;
                    return num;
                }
            }
        }

        public abstract class LayerNoXML : Layer
        {
            protected LayerNoXML(ISourceEngineContext engine, MapMetaCompleteScreenLayer meta)
                : base(engine, FakeXML)
            {
                Position = meta.Position;
                ScrollFactor = meta.Scroll;
            }
        }

        public class UILayerNoXML : UILayer
        {
            private readonly CompleteRendererState renderer;

            public UILayerNoXML(CompleteRendererState renderer, MapMetaCompleteScreenLayer meta)
                : base(renderer, FakeXML)
            {
                Position = meta.Position;
                ScrollFactor = meta.Scroll;
                this.renderer = renderer;
            }

            public override void Render(ISourceRenderContext context, Vector2 scroll)
            {
                renderer?.RenderUI(context, scroll);
            }
        }

        public class ImageLayerNoXML : InstalledImageLayer
        {
            public ImageLayerNoXML(ISourceEngineContext engine, Vector2 offset, AtlasData atlas,
                MapMetaCompleteScreenLayer meta)
                : base(engine, offset, atlas, FakeXML)
            {
                Position = meta.Position + offset;
                ScrollFactor = meta.Scroll;
                Images.Clear();
                foreach (var text in meta.Images)
                {
                    if (atlas.Has(text))
                    {
                        Images.Add(atlas[text]);
                        continue;
                    }

                    ((IEverestLoggerProcessEnvironment)engine).Logger.Log(EverestLogLevel.Warn, "Atlas",
                        $"Requested CompleteScreen texture that does not exist: {((EverestAtlasData)atlas).DataPath.Substring(17)}/{text}");
                    Images.Add(null);
                }

                FrameRate = meta.FrameRate;
                Alpha = meta.Alpha;
                Speed = meta.Speed;
                Scale = meta.Scale;
                Loop = meta.Loop;
            }
        }

        protected override ImageLayer CreateImageLayer(Vector2 offset, AtlasData atlas, XmlElement xml)
        {
            return new InstalledImageLayer(engine, offset, atlas, xml);
        }

        public EverestCompleteRendererState(ISourceEngineContext engine, XmlElement xml, AtlasData atlas,
            float delay, Action onDoneSlide = null, MapMetaCompleteScreen meta = null)
            : base(engine, xml, atlas, delay, onDoneSlide)
        {
            this.meta = meta;
            if (meta == null) return;
            StartScroll = meta.Start;
            CenterScroll = meta.Center;
            Offset = meta.Offset;
            Layers.Clear();
            if (meta.Layers == null || meta.Layers.Length == 0) return;
            foreach (var layer in meta.Layers)
                if (!string.IsNullOrEmpty(layer.Type) &&
                    layer.Type.Equals("ui", StringComparison.CurrentCultureIgnoreCase))
                {
                    HasUI = true;
                    Layers.Add(new UILayerNoXML(this, layer));
                }
                else
                {
                    Layers.Add(new ImageLayerNoXML(engine, Offset, atlas, layer));
                }
        }
    }
}
