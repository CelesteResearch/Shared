using Celeste.Input.Devices.Mouse;
using Celeste.Input.Devices.Keyboard;
using Celeste.Core.Display;
using System;
using System.Numerics;
using Celeste.Core.Audio;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Core.Scheduling;
using Celeste.Input.Gameplay;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Presentation.Mountain.Model;
using Celeste.Game.Presentation.Mountain.Policies;
using Celeste.Game.Presentation.Mountain.Views;
using Celeste.Game.Presentation.Mountain.Input;
using Celeste.Game.Execution.Engine;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Session;
using Celeste.Scene.Rendering;
using Celeste.Graphics.Display;
using Celeste.Graphics.Geometry.ThreeD.Camera;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Vertices;
using global::Celeste.Game.Execution;

namespace Celeste.Game.Presentation.Mountain.Rendering
{
    public class MountainRendererState : SceneRenderer
    {
        public readonly ISourceEngineContext EngineContext;
        private ISourceVectorArithmetic VectorArithmetic => ((ISourceVectorEnvironment)EngineContext).VectorArithmetic;
        private ISourceScalarArithmetic ScalarArithmetic => ((ISourceScalarEnvironment)EngineContext).ScalarArithmetic;

        private ISourceExtremaArithmetic ExtremaArithmetic =>
            ((ISourceExtremaEnvironment)EngineContext).ExtremaArithmetic;

        private ISourceEasingArithmetic EasingArithmetic => ((ISourceEasingEnvironment)EngineContext).EasingArithmetic;

        private IOriginalMountainDebugInput DebugInput =>
            ((IOriginalMountainDebugInputEnvironment)EngineContext).MountainDebugInput;

        private static float ForwardAngle(Quaternion rotation)
        {
            var forward = SourceQuaternionMath.Forward(rotation);
            return Vector2Geometry.Angle(new Vector2(forward.X, forward.Z));
        }

        public bool ForceNearFog;

        public Action OnEaseEnd;

        public static readonly Vector3 RotateLookAt = new Vector3(0f, 7f, 0f);

        private const float rotateDistance = 15f;

        private const float rotateYPosition = 3f;

        private bool rotateAroundCenter;

        private bool rotateAroundTarget;

#pragma warning disable CS0169 // The original source retains this unused camera field.
        private float rotateAroundTargetDistance;
#pragma warning restore CS0169

        private float rotateTimer = (float)Math.PI / 2f;

        private const float DurationDivisor = 3f;

        public MountainCameraState UntiltedCamera;

        public MountainModelState Model;

        public bool AllowUserRotation = true;

        private Vector2 userOffset;

        private bool inFreeCameraDebugMode;
        public bool InFreeCameraDebugMode => inFreeCameraDebugMode;
        public void SetFreeCam(bool value) => inFreeCameraDebugMode = value;


        private float percent = 1f;

        private float duration = 1f;

        private MountainCameraState easeCameraFrom;

        private MountainCameraState easeCameraTo;

        private float easeCameraRotationAngleTo;

        private float timer;

        private float door;

        public MountainCameraState Camera => Model.Camera;

        public bool Animating { get; private set; }

        public int Area { get; set; }

        public MountainRendererState(ISourceEngineContext engine)
        {
            EngineContext = engine;
            Model = ((IOriginalMountainPresentationEnvironment)engine).MountainPresentationPolicy.CreateModel(engine);
            GotoRotationMode();
        }

        public void Dispose()
        {
            Model.Dispose();
        }

        public override void Update(object scene)
            => ((IOriginalMountainPresentationEnvironment)EngineContext).MountainPresentationPolicy.UpdateRenderer(this,
                scene);

        public void UpdateOriginal(object scene) => UpdateCore(scene, false);
        public void UpdateInstalledOriginal(object scene) => UpdateCore(scene, true);

