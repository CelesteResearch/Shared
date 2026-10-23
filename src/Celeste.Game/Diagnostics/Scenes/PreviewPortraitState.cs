using Celeste.Input.Runtime;
using Celeste.Input.Devices.Keyboard;
using Celeste.Core.Display;
using System.Collections.Generic;
using System.Xml;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Rendering.States;
using Celeste.Scene.Scenes;
using Celeste.Scene.Tracking;
using Celeste.Scene.Scheduling;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Xml;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Formats.Graphics.Sprites;
using Celeste.Formats.Graphics.Xml;
using Celeste.Game.Execution.Engine;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Content.Dialogs;
using global::Celeste.Game.Execution;

namespace Celeste.Game.Diagnostics.Scenes
{
    public class PreviewPortraitState : SourceSceneState
    {
        private Sprite animation;

        private List<string> options = new List<string>();

        private List<string> animations = new List<string>();

        private Vector2 topleft = new Vector2(64f, 64f);

        private string currentPortrait;

        public Vector2 Mouse => SourceVector2Math.Transform(
            new Vector2(((ISourceMInputEnvironment)EngineContext).MInput.Mouse.CurrentState.X,
                ((ISourceMInputEnvironment)EngineContext).MInput.Mouse.CurrentState.Y),
            SourceMatrixMath.Invert(((IOriginalEngineGraphicsEnvironment)EngineContext).EngineGraphics.ScreenMatrix));

        public PreviewPortraitState(ISourceEngineContext engine, float scroll = 64f)
            : base(engine, ((ISourceSceneCatalogEnvironment)engine).SceneCatalog,
                ((ISourceSceneUpdatePolicyEnvironment)engine).PlainScenePolicy)
        {
            foreach (KeyValuePair<string, SpriteData> spriteDatum in
                     ((OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)EngineContext).GameGraphics)
                     .PortraitsSpriteBank.SpriteData)
            {
                if (spriteDatum.Key.StartsWith("portrait"))
                {
                    options.Add(spriteDatum.Key);
                }
            }

            topleft.Y = scroll;
        }

        public override void Update()
        {
            if (animation != null)
            {
                animation.Update();
                if (((ISourceMInputEnvironment)EngineContext).MInput.Mouse.PressedLeftButton)
                {
                    for (int i = 0; i < animations.Count; i++)
                    {
                        if (MouseOverOption(i))
                        {
                            if (i == 0)
                            {
                                animation = null;
                            }
                            else
                            {
                                animation.Play(animations[i]);
                            }

                            break;
                        }
                    }
                }
            }
            else if (((ISourceMInputEnvironment)EngineContext).MInput.Mouse.PressedLeftButton)
            {
                for (int j = 0; j < options.Count; j++)
                {
                    if (!MouseOverOption(j))
                    {
                        continue;
                    }

                    currentPortrait = options[j].Split('_')[1];
                    animation =
                        ((OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)EngineContext).GameGraphics)
                        .PortraitsSpriteBank.Create(options[j]);
                    animations.Clear();
                    animations.Add("<-BACK");
                    XmlElement xML =
                        ((OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)EngineContext).GameGraphics)
                        .PortraitsSpriteBank.SpriteData[options[j]].Sources[0].XML;
                    foreach (XmlElement item in xML.GetElementsByTagName("Anim"))
                    {
                        animations.Add(item.Attr("id"));
                    }

                    foreach (XmlElement item2 in xML.GetElementsByTagName("Loop"))
                    {
                        animations.Add(item2.Attr("id"));
                    }

                    break;
                }
            }

            topleft.Y += (float)((ISourceMInputEnvironment)EngineContext).MInput.Mouse.WheelDelta *
                         EngineContext.Frame.DeltaTime *
                         ((IOriginalGameTextEnvironment)EngineContext).Text.ActiveFont.LineHeight;
            if (((ISourceMInputEnvironment)EngineContext).MInput.Keyboard.Pressed(SourceKeys.F1))
            {
                GameRuntime.ReloadPortraits();
                EngineContext.Frame.Scenes.NextScene = new PreviewPortraitState(EngineContext, topleft.Y);
            }
        }

        public override void Render()
        {
            ((ISourceDrawScope)EngineContext).Draw.SpriteBatch.Begin(SourceSpriteSortMode.Deferred,
                SourceBlendState.AlphaBlend, SourceSamplerState.LinearClamp, null, SourceRasterizerState.CullNone, null,
                ((IOriginalEngineGraphicsEnvironment)EngineContext).EngineGraphics.ScreenMatrix);
            SourcePrimitiveDrawing.Rect(SourceRenderContext, this, 0f, 0f, 960f, 1080f,
                PackedColor.DarkSlateGray * 0.25f);
            if (animation != null)
            {
                animation.Scale = Vector2.One;
                animation.Position = new Vector2(1440f, 540f);
                animation.Render(SourceRenderContext);
                int num = 0;
                foreach (string animation in animations)
                {
                    PackedColor color = PackedColor.Gray;
                    if (MouseOverOption(num))
                    {
                        color = PackedColor.White;
                    }
                    else if (this.animation.CurrentAnimationID == animation)
                    {
                        color = PackedColor.Yellow;
                    }

                    ((IOriginalGameTextEnvironment)EngineContext).Text.ActiveFont.Draw(SourceRenderContext, this,
                        animation,
                        topleft + new Vector2(0f,
                            (float)num * ((IOriginalGameTextEnvironment)EngineContext).Text.ActiveFont.LineHeight),
                        Vector2.Zero, Vector2.One, color);
                    num++;
                }

                if (!string.IsNullOrEmpty(this.animation.CurrentAnimationID))
                {
                    string[] array = this.animation.CurrentAnimationID.Split('_');
                    if (array.Length > 1)
                    {
                        ((IOriginalGameTextEnvironment)EngineContext).Text.ActiveFont.Draw(SourceRenderContext, this,
                            currentPortrait + " " + array[1], new Vector2(1440f, 1016f), new Vector2(0.5f, 1f),
                            Vector2.One,
                            PackedColor.White);
                    }
                }
            }
            else
            {
                int num2 = 0;
                foreach (string option in options)
                {
                    ((IOriginalGameTextEnvironment)EngineContext).Text.ActiveFont.Draw(SourceRenderContext, this,
                        option,
                        topleft + new Vector2(0f,
                            (float)num2 * ((IOriginalGameTextEnvironment)EngineContext).Text.ActiveFont.LineHeight),
                        Vector2.Zero, Vector2.One, MouseOverOption(num2) ? PackedColor.White : PackedColor.Gray);
                    num2++;
                }
            }

            SourcePrimitiveDrawing.Rect(SourceRenderContext, this, Mouse.X - 12f, Mouse.Y - 4f, 24f, 8f,
                PackedColor.Red);
            SourcePrimitiveDrawing.Rect(SourceRenderContext, this, Mouse.X - 4f, Mouse.Y - 12f, 8f, 24f,
                PackedColor.Red);
            ((ISourceDrawScope)EngineContext).Draw.SpriteBatch.End();
        }

        private bool MouseOverOption(int i)
        {
            if (Mouse.X > topleft.X &&
                Mouse.Y > topleft.Y +
                (float)i * ((IOriginalGameTextEnvironment)EngineContext).Text.ActiveFont.LineHeight &&
                ((ISourceMInputEnvironment)EngineContext).MInput.Mouse.X < 960f)
            {
                return Mouse.Y < topleft.Y +
                    (float)(i + 1) * ((IOriginalGameTextEnvironment)EngineContext).Text.ActiveFont.LineHeight;
            }

            return false;
        }
    }
}
