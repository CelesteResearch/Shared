using Celeste.Input.Devices.Mouse;
using System.Numerics;
using System;
using System.Collections.Generic;

namespace Celeste.Input.Devices.Touch
{
    internal class SourceGestureDetector
    {
        private readonly SourceFnaTouchPanel panel;
        private readonly SourceSDLMouseTouchPlatform platform;
        private readonly ISourceFnaInputClock clock;
        private readonly Celeste.Core.Mathematics.ISourceVectorArithmetic arithmetic;

        internal SourceGestureDetector(SourceFnaTouchPanel panel, SourceSDLMouseTouchPlatform platform,
            ISourceFnaInputClock clock, Celeste.Core.Mathematics.ISourceVectorArithmetic arithmetic)
        {
            this.panel = panel;
            this.platform = platform;
            this.clock = clock;
            this.arithmetic = arithmetic;
        }

        private enum GestureState
        {
            NONE,
            HOLDING,
            HELD,
            JUST_TAPPED,
            DRAGGING_FREE,
            DRAGGING_H,
            DRAGGING_V,
            PINCHING
        }

        private int activeFingerId = -1;

        private Vector2 activeFingerPosition;

        private bool callBelatedPinchComplete = false;

        private DateTime eventTimestamp;

        private List<int> fingerIds = new List<int>();

        private bool justDoubleTapped = false;

        private Vector2 lastUpdatePosition;

        private Vector2 pressPosition;

        private int secondFingerId = -1;

        private Vector2 secondFingerPosition;

        private GestureState state = GestureState.NONE;

        private DateTime updateTimestamp;

        private Vector2 velocity;

        private const int MOVE_THRESHOLD = 35;

        private const int MIN_FLICK_VELOCITY = 100;

        internal void OnPressed(int fingerId, Vector2 touchPosition)
        {
            fingerIds.Add(fingerId);
            if (state == GestureState.PINCHING)
            {
                return;
            }

            if (activeFingerId == -1)
            {
                activeFingerId = fingerId;
                activeFingerPosition = touchPosition;
                if (state == GestureState.JUST_TAPPED && IsGestureEnabled(SourceGestureType.DoubleTap) &&
                    clock.Now - eventTimestamp <= TimeSpan.FromMilliseconds(300.0) &&
                    arithmetic.Length(touchPosition - pressPosition) <= 35f)
                {
                    panel.EnqueueGesture(new SourceGestureSample(SourceGestureType.DoubleTap, GetGestureTimestamp(),
                        touchPosition, Vector2.Zero, Vector2.Zero, Vector2.Zero, fingerId, -1));
                    justDoubleTapped = true;
                }

                state = GestureState.HOLDING;
                pressPosition = touchPosition;
                eventTimestamp = clock.Now;
            }
            else if (IsGestureEnabled(SourceGestureType.Pinch))
            {
                secondFingerId = fingerId;
                secondFingerPosition = touchPosition;
                state = GestureState.PINCHING;
            }
        }