        private void UpdateCore(object scene, bool installedBindings)
        {
            timer += EngineContext.DeltaTime;
            Model.Update();
            Vector2 vector = (AllowUserRotation
                ? (-((ISourceGameInputEnvironment)EngineContext).Input.MountainAim.Value * 0.8f)
                : Vector2.Zero);
            userOffset += (vector - userOffset) * (1f - (float)Math.Pow(0.009999999776482582, EngineContext.DeltaTime));
            if (!rotateAroundCenter)
            {
                if (Area == 8)
                {
                    userOffset.Y = ExtremaArithmetic.Max(0f, userOffset.Y);
                }

                if (Area == 7)
                {
                    userOffset.X = ScalarMath.Clamp(userOffset.X, -0.4f, 0.4f);
                }
            }

            if (!inFreeCameraDebugMode)
            {
                if (rotateAroundCenter)
                {
                    rotateTimer -= EngineContext.DeltaTime * 0.1f;
                    Vector3 vector2 = new Vector3((float)Math.Cos(rotateTimer) * 15f, 3f,
                        (float)Math.Sin(rotateTimer) * 15f);
                    Model.Camera.Position += (vector2 - Model.Camera.Position) *
                                             (1f - (float)Math.Pow(0.10000000149011612, EngineContext.DeltaTime));
                    Model.Camera.Target = RotateLookAt + Vector3.UnitY * userOffset.Y;
                    Quaternion quaternion = SourceQuaternionMath.LookAt(Model.Camera.Position, Model.Camera.Target,
                        Vector3.UnitY, VectorArithmetic);
                    Model.Camera.Rotation =
                        SourceQuaternionMath.Slerp(Model.Camera.Rotation, quaternion, EngineContext.DeltaTime * 4f);
                    UntiltedCamera = Camera;
                }
                else
                {
                    if (Animating)
                    {
                        percent = ScalarMath.Approach(percent, 1f, EngineContext.DeltaTime / duration,
                            ExtremaArithmetic);
                        float num = EasingArithmetic.SineOut(percent);
                        Model.Camera.Position = GetBetween(easeCameraFrom.Position, easeCameraTo.Position, num);
                        Model.Camera.Target = GetBetween(easeCameraFrom.Target, easeCameraTo.Target, num);
                        Vector3 vector3 = SourceQuaternionMath.Forward(easeCameraFrom.Rotation);
                        Vector3 vector4 = SourceQuaternionMath.Forward(easeCameraTo.Rotation);
                        Vector2 vector5 = Vector2Geometry.AngleToVector(
                            length: ScalarArithmetic.Lerp(VectorArithmetic.Length(new Vector2(vector3.X, vector3.Z)),
                                VectorArithmetic.Length(new Vector2(vector4.X, vector4.Z)),
                                ScalarMath.Clamp(num, 0f, 1f)),
                            angle: ScalarArithmetic.Lerp(Vector2Geometry.Angle(new Vector2(vector3.X, vector3.Z)),
                                easeCameraRotationAngleTo, num));
                        float y = ScalarArithmetic.Lerp(vector3.Y, vector4.Y, ScalarMath.Clamp(num, 0f, 1f));
                        Model.Camera.Rotation = SourceQuaternionMath.LookAt(new Vector3(vector5.X, y, vector5.Y),
                            Vector3.UnitY, VectorArithmetic);
                        if (percent >= 1f)
                        {
                            rotateTimer =
                                Vector2Geometry.Angle(new Vector2(Model.Camera.Position.X, Model.Camera.Position.Z));
                            Animating = false;
                            if (OnEaseEnd != null)
                            {
                                OnEaseEnd();
                            }
                        }
                    }
                    else if (rotateAroundTarget)
                    {
                        rotateTimer -= EngineContext.DeltaTime * 0.1f;
                        float num2 = VectorArithmetic.Length(new Vector2(easeCameraTo.Target.X, easeCameraTo.Target.Z) -
                                                             new Vector2(easeCameraTo.Position.X,
                                                                 easeCameraTo.Position.Z));
                        Vector3 vector6 = new Vector3(easeCameraTo.Target.X + (float)Math.Cos(rotateTimer) * num2,
                            easeCameraTo.Position.Y, easeCameraTo.Target.Z + (float)Math.Sin(rotateTimer) * num2);
                        Model.Camera.Position += (vector6 - Model.Camera.Position) *
                                                 (1f - (float)Math.Pow(0.10000000149011612, EngineContext.DeltaTime));
                        Model.Camera.Target = easeCameraTo.Target + Vector3.UnitY * userOffset.Y * 2f +
                                              new Vector3(-1f, 0f, 0f) * userOffset.X * 2f;
                        Quaternion quaternion2 = SourceQuaternionMath.LookAt(Model.Camera.Position, Model.Camera.Target,
                            Vector3.UnitY, VectorArithmetic);
                        Model.Camera.Rotation = SourceQuaternionMath.Slerp(Model.Camera.Rotation, quaternion2,
                            EngineContext.DeltaTime * 4f);
                        UntiltedCamera = Camera;
                    }
                    else
                    {
                        Model.Camera.Rotation = easeCameraTo.Rotation;
                        Model.Camera.Target = easeCameraTo.Target;
                    }

                    UntiltedCamera = Camera;
                    if (userOffset != Vector2.Zero && !rotateAroundTarget)
                    {
                        Vector3 vector7 = SourceQuaternionMath.Left(Model.Camera.Rotation) * userOffset.X * 0.25f;
                        Vector3 vector8 = SourceQuaternionMath.Up(Model.Camera.Rotation) * userOffset.Y * 0.25f;
                        Vector3 pos = Model.Camera.Position + SourceQuaternionMath.Forward(Model.Camera.Rotation) +
                                      vector7 + vector8;
                        Model.Camera.LookAt(pos, VectorArithmetic);
                    }
                }
            }
            else
            {
                Vector3 vector9 = SourceVector3Math.Transform(new Vector3(0f, 0f, -1f),
                    SourceQuaternionMath.Conjugate(Model.Camera.Rotation));
                Model.Camera.Rotation =
                    SourceQuaternionMath.LookAt(Vector3.Zero, vector9, Vector3.UnitY, VectorArithmetic);
                Vector3 vector10 = SourceVector3Math.Transform(new Vector3(-1f, 0f, 0f),
                    SourceQuaternionMath.Conjugate(Model.Camera.Rotation));
                Vector3 vector11 = new Vector3(0f, 0f, 0f);
                if ((installedBindings
                        ? ((IOriginalMountainCameraBindingsEnvironment)EngineContext).MountainCameraBindings
                        .CameraForwardCheck
                        : DebugInput.KeyboardCheck(SourceKeys.W)))
                {
                    vector11 += vector9;
                }

                if ((installedBindings
                        ? ((IOriginalMountainCameraBindingsEnvironment)EngineContext).MountainCameraBindings
                        .CameraBackwardCheck
                        : DebugInput.KeyboardCheck(SourceKeys.S)))
                {
                    vector11 -= vector9;
                }

                if ((installedBindings
                        ? ((IOriginalMountainCameraBindingsEnvironment)EngineContext).MountainCameraBindings
                        .CameraRightCheck
                        : DebugInput.KeyboardCheck(SourceKeys.D)))
                {
                    vector11 -= vector10;
                }

                if ((installedBindings
                        ? ((IOriginalMountainCameraBindingsEnvironment)EngineContext).MountainCameraBindings
                        .CameraLeftCheck
                        : DebugInput.KeyboardCheck(SourceKeys.A)))
                {
                    vector11 += vector10;
                }

                if ((installedBindings
                        ? ((IOriginalMountainCameraBindingsEnvironment)EngineContext).MountainCameraBindings
                        .CameraUpCheck
                        : DebugInput.KeyboardCheck(SourceKeys.Q)))
                {
                    vector11 += Vector3.UnitY;
                }

                if ((installedBindings
                        ? ((IOriginalMountainCameraBindingsEnvironment)EngineContext).MountainCameraBindings
                        .CameraDownCheck
                        : DebugInput.KeyboardCheck(SourceKeys.Z)))
                {
                    vector11 += -Vector3.UnitY;
                }

                Model.Camera.Position += vector11 *
                                         ((installedBindings
                                             ? ((IOriginalMountainCameraBindingsEnvironment)EngineContext)
                                             .MountainCameraBindings.CameraSlowCheck
                                             : DebugInput.KeyboardCheck(SourceKeys.LeftShift))
                                             ? 0.5f
                                             : 5f) * EngineContext.DeltaTime;
                if (DebugInput.CheckLeftButton)
                {
                    SourceMouseState state = DebugInput.GetMousePosition();
                    int num3 = ((ISourceGraphicsDeviceEnvironment)EngineContext).GraphicsDevice.Viewport.Width / 2;
                    int num4 = ((ISourceGraphicsDeviceEnvironment)EngineContext).GraphicsDevice.Viewport.Height / 2;
                    int num5 = state.X - num3;
                    int num6 = state.Y - num4;
                    Model.Camera.Rotation = SourceQuaternionMath.Multiply(Model.Camera.Rotation,
                        SourceQuaternionMath.CreateFromAxisAngle(Vector3.UnitY,
                            (float)num5 * 0.1f * EngineContext.DeltaTime));
                    Model.Camera.Rotation = SourceQuaternionMath.Multiply(Model.Camera.Rotation,
                        SourceQuaternionMath.CreateFromAxisAngle(vector10,
                            (float)(-num6) * 0.1f * EngineContext.DeltaTime));
                    DebugInput.SetMousePosition(num3, num4);
                }

                if (Area >= 0)
                {
                    Vector3 target = ((IOriginalSessionConstructionProcess)EngineContext).AreaTable.Areas[Area]
                        .MountainIdle
                        .Target;
                    Vector3 vector12 = vector10 * 0.05f;
                    Vector3 vector13 = Vector3.UnitY * 0.05f;
                    Model.DebugPoints.Clear();
                    Model.DebugPoints.Add(new SourceVertexPositionColor(target - vector12 + vector13, PackedColor.Red));
                    Model.DebugPoints.Add(new SourceVertexPositionColor(target + vector12 + vector13, PackedColor.Red));
                    Model.DebugPoints.Add(new SourceVertexPositionColor(target + vector12 - vector13, PackedColor.Red));
                    Model.DebugPoints.Add(new SourceVertexPositionColor(target - vector12 + vector13, PackedColor.Red));
                    Model.DebugPoints.Add(new SourceVertexPositionColor(target + vector12 - vector13, PackedColor.Red));
                    Model.DebugPoints.Add(new SourceVertexPositionColor(target - vector12 - vector13, PackedColor.Red));
                    Model.DebugPoints.Add(new SourceVertexPositionColor(target - vector12 * 0.25f - vector13,
                        PackedColor.Red));
                    Model.DebugPoints.Add(new SourceVertexPositionColor(target + vector12 * 0.25f - vector13,
                        PackedColor.Red));
                    Model.DebugPoints.Add(new SourceVertexPositionColor(
                        target + vector12 * 0.25f + -Vector3.UnitY * 100f,
                        PackedColor.Red));
                    Model.DebugPoints.Add(new SourceVertexPositionColor(target - vector12 * 0.25f - vector13,
                        PackedColor.Red));
                    Model.DebugPoints.Add(new SourceVertexPositionColor(
                        target + vector12 * 0.25f + -Vector3.UnitY * 100f,
                        PackedColor.Red));
                    Model.DebugPoints.Add(new SourceVertexPositionColor(
                        target - vector12 * 0.25f + -Vector3.UnitY * 100f,
                        PackedColor.Red));
                }
            }

            door = ScalarMath.Approach(door, (Area == 9 && !rotateAroundCenter) ? 1 : 0, EngineContext.DeltaTime * 1f,
                ExtremaArithmetic);
            Model.CoreWallPosition = SourceVector3Math.Lerp(Vector3.Zero, -new Vector3(-1.5f, 1.5f, 1f),
                EasingArithmetic.CubeInOut(door), ScalarArithmetic);
            Model.NearFogAlpha = ScalarMath.Approach(Model.NearFogAlpha, (ForceNearFog || rotateAroundCenter) ? 1 : 0,
                (float)(rotateAroundCenter ? 1 : 4) * EngineContext.DeltaTime, ExtremaArithmetic);
            if (((Celeste.Game.Execution.Startup.IOriginalGamePlayModeEnvironment)EngineContext).PlayMode ==
                Celeste.Game.Execution.GameRuntime.PlayModes.Debug)
            {
                if ((installedBindings
                        ? ((IOriginalMountainCameraBindingsEnvironment)EngineContext).MountainCameraBindings
                        .CameraPrintPressed
                        : DebugInput.KeyboardPressed(SourceKeys.P)))
                {
                    DebugInput.WriteConsoleLine(GetCameraString());
                }

                if (DebugInput.KeyboardPressed(SourceKeys.F2))
                {
                    EngineContext.Frame.Scenes.NextScene =
                        ((IOriginalOverworldLoaderEnvironment)EngineContext).OverworldLoaders.CreateOverworldLoader(
                            OverworldStartMode.ReturnFromOptions);
                }

                if ((installedBindings
                        ? ((IOriginalMountainCameraBindingsEnvironment)EngineContext).MountainCameraBindings
                        .ToggleMountainFreeCamPressed
                        : DebugInput.KeyboardPressed(SourceKeys.Space)))
                {
                    inFreeCameraDebugMode = !inFreeCameraDebugMode;
                }

                Model.DrawDebugPoints = inFreeCameraDebugMode;
                if (DebugInput.KeyboardPressed(SourceKeys.F1))
                {
                    ((IOriginalMountainViewsEnvironment)EngineContext).MountainViews.ReloadMountainViews();
                }
            }
        }

