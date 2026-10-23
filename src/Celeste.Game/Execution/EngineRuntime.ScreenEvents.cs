using System;
using System.Numerics;
using Celeste.Graphics.Geometry.TwoD.Camera;
using Celeste.Scene.Scenes;

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
            if (!(Window.ClientBounds.Width > 0 && Window.ClientBounds.Height > 0 && !SourceScreen.Resizing))
                return;
            SourceScreen.Resizing = true;
            Graphics.PreferredBackBufferWidth = Window.ClientBounds.Width;
            Graphics.PreferredBackBufferHeight = Window.ClientBounds.Height;
            UpdateView();
            SourceScreen.Resizing = false;
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
            if (width / Width > height / Height)
            {
                ViewWidth = (int)(height / Height * Width);
                ViewHeight = (int)height;
            }
            else
            {
                ViewWidth = (int)width;
                ViewHeight = (int)(width / Width * Height);
            }

            var ratio = ViewHeight / (float)ViewWidth;
            ViewWidth -= ViewPadding * 2;
            ViewHeight -= (int)(ratio * ViewPadding * 2f);
            var scale = ViewWidth / (float)Width;
            ScreenMatrix = new(scale, 0, 0, 0, 0, scale, 0, 0, 0, 0, scale, 0, 0, 0, 0, 1);
            Viewport = new()
            {
                X = (int)(width / 2f - ViewWidth / 2),
                Y = (int)(height / 2f - ViewHeight / 2),
                Width = ViewWidth, Height = ViewHeight, MinDepth = 0f, MaxDepth = 1f,
            };
        }
    }
}
