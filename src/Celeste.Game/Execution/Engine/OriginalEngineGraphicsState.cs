using System;
using System.Numerics;
using Celeste.Core.Rendering;
using Celeste.Simulation.Presentation.Scene.Transitions;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Geometry.TwoD.Camera;

namespace Celeste.Game.Execution.Engine
{
    public sealed class OriginalEngineGraphicsState : ISourceGraphicsContext, ISourceScreenWipeGraphicsContext
    {
        public int Width { get; }
        public int Height { get; }
        public int ViewWidth { get; private set; }
        public int ViewHeight { get; private set; }
        public CameraViewport Viewport { get; private set; }
        public Matrix4x4 ScreenMatrix;
        public object HudTarget, WipeTarget;
        Matrix4x4 ISourceGraphicsContext.ScreenMatrix => ScreenMatrix;
        object ISourceGraphicsContext.HudTarget => HudTarget;
        VirtualRenderTarget ISourceScreenWipeGraphicsContext.WipeTarget => (VirtualRenderTarget)WipeTarget;
        private int viewPadding;
        private readonly Func<int> backBufferWidth, backBufferHeight;

        public int ViewPadding
        {
            get => viewPadding;
            set
            {
                viewPadding = value;
                UpdateView();
            }
        }

        public OriginalEngineGraphicsState(int width, int height, Func<int> backBufferWidth, Func<int> backBufferHeight)
        {
            Width = width;
            Height = height;
            this.backBufferWidth = backBufferWidth ?? throw new ArgumentNullException(nameof(backBufferWidth));
            this.backBufferHeight = backBufferHeight ?? throw new ArgumentNullException(nameof(backBufferHeight));
        }

        public void UpdateView()
        {
            float width = backBufferWidth();
            float height = backBufferHeight();
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
                Width = ViewWidth,
                Height = ViewHeight,
                MinDepth = 0f,
                MaxDepth = 1f
            };
        }
    }
}
