using Celeste.Scene.Scheduling;
using Celeste.Physics.Collision;
using System;
using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Player.Scene.Transitions
{
    public sealed class PlayerTransition : IRoomTransitionPlayer
    {
        public readonly PixelActor Body;
        public readonly global::Celeste.Simulation.Gameplay.Player.State.PlayerState State;
        public Func<int> MaxDashes;
        public Action CleanTriggers, ClearChaserStates, TransferFollowers, UpdateCarry;
        public Action<bool> UpdateHair;

        public Vector2 Position
        {
            get => Body.Position;
            set => Body.Position = value;
        }

        public PlayerTransition(PixelActor body, global::Celeste.Simulation.Gameplay.Player.State.PlayerState state,
            Func<int> maxDashes)
        {
            Body = body;
            State = state;
            MaxDashes = maxDashes;
        }

        public void CleanUpTriggers() => CleanTriggers?.Invoke();

        public bool TransitionTo(Vector2 target, Vector2 direction, float deltaTime)
        {
            float toX = Approach(Body.ExactPosition.X, target.X, 60f * deltaTime);
            ((RoomPlayerSession)Body.SourceColliderOwner).MoveToX(toX);
            float toY = Approach(Body.ExactPosition.Y, target.Y, 60f * deltaTime);
            ((RoomPlayerSession)Body.SourceColliderOwner).MoveToY(toY);
            // 过场在自己的整个期间独占这个身体。`Level.Update` 的 Transitioning 分支只跑
            // `Tags.TransitionUpdate` 的实体（`Celeste/Level.cs:1887-1895`），而该分支的存活条件是
            // `transition != null`（`Celeste/Level.cs:221`）——`transition` 在 `TransitionTo` 里建立
            // （`Celeste/Level.cs:1489`）、在 `TransitionRoutine` 的最后一行才清空
            // （`Celeste/Level.cs:1639`），也就是**横扫结束之后**，不是换房那一刻。`Player` 只带
            // `Tags.Persistent`（`Celeste/Player.cs:1122`），所以原版在整个过场期间都不跑玩家的 update，
            // 位置完全由这里的两次 Approach 决定。端口侧的对应保证是：场景在 `Transitioning` 期间保持
            // `OriginalSceneModes.Transition`，而无标签的玩家调度项在该模式下不执行
            // （`RoomPresentation.Transition.cs` 的 `EntityTransitioning`、`SceneUpdateScheduler.RunMode`）。
            //
            // 这里**不要**再补一句 `Body.Position = new Vector2(toX, toY); Body.Remainder = Vector2.Zero;`。
            // 曾经有过，是有害的：`MoveH/MoveV` 本来就把 `Position + Remainder` 保持为同一个值
            // （`PixelActor.cs`），pin 写回的是同样的值，只是把切分从「整数像素 + 小数余数」改成了
            // 「小数像素」；而到达判据读的是整数 `Position`（原版 `Celeste/Player.cs:2299` 同样如此），
            // 于是每个过场都会晚一帧才判为到达。实测：加 pin 的 1A 有 9 个分歧，id 全部是这个签名
            // （195/353/499/631/2041/2533 在 y、1451/2174/2918 在 x，下一帧补齐）；去掉后为 0。
            UpdateHair?.Invoke(false);
            UpdateCarry?.Invoke();
            if (Position != target) return false;
            Body.Remainder = Vector2.Zero;
            State.Motion.Normal.Speed.X = (int)Math.Round(State.Motion.Normal.Speed.X);
            State.Motion.Normal.Speed.Y = (int)Math.Round(State.Motion.Normal.Speed.Y);
            return true;
        }

        public void OnTransition()
        {
            State.Motion.WallSlideTimer = 1.2f;
            State.Motion.JumpGraceTimer = 0;
            State.Motion.ForceMoveXTimer = 0;
            ClearChaserStates?.Invoke();
            int max = MaxDashes();
            if (State.Dashes < max) State.Dashes = max;
            State.Stamina = 110;
            TransferFollowers?.Invoke();
        }

        private static float Approach(float value, float target, float maxMove) => value > target
            ? Math.Max(value - maxMove, target)
            : Math.Min(value + maxMove, target);
    }
}
