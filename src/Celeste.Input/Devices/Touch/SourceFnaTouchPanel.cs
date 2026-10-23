using Celeste.Input.Devices.Mouse;
using Celeste.Core.Display;
using System.Numerics;
using System;
using System.Collections.Generic;

namespace Celeste.Input.Devices.Touch
{
    public class SourceFnaTouchPanel
    {
        private readonly SourceSDLMouseTouchPlatform platform;
        private readonly SourceGestureDetector detector;

        internal SourceFnaTouchPanel(SourceSDLMouseTouchPlatform platform, ISourceFnaInputClock clock,
            Celeste.Core.Mathematics.ISourceVectorArithmetic arithmetic)
        {
            this.platform = platform;
            detector = new SourceGestureDetector(this, platform, clock, arithmetic);
        }

        internal const int MAX_TOUCHES = 8;

        internal const int NO_FINGER = -1;

        public bool TouchDeviceExists;

        private Queue<SourceGestureSample> gestures = new Queue<SourceGestureSample>();

        private SourceTouchLocation[] touches = new SourceTouchLocation[8];

        private SourceTouchLocation[] prevTouches = new SourceTouchLocation[8];

        private List<SourceTouchLocation> validTouches = new List<SourceTouchLocation>();

        public int DisplayWidth { get; set; }

        public int DisplayHeight { get; set; }

        public SourceDisplayOrientation DisplayOrientation { get; set; }

        public SourceGestureType EnabledGestures { get; set; }

        public bool IsGestureAvailable => gestures.Count > 0;

        public IntPtr WindowHandle { get; set; }

        public SourceTouchPanelCapabilities GetCapabilities()
        {
            return platform.GetTouchCapabilities();
        }

        public SourceTouchCollection GetState()
        {
            validTouches.Clear();
            for (int i = 0; i < 8; i++)
            {
                if (touches[i].State != SourceTouchLocationState.Invalid)
                {
                    validTouches.Add(touches[i]);
                }
            }

            return new SourceTouchCollection(validTouches.ToArray());
        }

        public SourceGestureSample ReadGesture()
        {
            if (gestures.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return gestures.Dequeue();
        }

        internal void EnqueueGesture(SourceGestureSample gesture)
        {
            gestures.Enqueue(gesture);
        }

        internal void INTERNAL_onTouchEvent(int fingerId, SourceTouchLocationState state, float x, float y, float dx,
            float dy)
        {
            Vector2 touchPosition = new Vector2((float)Math.Round(x * (float)DisplayWidth),
                (float)Math.Round(y * (float)DisplayHeight));
            switch (state)
            {
                case SourceTouchLocationState.Pressed:
                    detector.OnPressed(fingerId, touchPosition);
                    break;
                case SourceTouchLocationState.Moved:
                {
                    Vector2 delta = new Vector2((float)Math.Round(dx * (float)DisplayWidth),
                        (float)Math.Round(dy * (float)DisplayHeight));
                    detector.OnMoved(fingerId, touchPosition, delta);
                    break;
                }
                case SourceTouchLocationState.Released:
                    detector.OnReleased(fingerId, touchPosition);
                    break;
            }
        }

        internal void SetFinger(int index, int fingerId, Vector2 fingerPos)
        {
            if (fingerId == -1)
            {
                if (prevTouches[index].State != SourceTouchLocationState.Invalid &&
                    prevTouches[index].State != SourceTouchLocationState.Released)
                {
                    touches[index] = new SourceTouchLocation(prevTouches[index].Id, SourceTouchLocationState.Released,
                        prevTouches[index].Position, prevTouches[index].State, prevTouches[index].Position);
                }
                else
                {
                    touches[index] = new SourceTouchLocation(-1, SourceTouchLocationState.Invalid, Vector2.Zero);
                }
            }
            else if (prevTouches[index].State == SourceTouchLocationState.Invalid)
            {
                touches[index] = new SourceTouchLocation(fingerId, SourceTouchLocationState.Pressed, fingerPos);
            }
            else
            {
                touches[index] = new SourceTouchLocation(fingerId, SourceTouchLocationState.Moved, fingerPos,
                    prevTouches[index].State, prevTouches[index].Position);
            }
        }

        internal void Update()
        {
            detector.OnUpdate();
            touches.CopyTo(prevTouches, 0);
            platform.UpdateTouchPanelState(this);
        }
    }
}
