using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Game.Audio.Surfaces;
using Celeste.Game.Content.Maps;
using Celeste.Game.Controls.Source;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Tiles;
using Celeste.Graphics.Content.Tiles.Autotiling;
using Celeste.Physics.Collision;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Gameplay.Platforms.StaticMovers;
using Celeste.Simulation.Gameplay.Tiles;
using Celeste.Simulation.Presentation.Lighting;
using JetBrains.Annotations;

namespace Celeste.Game.Gameplay.Platforms.FallingBlocks
{
    public abstract class FallingBlockState : SourceSolidEntityState
    {
        protected readonly ISourceEngineContext engine;
        private OriginalLevelSceneRoot Level => (OriginalLevelSceneRoot)Scene;
        private IOriginalGameplayProcess Process => (IOriginalGameplayProcess)engine;

        private bool CheckAt(string type, Vector2 at)
        {
            return SourceTrackedEntityCollision.CheckAt(((ISourceScene)Scene).SourceScene.Entities, type, this, at);
        }

        private bool CheckPoint(string type, Vector2 at)
        {
            return SourceSceneCollision.FirstPoint<ISourceEntityCollider>(((ISourceScene)Scene).SourceScene.Entities,
                type,
                at) != null;
        }


        public bool Triggered;

        public float FallDelay;

        private readonly char TileType;

        [UsedImplicitly(ImplicitUseKindFlags.Access |
                        ImplicitUseKindFlags.Assign)]
        private TileGrid tiles;

        [UsedImplicitly(ImplicitUseKindFlags.Access |
                        ImplicitUseKindFlags.Assign)]
        private TileGrid highlight;

        protected TileGrid SourceTiles
        {
            get => tiles;
            set => tiles = value;
        }

        protected TileGrid SourceHighlight
        {
            get => highlight;
            set => highlight = value;
        }

        protected bool finalBoss;

        protected bool climbFall;

        public bool HasStartedFalling { get; protected set; }