        private Vector3 GetBetween(Vector3 from, Vector3 to, float ease)
        {
            Vector2 vector = new Vector2(from.X, from.Z);
            Vector2 vector2 = new Vector2(to.X, to.Z);
            float startAngle = Vector2Geometry.Angle(vector, Vector2.Zero);
            float endAngle = Vector2Geometry.Angle(vector2, Vector2.Zero);
            float angleRadians = ScalarMath.AngleLerp(startAngle, endAngle, ease);
            float num = VectorArithmetic.Length(vector);
            float num2 = VectorArithmetic.Length(vector2);
            float length = num + (num2 - num) * ease;
            float y = from.Y + (to.Y - from.Y) * ease;
            Vector2 vector3 = -Vector2Geometry.AngleToVector(angleRadians, length);
            return new Vector3(vector3.X, y, vector3.Y);
        }

        public override void BeforeRender(object scene)
        {
            Model.BeforeRender(scene);
        }

        public override void Render(object scene)
        {
            Model.Render();
            var context = ((ISourceRenderEnvironment)EngineContext).CurrentContext;
            context.BeginBatch(new SourceRenderBatchState(SourceSpriteSortMode.Immediate,
                SourceBlendState.NonPremultiplied,
                SourceSamplerState.LinearClamp, null, null, null,
                ((IOriginalEngineGraphicsEnvironment)EngineContext).EngineGraphics.ScreenMatrix));
            global::Celeste.Graphics.Rendering.SourceAtlasDrawing.Draw(context, this,
                ((IOriginalOverworldGraphicsEnvironment)EngineContext).OverworldGraphics.Atlas["vignette"],
                Vector2.Zero,
                Vector2.Zero, PackedColor.White * .2f);
            context.EndBatch();
            if (inFreeCameraDebugMode)
            {
                context.BeginBatch(new SourceRenderBatchState(SourceSpriteSortMode.Immediate,
                    SourceBlendState.NonPremultiplied, SourceSamplerState.LinearClamp, null, null, null,
                    ((IOriginalEngineGraphicsEnvironment)EngineContext).EngineGraphics.ScreenMatrix));
                ((global::Celeste.Game.Content.Dialogs.IOriginalGameTextEnvironment)EngineContext).Text.ActiveFont
                    .DrawOutline(context, this, GetCameraString(), new Vector2(8f, 8f), Vector2.Zero,
                        Vector2.One * .75f,
                        PackedColor.White, 2f, PackedColor.Black);
                context.EndBatch();
            }
        }