        internal void OnReleased(int fingerId, Vector2 touchPosition)
        {
            fingerIds.Remove(fingerId);
            if (state == GestureState.PINCHING)
            {
                OnReleased_Pinch(fingerId, touchPosition);
                return;
            }

            if (fingerId == activeFingerId)
            {
                activeFingerId = -1;
            }

            if (platform.GetNumTouchFingers() > 0)
            {
                return;
            }

            if (state == GestureState.HOLDING)
            {
                bool flag = IsGestureEnabled(SourceGestureType.Tap);
                bool flag2 = IsGestureEnabled(SourceGestureType.DoubleTap);
                if ((flag || flag2) && clock.Now - eventTimestamp < TimeSpan.FromSeconds(1.0) && !justDoubleTapped)
                {
                    if (flag)
                    {
                        panel.EnqueueGesture(new SourceGestureSample(SourceGestureType.Tap, GetGestureTimestamp(),
                            touchPosition, Vector2.Zero, Vector2.Zero, Vector2.Zero, fingerId, -1));
                    }

                    state = GestureState.JUST_TAPPED;
                }
            }

            justDoubleTapped = false;
            if (IsGestureEnabled(SourceGestureType.Flick))
            {
                if (arithmetic.Length(touchPosition - pressPosition) > 35f && arithmetic.Length(velocity) >= 100f)
                {
                    panel.EnqueueGesture(new SourceGestureSample(SourceGestureType.Flick, GetGestureTimestamp(),
                        Vector2.Zero, Vector2.Zero, velocity, Vector2.Zero, fingerId, -1));
                }

                velocity = Vector2.Zero;
                lastUpdatePosition = Vector2.Zero;
                updateTimestamp = DateTime.MinValue;
            }

            if (IsGestureEnabled(SourceGestureType.DragComplete) && (state == GestureState.DRAGGING_H ||
                                                                     state == GestureState.DRAGGING_V ||
                                                                     state == GestureState.DRAGGING_FREE))
            {
                panel.EnqueueGesture(new SourceGestureSample(SourceGestureType.DragComplete, GetGestureTimestamp(),
                    Vector2.Zero, Vector2.Zero, Vector2.Zero, Vector2.Zero, fingerId, -1));
            }

            if (callBelatedPinchComplete && IsGestureEnabled(SourceGestureType.PinchComplete))
            {
                panel.EnqueueGesture(new SourceGestureSample(SourceGestureType.PinchComplete, GetGestureTimestamp(),
                    Vector2.Zero, Vector2.Zero, Vector2.Zero, Vector2.Zero, -1, -1));
            }

            callBelatedPinchComplete = false;
            if (state != GestureState.JUST_TAPPED)
            {
                state = GestureState.NONE;
            }

            eventTimestamp = clock.Now;
        }

        internal void OnMoved(int fingerId, Vector2 touchPosition, Vector2 delta)
        {
            if (state == GestureState.PINCHING)
            {
                OnMoved_Pinch(fingerId, touchPosition, delta);
                return;
            }

            if (activeFingerId == -1)
            {
                activeFingerId = fingerId;
            }

            if (fingerId != activeFingerId)
            {
                return;
            }

            activeFingerPosition = touchPosition;
            bool flag = IsGestureEnabled(SourceGestureType.HorizontalDrag);
            bool flag2 = IsGestureEnabled(SourceGestureType.VerticalDrag);
            bool flag3 = IsGestureEnabled(SourceGestureType.FreeDrag);
            if ((state == GestureState.HOLDING || state == GestureState.HELD) &&
                arithmetic.Length(touchPosition - pressPosition) > 35f)
            {
                if (flag && Math.Abs(delta.X) > Math.Abs(delta.Y))
                {
                    state = GestureState.DRAGGING_H;
                }
                else if (flag2 && Math.Abs(delta.Y) > Math.Abs(delta.X))
                {
                    state = GestureState.DRAGGING_V;
                }
                else if (flag3)
                {
                    state = GestureState.DRAGGING_FREE;
                }
                else
                {
                    state = GestureState.NONE;
                }
            }

            if (state == GestureState.DRAGGING_H && flag)
            {
                panel.EnqueueGesture(new SourceGestureSample(SourceGestureType.HorizontalDrag, GetGestureTimestamp(),
                    touchPosition, Vector2.Zero, new Vector2(delta.X, 0f), Vector2.Zero, fingerId, -1));
            }
            else if (state == GestureState.DRAGGING_V && flag2)
            {
                panel.EnqueueGesture(new SourceGestureSample(SourceGestureType.VerticalDrag, GetGestureTimestamp(),
                    touchPosition, Vector2.Zero, new Vector2(0f, delta.Y), Vector2.Zero, fingerId, -1));
            }
            else if (state == GestureState.DRAGGING_FREE && flag3)
            {
                panel.EnqueueGesture(new SourceGestureSample(SourceGestureType.FreeDrag, GetGestureTimestamp(),
                    touchPosition, Vector2.Zero, delta, Vector2.Zero, fingerId, -1));
            }

            if ((state == GestureState.DRAGGING_H && !flag) || (state == GestureState.DRAGGING_V && !flag2) ||
                (state == GestureState.DRAGGING_FREE && !flag3))
            {
                state = GestureState.HELD;
            }
        }

