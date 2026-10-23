using System.Collections.Generic;
using System.IO;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Rendering.States;
using Celeste.Core.Scheduling;
using Celeste.Formats.Replay.Timelines;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Entities.Playback;
using Celeste.Game.Execution.Engine;
using Celeste.Game.Execution.Processes;
using Celeste.Graphics.Animation.Replay;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Input.Devices.Keyboard;
using Celeste.Input.Runtime;
using Celeste.Scene.Scenes;
using Celeste.Scene.Scheduling;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Player.Presentation.Sprites;
using Celeste.Simulation.Gameplay.Tutorial.Replay;

namespace Celeste.Game.Diagnostics.Scenes
{
    public class PreviewRecordingState : SourceSceneState
    {
        public string Filename;

        public List<CharacterReplayFrame> Timeline;

        public PlayerPlaybackState entity;

        public float ScreenWidth = 640f;

        public float ScreenHeight = 360f;

        public float Width;

        public float Height;

        private Matrix4x4 Matrix => SourceMatrixMath.Multiply(SourceMatrixMath.CreateScale(1920f / ScreenWidth),
            ((IOriginalEngineGraphicsEnvironment)EngineContext).EngineGraphics.ScreenMatrix);

        public PreviewRecordingState(ISourceEngineContext engine, string filename)
            : base(engine, ((ISourceSceneCatalogEnvironment)engine).SceneCatalog,
                ((ISourceSceneUpdatePolicyEnvironment)engine).PlainScenePolicy)
        {
            Filename = filename;
            var buffer = ReadRecordingBytes(filename);
            Timeline = PlaybackTimelineCodec.Import(buffer);
            var num = float.MaxValue;
            var num2 = float.MinValue;
            var num3 = float.MinValue;
            var num4 = float.MaxValue;
            foreach (var item in Timeline)
            {
                num = ((ISourceExtremaEnvironment)EngineContext).ExtremaArithmetic.Min(item.Position.X, num);
                num2 = ((ISourceExtremaEnvironment)EngineContext).ExtremaArithmetic.Max(item.Position.X, num2);
                num4 = ((ISourceExtremaEnvironment)EngineContext).ExtremaArithmetic.Min(item.Position.Y, num4);
                num3 = ((ISourceExtremaEnvironment)EngineContext).ExtremaArithmetic.Max(item.Position.Y, num3);
            }

            Width = (int)(num2 - num);
            Height = (int)(num3 - num4);
            SourceScene.QueueSourceEntity(entity = new(engine,
                new((ScreenWidth - Width) / 2f - num, (ScreenHeight - Height) / 2f - num4),
                PlayerSpriteMode.Madeline, Timeline,
                new OriginalPlayerPlaybackAudio(((IOriginalGameplayProcess)engine).AudioSession,
                    ((IOriginalGameplayProcess)engine).SaveContext)));
        }

        protected virtual byte[] ReadRecordingBytes(string filename)
        {
            return File.ReadAllBytes(filename);
        }

        protected virtual PreviewRecordingState CreateNextPreview(string filename)
        {
            return new(EngineContext, filename);
        }

        public override void Update()
        {
            if (((ISourceMInputEnvironment)EngineContext).MInput.Keyboard.Check(SourceKeys.A))
                entity.TrimStart =
                    ((ISourceExtremaEnvironment)EngineContext).ExtremaArithmetic.Max(0f,
                        entity.TrimStart -= EngineContext.Frame.DeltaTime);

            if (((ISourceMInputEnvironment)EngineContext).MInput.Keyboard.Check(SourceKeys.D))
                entity.TrimStart = ((ISourceExtremaEnvironment)EngineContext).ExtremaArithmetic.Min(entity.Duration,
                    entity.TrimStart += EngineContext.Frame.DeltaTime);

            if (((ISourceMInputEnvironment)EngineContext).MInput.Keyboard.Check(SourceKeys.Left))
                entity.TrimEnd =
                    ((ISourceExtremaEnvironment)EngineContext).ExtremaArithmetic.Max(0f,
                        entity.TrimEnd -= EngineContext.Frame.DeltaTime);

            if (((ISourceMInputEnvironment)EngineContext).MInput.Keyboard.Check(SourceKeys.Right))
                entity.TrimEnd = ((ISourceExtremaEnvironment)EngineContext).ExtremaArithmetic.Min(entity.Duration,
                    entity.TrimEnd += EngineContext.Frame.DeltaTime);

            if (((ISourceMInputEnvironment)EngineContext).MInput.Keyboard.Check(SourceKeys.LeftControl) &&
                ((ISourceMInputEnvironment)EngineContext).MInput.Keyboard.Pressed(SourceKeys.S))
            {
                while (Timeline[0].TimeStamp < entity.TrimStart) Timeline.RemoveAt(0);

                while (Timeline[Timeline.Count - 1].TimeStamp > entity.TrimEnd) Timeline.RemoveAt(Timeline.Count - 1);

                PlaybackTimelineCodec.Export(Timeline, Filename);
                EngineContext.Frame.Scenes.NextScene = CreateNextPreview(Filename);
            }

            base.Update();
            entity.Hair.AfterUpdate();
        }