        public void SnapCamera(int area, MountainCameraState transform, bool targetRotate = false)
        {
            Area = area;
            Animating = false;
            rotateAroundCenter = false;
            rotateAroundTarget = targetRotate;
            Model.Camera = transform;
            percent = 1f;
        }

        public void SnapState(int state)
        {
            Model.SnapState(state);
        }

        public float EaseCamera(int area, MountainCameraState transform, float? duration = null, bool nearTarget = true,
            bool targetRotate = false)
        {
            if (Area != area && area >= 0)
            {
                PlayWhoosh(Area, area);
            }

            Area = area;
            percent = 0f;
            Animating = true;
            rotateAroundCenter = false;
            rotateAroundTarget = targetRotate;
            userOffset = Vector2.Zero;
            easeCameraFrom = Model.Camera;
            if (nearTarget)
            {
                easeCameraFrom.Target = easeCameraFrom.Position +
                                        VectorArithmetic.SafeNormalize(easeCameraFrom.Target -
                                                                       easeCameraFrom.Position) *
                                        0.5f;
            }

            easeCameraTo = transform;
            float num = ForwardAngle(easeCameraFrom.Rotation);
            float radiansB = ForwardAngle(easeCameraTo.Rotation);
            float num2 = ScalarMath.AngleDiff(num, radiansB);
            float num3 = (float)(-Math.Sign(num2)) * ((float)Math.PI * 2f - Math.Abs(num2));
            Vector3 between = GetBetween(easeCameraFrom.Position, easeCameraTo.Position, 0.5f);
            Vector2 vector = Vector2Geometry.AngleToVector(ScalarArithmetic.Lerp(num, num + num2, 0.5f), 1f);
            Vector2 vector2 = Vector2Geometry.AngleToVector(ScalarArithmetic.Lerp(num, num + num3, 0.5f), 1f);
            if (VectorArithmetic.Length(between + new Vector3(vector.X, 0f, vector.Y)) <
                VectorArithmetic.Length(between + new Vector3(vector2.X, 0f, vector2.Y)))
            {
                easeCameraRotationAngleTo = num + num2;
            }
            else
            {
                easeCameraRotationAngleTo = num + num3;
            }

            if (!duration.HasValue)
            {
                this.duration = GetDuration(easeCameraFrom, easeCameraTo);
            }
            else
            {
                this.duration = duration.Value;
            }

            return this.duration;
        }