        protected FallingBlockState(Vector2 position, char tile, int width, int height, bool finalBoss,
            bool behind,
            bool climbFall, ISourceSolidWorld world, ISourceEngineContext engine)
            : base(position, width, height, false, world)
        {
            this.engine = engine;
            this.finalBoss = finalBoss;
            this.climbFall = climbFall;
            var newSeed = ((ISourceRandomEnvironment)engine).Random.Next();
            ((ISourceRandomProcessEnvironment)engine).RandomProcess.PushRandom(newSeed);
            OwnedComponents.Add(tiles =
                ((ISourceAutotilingResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics)
                .ForegroundAutotiler.GenerateBox(tile, width / 8, height / 8).TileGrid);
            ((ISourceRandomProcessEnvironment)engine).RandomProcess.PopRandom();
            if (finalBoss)
            {
                ((ISourceRandomProcessEnvironment)engine).RandomProcess.PushRandom(newSeed);
                OwnedComponents.Add(highlight =
                    ((ISourceAutotilingResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics)
                    .ForegroundAutotiler
                    .GenerateBox('G', width / 8, height / 8).TileGrid);
                ((ISourceRandomProcessEnvironment)engine).RandomProcess.PopRandom();
                highlight.Alpha = 0f;
            }

            OwnedComponents.Add(new SimulationCoroutine(engine, CreateSequence()));
            OwnedComponents.Add(new LightOccludeState());
            OwnedComponents.Add(new TileInterceptorState(tiles, false));
            TileType = tile;
            SurfaceSoundIndex = ((IOriginalTileSurfaceEnvironment)engine).SurfaceIndices.TileToIndex[tile];
            if (behind) Depth = 5000;
        }

        public override void OnShake(Vector2 amount)
        {
            base.OnShake(amount);
            tiles.Position += amount;
            if (highlight != null) highlight.Position += amount;
        }

        public override void OnStaticMoverTrigger(SourceStaticMoverState sm)
        {
            if (!finalBoss) Triggered = true;
        }

        protected virtual bool PlayerFallCheckCore()
        {
            return climbFall ? HasPlayerRider() : HasPlayerOnTop();
        }

        protected virtual bool PlayerWaitCheckCore()
        {
            if (Triggered) return true;

            if (PlayerFallCheckCore()) return true;

            if (climbFall)
            {
                if (!CheckAt(typeof(RoomPlayerSession).FullName, Position - Vector2.UnitX))
                    return CheckAt(typeof(RoomPlayerSession).FullName,
                        Position + Vector2.UnitX);

                return true;
            }

            return false;
        }

        protected virtual IEnumerator CreateSequence()
        {
            return SequenceCore();
        }

        protected IEnumerator SequenceCore()
        {
            while (!Triggered && (finalBoss || !PlayerFallCheckCore())) yield return null;

            while (FallDelay > 0f)
            {
                FallDelay -= engine.Frame.DeltaTime;
                yield return null;
            }

            HasStartedFalling = true;
            while (true)
            {
                ShakeSfxCore();
                StartShaking();
                ((IOriginalGameInputProcessEnvironment)engine).InputSource.Rumble(RumbleStrength.Medium,
                    RumbleLength.Medium);
                if (finalBoss) OwnedComponents.Add(new SimulationCoroutine(engine, HighlightFadeCore(1f)));

                yield return 0.2f;
                var timer = 0.4f;
                if (finalBoss) timer = 0.2f;

                while (timer > 0f && PlayerWaitCheckCore())
                {
                    yield return null;
                    timer -= engine.Frame.DeltaTime;
                }

                StopShaking();
                EmitFallParticlesCore();

                var speed = 0f;
                var maxSpeed = finalBoss ? 130f : 160f;
                while (true)
                {
                    var level = Level;
                    speed = ScalarMath.Approach(speed, maxSpeed, 500f * engine.Frame.DeltaTime,
                        ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                    if (MoveVCollideSolids(speed * engine.Frame.DeltaTime, true)) break;

                    if (Top > level.Bounds.Bottom + 16 || (Top > level.Bounds.Bottom - 1 &&
                                                           CheckAt("Celeste.Solid",
                                                               Position + new Vector2(0f, 1f))))
                    {
                        var fallingBlock = this;
                        var fallingBlock2 = this;
                        var collidable = false;
                        fallingBlock2.Visible = false;
                        fallingBlock.Collidable = collidable;
                        yield return 0.2f;
                        if (((OriginalChapterMapData)level.Session.MapData).CanTransitionTo(level,
                                new(Center.X, Bottom + 12f)))
                        {
                            yield return 0.2f;
                            Level.Shake();
                            ((IOriginalGameInputProcessEnvironment)engine).InputSource.Rumble(RumbleStrength.Strong,
                                RumbleLength.Medium);
                        }

                        RemoveSelf();
                        DestroyStaticMovers();
                        yield break;
                    }

                    yield return null;
                }

                ImpactSfxCore();
                ((IOriginalGameInputProcessEnvironment)engine).InputSource.Rumble(RumbleStrength.Strong,
                    RumbleLength.Medium);
                Level.DirectionalShake(Vector2.UnitY, finalBoss ? 0.2f : 0.3f);
                if (finalBoss) OwnedComponents.Add(new SimulationCoroutine(engine, HighlightFadeCore(0f)));

                StartShaking();
                LandParticlesCore();
                yield return 0.2f;
                StopShaking();
                if (CheckAt("Celeste.SolidTiles", Position + new Vector2(0f, 1f))) break;

                while (CheckAt("Celeste.Platform", Position + new Vector2(0f, 1f))) yield return 0.1f;
            }

            Safe = true;
        }

        protected virtual void EmitFallParticlesCore()
        {
            for (var i = 2; i < Width; i += 4)
            {
                if (CheckPoint("Celeste.Solid", TopLeft + new Vector2(i, -2f)))
                    Level.Particles.Emit(Process.ParticleTypes.FallingBlock.P_FallDustA, 2,
                        new(X + i, Y), Vector2.One * 4f, (float)Math.PI / 2f);

                Level.Particles.Emit(Process.ParticleTypes.FallingBlock.P_FallDustB, 2,
                    new(X + i, Y), Vector2.One * 4f);
            }
        }

        protected virtual IEnumerator HighlightFadeCore(float to)
        {
            var from = highlight.Alpha;
            for (var p = 0f; p < 1f; p += engine.Frame.DeltaTime / 0.5f)
            {
                highlight.Alpha = ((ISourceScalarEnvironment)engine).ScalarArithmetic.Lerp(from, to,
                    ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeInOut(p));
                tiles.Alpha = 1f - highlight.Alpha;
                yield return null;
            }

            highlight.Alpha = to;
            tiles.Alpha = 1f - to;
        }

        protected virtual void LandParticlesCore()
        {
            for (var i = 2; i <= Width; i += 4)
                if (CheckPoint("Celeste.Solid", BottomLeft + new Vector2(i, 3f)))
                {
                    Level.ParticlesFG.Emit(Process.ParticleTypes.FallingBlock.P_FallDustA, 1,
                        new(X + i, Bottom), Vector2.One * 4f, -(float)Math.PI / 2f);
                    var direction = !(i < Width / 2f) ? 0f : (float)Math.PI;
                    Level.ParticlesFG.Emit(Process.ParticleTypes.FallingBlock.P_LandDust, 1,
                        new(X + i, Bottom), Vector2.One * 4f, direction);
                }
        }

        protected virtual void ShakeSfxCore()
        {
            if (TileType == '3')
                Process.AudioSession.Play("event:/game/01_forsaken_city/fallblock_ice_shake", Center,
                    Process.SaveContext);
            else if (TileType == '9')
                Process.AudioSession.Play("event:/game/03_resort/fallblock_wood_shake", Center,
                    Process.SaveContext);
            else if (TileType == 'g')
                Process.AudioSession.Play("event:/game/06_reflection/fallblock_boss_shake", Center,
                    Process.SaveContext);
            else
                Process.AudioSession.Play("event:/game/general/fallblock_shake", Center, Process.SaveContext);
        }

        protected virtual void ImpactSfxCore()
        {
            if (TileType == '3')
                Process.AudioSession.Play("event:/game/01_forsaken_city/fallblock_ice_impact", BottomCenter,
                    Process.SaveContext);
            else if (TileType == '9')
                Process.AudioSession.Play("event:/game/03_resort/fallblock_wood_impact", BottomCenter,
                    Process.SaveContext);
            else if (TileType == 'g')
                Process.AudioSession.Play("event:/game/06_reflection/fallblock_boss_impact", BottomCenter,
                    Process.SaveContext);
            else
                Process.AudioSession.Play("event:/game/general/fallblock_impact", BottomCenter,
                    Process.SaveContext);
        }
    }
}
