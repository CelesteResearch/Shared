using System;
using System.Numerics;
using Celeste.Scene.Scenes;
using Celeste.Graphics.Geometry.TwoD.Camera;
using global::Celeste.Game.Execution.Engine;
using global::Celeste.Game.Execution;

namespace Celeste.Game.Execution
{
    public partial class EngineRuntime
    {
        private static int viewPadding;

        public static int ViewWidth { get; private set; }
        public static int ViewHeight { get; private set; }
        public static Matrix4x4 ScreenMatrix;
        public static CameraViewport Viewport { get; private set; }

        public static int ViewPadding
        {
            get => viewPadding;
            set
            {
                viewPadding = value;
                Instance.UpdateView();
            }
        }

        private SourceSceneState scene => (SourceSceneState)Process.Frame.Scenes.CurrentScene;
        private SourceSceneState nextScene => (SourceSceneState)Process.Frame.Scenes.NextScene;

        protected virtual void OnClientSizeChanged(object sender, EventArgs args)
        {
            if (Window.ClientBounds.Width > 0 && Window.ClientBounds.Height > 0 && !SourceScreen.Resizing)
            {
                SourceScreen.Resizing = true;
                Graphics.PreferredBackBufferWidth = Window.ClientBounds.Width;
                Graphics.PreferredBackBufferHeight = Window.ClientBounds.Height;
                UpdateView();
                SourceScreen.Resizing = false;
            }
        }

        protected virtual void OnGraphicsReset(object sender, EventArgs args)
        {
            UpdateView();
            if (scene != null) scene.HandleGraphicsReset();
            if (nextScene != null && nextScene != scene) nextScene.HandleGraphicsReset();
        }

        protected virtual void OnGraphicsCreate(object sender, EventArgs args)
        {
            UpdateView();
            if (scene != null) scene.HandleGraphicsCreate();
            if (nextScene != null && nextScene != scene) nextScene.HandleGraphicsCreate();
        }

        private void UpdateView()
        {
            float width = Graphics.GraphicsDevice.PresentationParameters.BackBufferWidth;
            float height = Graphics.GraphicsDevice.PresentationParameters.BackBufferHeight;
            if (width / (float)Width > height / (float)Height)
            {
                ViewWidth = (int)(height / (float)Height * (float)Width);
                ViewHeight = (int)height;
            }
            else
            {
                ViewWidth = (int)width;
                ViewHeight = (int)(width / (float)Width * (float)Height);
            }

            float ratio = (float)ViewHeight / (float)ViewWidth;
            ViewWidth -= ViewPadding * 2;
            ViewHeight -= (int)(ratio * (float)ViewPadding * 2f);
            float scale = (float)ViewWidth / (float)Width;
            ScreenMatrix = new Matrix4x4(scale, 0, 0, 0, 0, scale, 0, 0, 0, 0, scale, 0, 0, 0, 0, 1);
            Viewport = new CameraViewport
            {
                X = (int)(width / 2f - (float)(ViewWidth / 2)),
                Y = (int)(height / 2f - (float)(ViewHeight / 2)),
                Width = ViewWidth, Height = ViewHeight, MinDepth = 0f, MaxDepth = 1f
            };
        }
    }
}