        internal void OnUpdate()
        {
            if (state == GestureState.PINCHING)
            {
                if (!IsGestureEnabled(SourceGestureType.Pinch))
                {
                    state = GestureState.HELD;
                    secondFingerId = -1;
                    callBelatedPinchComplete = true;
                }
            }
            else
            {
                if (activeFingerId == -1)
                {
                    return;
                }

                if (IsGestureEnabled(SourceGestureType.Flick))
                {
                    if (updateTimestamp != DateTime.MinValue)
                    {
                        float num = (float)(clock.Now - updateTimestamp).TotalSeconds;
                        Vector2 vector = arithmetic.Divide(activeFingerPosition - lastUpdatePosition, 0.001f + num);
                        velocity += (vector - velocity) * 0.45f;
                    }

                    lastUpdatePosition = activeFingerPosition;
                    updateTimestamp = clock.Now;
                }

                if (IsGestureEnabled(SourceGestureType.Hold) && state == GestureState.HOLDING &&
                    clock.Now - eventTimestamp >= TimeSpan.FromSeconds(1.0))
                {
                    panel.EnqueueGesture(new SourceGestureSample(SourceGestureType.Hold, GetGestureTimestamp(),
                        activeFingerPosition, Vector2.Zero, Vector2.Zero, Vector2.Zero, activeFingerId, -1));
                    state = GestureState.HELD;
                }
            }
        }

        private TimeSpan GetGestureTimestamp()
        {
            return TimeSpan.FromTicks(clock.TickCount);
        }

        private bool IsGestureEnabled(SourceGestureType gestureType)
        {
            return (panel.EnabledGestures & gestureType) != 0;
        }

        private void OnReleased_Pinch(int fingerId, Vector2 touchPosition)
        {
            if (fingerId != activeFingerId && fingerId != secondFingerId)
            {
                return;
            }

            if (IsGestureEnabled(SourceGestureType.PinchComplete))
            {
                panel.EnqueueGesture(new SourceGestureSample(SourceGestureType.PinchComplete, GetGestureTimestamp(),
                    Vector2.Zero, Vector2.Zero, Vector2.Zero, Vector2.Zero, activeFingerId, secondFingerId));
            }

            if (fingerId == activeFingerId)
            {
                activeFingerId = secondFingerId;
                activeFingerPosition = secondFingerPosition;
            }

            secondFingerId = -1;
            bool flag = false;
            foreach (int fingerId2 in fingerIds)
            {
                if (fingerId2 != activeFingerId)
                {
                    secondFingerId = fingerId2;
                    flag = true;
                    break;
                }
            }

            if (!flag)
            {
                state = GestureState.HELD;
            }
        }

        private void OnMoved_Pinch(int fingerId, Vector2 touchPosition, Vector2 delta)
        {
            if (fingerId == activeFingerId || fingerId == secondFingerId)
            {
                if (fingerId == activeFingerId)
                {
                    activeFingerPosition = touchPosition;
                    panel.EnqueueGesture(new SourceGestureSample(SourceGestureType.Pinch, GetGestureTimestamp(),
                        activeFingerPosition, secondFingerPosition, delta, Vector2.Zero, activeFingerId,
                        secondFingerId));
                }
                else
                {
                    secondFingerPosition = touchPosition;
                    panel.EnqueueGesture(new SourceGestureSample(SourceGestureType.Pinch, GetGestureTimestamp(),
                        activeFingerPosition, secondFingerPosition, Vector2.Zero, delta, activeFingerId,
                        secondFingerId));
                }
            }
        }
    }
}