        public override void Render()
        {
            ((ISourceDrawScope)EngineContext).Draw.SpriteBatch.Begin(SourceSpriteSortMode.Deferred,
                SourceBlendState.AlphaBlend, SourceSamplerState.LinearClamp, null, SourceRasterizerState.CullNone, null,
                ((IOriginalEngineGraphicsEnvironment)EngineContext).EngineGraphics.ScreenMatrix);
            ((IOriginalGameTextEnvironment)EngineContext).Text.ActiveFont.Draw(SourceRenderContext, this,
                "A/D:        Move Start Trim", new(8f, 8f), new(0f, 0f), Vector2.One * 0.5f,
                PackedColor.White);
            ((IOriginalGameTextEnvironment)EngineContext).Text.ActiveFont.Draw(SourceRenderContext, this,
                "Left/Right: Move End Trim", new(8f, 32f), new(0f, 0f), Vector2.One * 0.5f,
                PackedColor.White);
            ((IOriginalGameTextEnvironment)EngineContext).Text.ActiveFont.Draw(SourceRenderContext, this,
                "CTRL+S: Save New Trim", new(8f, 56f), new(0f, 0f), Vector2.One * 0.5f,
                PackedColor.White);
            ((ISourceDrawScope)EngineContext).Draw.SpriteBatch.End();
            ((ISourceDrawScope)EngineContext).Draw.SpriteBatch.Begin(SourceSpriteSortMode.Deferred,
                SourceBlendState.AlphaBlend, SourceSamplerState.PointClamp, null, SourceRasterizerState.CullNone, null,
                Matrix);
            SourcePrimitiveDrawing.HollowRect(SourceRenderContext, this, (ScreenWidth - Width) / 2f - 16f,
                (ScreenHeight - Height) / 2f - 16f, Width + 32f, Height + 32f, PackedColor.Red * 0.6f);
            SourcePrimitiveDrawing.HollowRect(SourceRenderContext, this, (ScreenWidth - 320f) / 2f,
                (ScreenHeight - 180f) / 2f, 320f, 180f, PackedColor.White * 0.6f);
            if (entity.Visible) entity.Render(SourceRenderContext);

            SourcePrimitiveDrawing.Rect(SourceRenderContext, this, 32f, ScreenHeight - 48f, ScreenWidth - 64f, 16f,
                PackedColor.DarkGray);
            SourcePrimitiveDrawing.Rect(SourceRenderContext, this, 32f, ScreenHeight - 48f,
                (ScreenWidth - 64f) * (entity.Time / entity.Duration), 16f, PackedColor.White);
            SourcePrimitiveDrawing.Rect(SourceRenderContext, this,
                32f + (ScreenWidth - 64f) * (entity.Time / entity.Duration) - 2f, ScreenHeight - 48f, 4f, 16f,
                PackedColor.LimeGreen);
            SourcePrimitiveDrawing.Rect(SourceRenderContext, this,
                32f + (ScreenWidth - 64f) * (entity.TrimStart / entity.Duration) - 2f, ScreenHeight - 48f, 4f, 16f,
                PackedColor.Red);
            SourcePrimitiveDrawing.Rect(SourceRenderContext, this,
                32f + (ScreenWidth - 64f) * (entity.TrimEnd / entity.Duration) - 2f, ScreenHeight - 48f, 4f, 16f,
                PackedColor.Red);
            ((ISourceDrawScope)EngineContext).Draw.SpriteBatch.End();
        }
    }
}
