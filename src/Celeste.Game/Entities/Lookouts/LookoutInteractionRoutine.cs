using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Scheduling;
using Celeste.Game.Controls.Source;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Gameplay.Environment.Lava.Sandwich;
using Celeste.Scene.Entities;
using Celeste.Scene.Rendering;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Presentation.Scene.Transitions;

namespace Celeste.Game.Entities.Lookouts
{
    public static class LookoutInteractionRoutine
    {
        public static IEnumerator Run(ILookoutInteractionState state, RoomPlayerSession player)
        {
            var level = (OriginalLevelSceneRoot)state.Entity.Scene;
            var sandwichLava =
                ((ISourceScene)state.Entity.Scene).SourceScene.Entities.FindFirst<OriginalSandwichLavaState>();
            if (sandwichLava != null) sandwichLava.Waiting = true;

            if (player.Holding.Holding != null) player.Drop();

            player.Machine.State = 11;
            yield return player.DummyWalkToExact((int)state.Entity.X, false, 1f, true);
            if (Math.Abs(state.Entity.X - player.X) > 4f || player.Dead || !player.OnGround())
            {
                if (!player.Dead) player.Machine.State = 0;

                yield break;
            }

            state.Process.PlaySound("event:/game/general/lookout_use", state.Entity.Position);
            if (player.Data.Facing == 1)
                state.Sprite.Play(state.AnimationPrefix + "lookRight");
            else
                state.Sprite.Play(state.AnimationPrefix + "lookLeft");

            var playerSprite = player.Sprite;
            var hair = player.Hair;
            var visible = false;
            hair.Visible = false;
            playerSprite.Visible = visible;
            yield return 0.2f;
            ((OriginalLevelSceneRoot)state.Entity.Scene).SourceScene.QueueSourceEntity((state.Hud = state.CreateHud())
                .Entity);
            state.Hud.TrackMode = state.Nodes != null;
            state.Hud.OnlyY = state.OnlyY;
            state.NodePercent = 0f;
            state.Node = 0;
            state.Process.PlayUiSound("event:/ui/game/lookout_on");
            while ((state.Hud.Easer = ScalarMath.Approach(state.Hud.Easer, 1f,
                       state.Process.EngineContext.DeltaTime * 3f,
                       state.Process.ExtremaArithmetic)) < 1f)
            {
                level.ScreenPadding = (int)(state.Process.EasingArithmetic.CubeInOut(state.Hud.Easer) * 16f);
                yield return null;
            }

            var accel = state.Acceleration;
            var maxspd = state.MaximumSpeed;
            var cam = level.Camera.Position;
            var speed = Vector2.Zero;
            var lastDir = Vector2.Zero;
            var camStart = level.Camera.Position;
            var camStartCenter = camStart + new Vector2(160f, 90f);
            state.OnViewStarted();
            while (!((IOriginalGameInputProcessEnvironment)state.Process.EngineContext).InputSource.MenuCancel
                       .Pressed &&
                   !((IOriginalGameInputProcessEnvironment)state.Process.EngineContext).InputSource.MenuConfirm
                       .Pressed &&
                   !((IOriginalGameInputProcessEnvironment)state.Process.EngineContext).InputSource.Dash.Pressed &&
                   !((IOriginalGameInputProcessEnvironment)state.Process.EngineContext).InputSource.Jump.Pressed &&
                   state.Interacting)
            {
                var value = ((IOriginalGameInputProcessEnvironment)state.Process.EngineContext).InputSource.Aim
                    .Value;
                if (state.OnlyY) value.X = 0f;

                if (Math.Sign(value.X) != Math.Sign(lastDir.X) || Math.Sign(value.Y) != Math.Sign(lastDir.Y))
                    state.Process.PlaySound("event:/game/general/lookout_move", state.Entity.Position);

                lastDir = value;
                if (state.Sprite.CurrentAnimationID != "lookLeft" && state.Sprite.CurrentAnimationID != "lookRight")
                {
                    if (value.X == 0f)
                    {
                        if (value.Y == 0f)
                            state.Sprite.Play(state.AnimationPrefix + "looking");
                        else if (value.Y > 0f)
                            state.Sprite.Play(state.AnimationPrefix + "lookingDown");
                        else
                            state.Sprite.Play(state.AnimationPrefix + "lookingUp");
                    }
                    else if (value.X > 0f)
                    {
                        if (value.Y == 0f)
                            state.Sprite.Play(state.AnimationPrefix + "lookingRight");
                        else if (value.Y > 0f)
                            state.Sprite.Play(state.AnimationPrefix + "lookingDownRight");
                        else
                            state.Sprite.Play(state.AnimationPrefix + "lookingUpRight");
                    }
                    else if (value.X < 0f)
                    {
                        if (value.Y == 0f)
                            state.Sprite.Play(state.AnimationPrefix + "lookingLeft");
                        else if (value.Y > 0f)
                            state.Sprite.Play(state.AnimationPrefix + "lookingDownLeft");
                        else
                            state.Sprite.Play(state.AnimationPrefix + "lookingUpLeft");
                    }
                }

                if (state.Nodes == null)
                {
                    speed += accel * value * state.Process.EngineContext.DeltaTime;
                    if (value.X == 0f)
                        speed.X = ScalarMath.Approach(speed.X, 0f, accel * 2f * state.Process.EngineContext.DeltaTime,
                            state.Process.ExtremaArithmetic);

                    if (value.Y == 0f)
                        speed.Y = ScalarMath.Approach(speed.Y, 0f, accel * 2f * state.Process.EngineContext.DeltaTime,
                            state.Process.ExtremaArithmetic);

                    if (state.Process.VectorArithmetic.Length(speed) > maxspd)
                        speed = state.Process.VectorArithmetic.SafeNormalize(speed, maxspd);

                    var vector = cam;
                    var entities =
                        ((ISourceScene)state.Entity.Scene).SourceScene.Entities.GetTrackedEntities(
                            "Celeste.LookoutBlocker");
                    cam.X += speed.X * state.Process.EngineContext.DeltaTime;
                    if (cam.X < level.Bounds.Left || cam.X + 320f > level.Bounds.Right) speed.X = 0f;

                    cam.X = ScalarMath.Clamp(cam.X, level.Bounds.Left, level.Bounds.Right - 320);
                    foreach (var entry in entities)
                    {
                        var item = (SceneEntityState)entry;
                        if (cam.X + 320f > item.Left && cam.Y + 180f > item.Top && cam.X < item.Right &&
                            cam.Y < item.Bottom)
                        {
                            cam.X = vector.X;
                            speed.X = 0f;
                        }
                    }

                    cam.Y += speed.Y * state.Process.EngineContext.DeltaTime;
                    if (cam.Y < level.Bounds.Top || cam.Y + 180f > level.Bounds.Bottom) speed.Y = 0f;

                    cam.Y = ScalarMath.Clamp(cam.Y, level.Bounds.Top, level.Bounds.Bottom - 180);
                    foreach (var entry2 in entities)
                    {
                        var item2 = (SceneEntityState)entry2;
                        if (cam.X + 320f > item2.Left && cam.Y + 180f > item2.Top && cam.X < item2.Right &&
                            cam.Y < item2.Bottom)
                        {
                            cam.Y = vector.Y;
                            speed.Y = 0f;
                        }
                    }

                    level.Camera.Position = cam;
                }
                else
                {
                    var vector2 = state.Node <= 0 ? camStartCenter : state.Nodes[state.Node - 1];
                    var vector3 = state.Nodes[state.Node];
                    var num = state.Process.VectorArithmetic.Length(vector2 - vector3);
                    state.Process.VectorArithmetic.SafeNormalize(vector3 - vector2);
                    if (state.NodePercent < 0.25f && state.Node > 0)
                    {
                        var begin = Vector2Interpolation.Lerp(
                            state.Node <= 1 ? camStartCenter : state.Nodes[state.Node - 2],
                            vector2,
                            0.75f, state.Process.ScalarArithmetic);
                        var end =
                            Vector2Interpolation.Lerp(vector2, vector3, 0.25f, state.Process.ScalarArithmetic);
                        var simpleCurve = new SimpleCurve(begin, end, vector2);
                        level.Camera.Position =
                            simpleCurve.GetPoint(0.5f + state.NodePercent / 0.25f * 0.5f,
                                state.Process.CurveArithmetic);
                    }
                    else if (state.NodePercent > 0.75f && state.Node < state.Nodes.Count - 1)
                    {
                        var value2 = state.Nodes[state.Node + 1];
                        var begin2 =
                            Vector2Interpolation.Lerp(vector2, vector3, 0.75f, state.Process.ScalarArithmetic);
                        var end2 =
                            Vector2Interpolation.Lerp(vector3, value2, 0.25f, state.Process.ScalarArithmetic);
                        var simpleCurve2 = new SimpleCurve(begin2, end2, vector3);
                        level.Camera.Position =
                            simpleCurve2.GetPoint((state.NodePercent - 0.75f) / 0.25f * 0.5f,
                                state.Process.CurveArithmetic);
                    }
                    else
                    {
                        level.Camera.Position =
                            Vector2Interpolation.Lerp(vector2, vector3, state.NodePercent,
                                state.Process.ScalarArithmetic);
                    }

                    level.Camera.Position += new Vector2(-160f, -90f);
                    state.NodePercent -= value.Y * (maxspd / num) * state.Process.EngineContext.DeltaTime;
                    if (state.NodePercent < 0f)
                    {
                        if (state.Node > 0)
                        {
                            state.Node--;
                            state.NodePercent = 1f;
                        }
                        else
                        {
                            state.NodePercent = 0f;
                        }
                    }
                    else if (state.NodePercent > 1f)
                    {
                        if (state.Node < state.Nodes.Count - 1)
                        {
                            state.Node++;
                            state.NodePercent = 0f;
                        }
                        else
                        {
                            state.NodePercent = 1f;
                            if (state.Summit) break;
                        }
                    }

                    var num2 = 0f;
                    var num3 = 0f;
                    for (var i = 0; i < state.Nodes.Count; i++)
                    {
                        var num4 =
                            state.Process.VectorArithmetic.Length((i == 0 ? camStartCenter : state.Nodes[i - 1]) -
                                                                  state.Nodes[i]);
                        num3 += num4;
                        if (i < state.Node)
                            num2 += num4;
                        else if (i == state.Node) num2 += num4 * state.NodePercent;
                    }

                    state.Hud.TrackPercent = num2 / num3;
                }

                yield return null;
            }

            var playerSprite2 = player.Sprite;
            var hair2 = player.Hair;
            visible = true;
            hair2.Visible = true;
            playerSprite2.Visible = visible;
            state.Sprite.Play(state.AnimationPrefix + "idle");
            state.Process.PlayUiSound("event:/ui/game/lookout_off");
            while ((state.Hud.Easer = ScalarMath.Approach(state.Hud.Easer, 0f,
                       state.Process.EngineContext.DeltaTime * 3f,
                       state.Process.ExtremaArithmetic)) > 0f)
            {
                level.ScreenPadding = (int)(state.Process.EasingArithmetic.CubeInOut(state.Hud.Easer) * 16f);
                yield return null;
            }

            var atSummitTop = state.Summit && state.Node >= state.Nodes.Count - 1 && state.NodePercent >= 0.95f;
            if (atSummitTop)
            {
                yield return 0.5f;
                var duration = 3f;
                var approach = 0f;
                var component = new SimulationCoroutine(state.Process.EngineContext,
                    level.ZoomTo(new(160f, 90f), 2f, duration));
                state.Entity.OwnedComponents.Add(component);
                while (!((IOriginalGameInputProcessEnvironment)state.Process.EngineContext).InputSource.MenuCancel
                           .Pressed &&
                       !((IOriginalGameInputProcessEnvironment)state.Process.EngineContext).InputSource.MenuConfirm
                           .Pressed &&
                       !((IOriginalGameInputProcessEnvironment)state.Process.EngineContext).InputSource.Dash.Pressed &&
                       !((IOriginalGameInputProcessEnvironment)state.Process.EngineContext).InputSource.Jump.Pressed &&
                       state.Interacting)
                {
                    approach = ScalarMath.Approach(approach, 1f, state.Process.EngineContext.DeltaTime / duration,
                        state.Process.ExtremaArithmetic);
                    state.Process.SetMusicParam("escape", approach);
                    yield return null;
                }
            }

            if (state.Process.VectorArithmetic.Length(camStart - level.Camera.Position) > 600f)
            {
                var was = level.Camera.Position;
                var direction = state.Process.VectorArithmetic.SafeNormalize(was - camStart);
                var approach = atSummitTop ? 1f : 0.5f;
                new FadeWipePresentation((ISourceRendererScene)state.Entity.Scene, false).Duration = approach;
                for (var duration = 0f; duration < 1f; duration += state.Process.EngineContext.DeltaTime / approach)
                {
                    level.Camera.Position = was - direction * ScalarMath.Lerp(0f, 64f,
                        state.Process.EasingArithmetic.CubeIn(duration), state.Process.ScalarArithmetic);
                    yield return null;
                }

                level.Camera.Position = camStart + direction * 32f;
                new FadeWipePresentation((ISourceRendererScene)state.Entity.Scene, true);
            }

            state.OnViewEnded();
            state.Process.SetMusicParam("escape", 0f);
            level.ScreenPadding = 0f;
            level.ZoomSnap(Vector2.Zero, 1f);
            ((OriginalLevelSceneRoot)state.Entity.Scene).RemoveEntity(state.Hud.Entity);
            state.Interacting = false;
            player.Machine.State = 0;
            yield return null;
        }
    }
}