        public void EaseState(int state)
        {
            Model.EaseState(state);
        }

        public void GotoRotationMode()
        {
            if (!rotateAroundCenter)
            {
                rotateAroundCenter = true;
                rotateTimer = Vector2Geometry.Angle(new Vector2(Model.Camera.Position.X, Model.Camera.Position.Z));
                Model.EaseState(0);
            }
        }

        private float GetDuration(MountainCameraState from, MountainCameraState to)
        {
            float value = ScalarMath.AngleDiff(
                Vector2Geometry.Angle(new Vector2(from.Position.X, from.Position.Z),
                    new Vector2(from.Target.X, from.Target.Z)),
                Vector2Geometry.Angle(new Vector2(to.Position.X, to.Position.Z),
                    new Vector2(to.Target.X, to.Target.Z)));
            double second = Math.Sqrt(VectorArithmetic.Length(from.Position - to.Position)) / 3.0;
            double first = Math.Abs(value) * .5f;
            return ScalarMath.Clamp((float)(ExtremaArithmetic.Max(first, second) * 0.699999988079071), .3f, 1.1f);
        }

        private void PlayWhoosh(int from, int to)
        {
            string text = "";
            if (from == 0 && to == 1)
            {
                text = "event:/ui/world_map/whoosh/400ms_forward";
            }
            else if (from == 1 && to == 0)
            {
                text = "event:/ui/world_map/whoosh/400ms_back";
            }
            else if (from == 1 && to == 2)
            {
                text = "event:/ui/world_map/whoosh/600ms_forward";
            }
            else if (from == 2 && to == 1)
            {
                text = "event:/ui/world_map/whoosh/600ms_back";
            }
            else if (from < to && from > 1 && from < 7)
            {
                text = "event:/ui/world_map/whoosh/700ms_forward";
            }
            else if (from > to && from > 2 && from < 8)
            {
                text = "event:/ui/world_map/whoosh/700ms_back";
            }
            else if (from == 7 && to == 8)
            {
                text = "event:/ui/world_map/whoosh/1000ms_forward";
            }
            else if (from == 8 && to == 7)
            {
                text = "event:/ui/world_map/whoosh/1000ms_back";
            }
            else if (from == 8 && to == 9)
            {
                text = "event:/ui/world_map/whoosh/600ms_forward";
            }
            else if (from == 9 && to == 8)
            {
                text = "event:/ui/world_map/whoosh/600ms_back";
            }
            else if (from == 9 && to == 10)
            {
                text = "event:/ui/world_map/whoosh/1000ms_forward";
            }
            else if (from == 10 && to == 9)
            {
                text = "event:/ui/world_map/whoosh/1000ms_back";
            }

            if (!string.IsNullOrEmpty(text))
            {
                ((ISourceAudioEnvironment)EngineContext).SourceAudio.Play(text);
            }
        }

        private string GetCameraString()
        {
            Vector3 position = Model.Camera.Position;
            Vector3 vector = position + SourceVector3Math.Transform(new Vector3(0f, 0f, -1f),
                SourceQuaternionMath.Conjugate(Model.Camera.Rotation)) * 2f;
            return "position=\"" + position.X.ToString("0.000") + ", " + position.Y.ToString("0.000") + ", " +
                   position.Z.ToString("0.000") + "\" \ntarget=\"" + vector.X.ToString("0.000") + ", " +
                   vector.Y.ToString("0.000") + ", " + vector.Z.ToString("0.000") + "\"";
        }
    }
}
