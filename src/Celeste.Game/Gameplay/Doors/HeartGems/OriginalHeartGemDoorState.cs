using Celeste.Core.Display;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components.Rendering;
using Celeste.Core.Geometry;
using Celeste.Core.Mathematics;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Collision;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Gameplay.Walls.Breakable;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Save.Runtime;

namespace Celeste.Game.Gameplay.Doors.HeartGems
{
    public class OriginalHeartGemDoorState : SceneEntityState
    {
        private readonly IOriginalHeartGemDoorProcess engine;
        private readonly ISourceSolidWorldFactory solidWorlds;
        private readonly IOriginalSaveCounterQueries saveCounters;

        private RoomPlayerSession FirstPlayer()
        {
            var list = ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities(
                typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);

            return list.Count > 0 ? list[0] as RoomPlayerSession : null;
        }

        private IBreakableWallEntity FirstDashBlock(IntRect bounds)
            => SourceSceneCollisionQueries.First<IBreakableWallEntity>(bounds,
                ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities("Celeste.DashBlock"));

        private void PlaySound(string path, Vector2 position)
            => engine.AudioSession.Play(path, position, engine.SaveContext);

        private SourceSolidEntityState CreateSolid(Vector2 position, float width, float height, bool safe)
            => new SourceSolidEntityState(position, width, height, safe, solidWorlds.Create(position, safe));

        private const string OpenedFlag = "opened_heartgem_door_";


        public readonly int Requires;

        public int Size;

        protected readonly float openDistance;

        protected float openPercent;

        protected SourceSolidEntityState TopSolid;

        protected SourceSolidEntityState BotSolid;

        private float offset;

        private Vector2 mist;

        private AtlasEntry temp = new AtlasEntry();

        protected List<AtlasEntry> icon;

        private HeartGemDoorParticle[] particles = new HeartGemDoorParticle[50];

        private bool startHidden;

        private float heartAlpha = 1f;

        public virtual int HeartGems
        {
            get
            {
                if (engine.SaveContext.CurrentSave.CheatMode)
                {
                    return Requires;
                }

                return saveCounters.TotalHeartGems(engine.SaveContext.CurrentSave);
            }
        }

        public float Counter { get; protected set; }

        public bool Opened { get; protected set; }

        private float openAmount => openPercent * openDistance;

        public OriginalHeartGemDoorState(EntityData data, Vector2 offset,
            IOriginalHeartGemDoorProcess engine, ISourceSolidWorldFactory solidWorlds,
            IOriginalSaveCounterQueries saveCounters)
            : base(engine.EntitySourceDataRegistration, data.Position + offset)
        {
            this.engine = engine;
            this.solidWorlds = solidWorlds;
            this.saveCounters = saveCounters;
            Requires = EntityAttributeReader.Int(data.Values, "requires");
            OwnedComponents.Add(new CustomBloomCallbackComponentState(RenderBloom));
            Size = data.Width;
            openDistance = 32f;
            Vector2? vector = data.Nodes != null && data.Nodes.Length != 0 ? data.Nodes[0] + offset : (Vector2?)null;
            if (vector.HasValue)
            {
                openDistance = Math.Abs(vector.Value.Y - base.Y);
            }

            icon = engine.GameGraphics.GameAtlas.GetAtlasSubtextures("objects/heartdoor/icon");
            startHidden = EntityAttributeReader.Bool(data.Values, "startHidden");
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            OriginalLevelSceneRoot level = scene as OriginalLevelSceneRoot;
            for (int i = 0; i < particles.Length; i++)
            {
                particles[i].Position = new Vector2(SourceRandomMath.NextFloat(engine.Random, Size),
                    SourceRandomMath.NextFloat(engine.Random, level.Bounds.Height));
                particles[i].Speed = SourceRandomMath.Range(engine.Random, 4, 12);
                particles[i].Color = PackedColor.White * SourceRandomMath.Range(engine.Random, 0.2f, 0.6f);
            }

            level.SourceScene.QueueSourceEntity(TopSolid = CreateSolid(new Vector2(base.X, level.Bounds.Top - 32), Size,
                base.Y - (float)level.Bounds.Top + 32f, true));
            TopSolid.SurfaceSoundIndex = 32;
            TopSolid.SquishEvenInAssistMode = true;
            TopSolid.EnableAssistModeChecks = false;
            level.SourceScene.QueueSourceEntity(BotSolid = CreateSolid(new Vector2(base.X, base.Y), Size,
                (float)level.Bounds.Bottom - base.Y + 32f, true));
            BotSolid.SurfaceSoundIndex = 32;
            BotSolid.SquishEvenInAssistMode = true;
            BotSolid.EnableAssistModeChecks = false;
            if ((base.Scene as OriginalLevelSceneRoot).Session.GetFlag("opened_heartgem_door_" + Requires))
            {
                Opened = true;
                Visible = true;
                openPercent = 1f;
                Counter = Requires;
                TopSolid.Y -= openDistance;
                BotSolid.Y += openDistance;
            }
            else
            {
                OwnedComponents.Add(new SimulationCoroutine(engine, Routine()));
            }
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            if (Opened)
            {
                FirstDashBlock(BotSolid.Collider.Bounds)?.RemoveSelf();
            }
            else if (startHidden)
            {
                RoomPlayerSession entity = FirstPlayer();
                if (entity != null && entity.X > base.X)
                {
                    startHidden = false;
                    FirstDashBlock(BotSolid.Collider.Bounds)?.RemoveSelf();
                }
                else
                {
                    Visible = false;
                }
            }
        }

        protected virtual bool CanApproach(RoomPlayerSession player) =>
            player != null && Math.Abs(player.X - Center.X) < 80f && player.X < X;

        protected virtual void OnOpened(OriginalLevelSceneRoot level) =>
            level.Session.SetFlag("opened_heartgem_door_" + Requires);

        protected virtual PackedColor InteriorColor => new PackedColor(0x18, 0x66, 0x8f);

        private IEnumerator Routine()
        {
            OriginalLevelSceneRoot level = base.Scene as OriginalLevelSceneRoot;
            float botFrom;
            float topFrom;
            float botTo;
            float topTo;
            if (startHidden)
            {
                RoomPlayerSession entity;
                do
                {
                    yield return null;
                    entity = FirstPlayer();
                } while (entity == null || !(Math.Abs(entity.X - base.Center.X) < 100f));

                PlaySound("event:/new_content/game/10_farewell/heart_door", Position);
                Visible = true;
                heartAlpha = 0f;
                topTo = TopSolid.Y;
                botTo = BotSolid.Y;
                topFrom = (TopSolid.Y -= 240f);
                botFrom = (BotSolid.Y -= 240f);
                for (float p = 0f; p < 1f; p += engine.DeltaTime * 1.2f)
                {
                    float num = engine.EasingArithmetic.CubeIn(p);
                    TopSolid.MoveToY(topFrom + (topTo - topFrom) * num);
                    BotSolid.MoveToY(botFrom + (botTo - botFrom) * num);
                    IBreakableWallEntity dashBlock = FirstDashBlock(BotSolid.Collider.Bounds);
                    if (dashBlock != null)
                    {
                        level.Shake(0.5f);
                        engine.Freeze(0.1f);
                        engine.RumbleSession.Rumble(2, 1);
                        dashBlock.Break(BotSolid.BottomCenter, new Vector2(0f, 1f), playSound: true,
                            playDebrisSound: false);
                        RoomPlayerSession entity2 = FirstPlayer();
                        if (entity2 != null && Math.Abs(entity2.X - base.Center.X) < 40f)
                        {
                            entity2.PointBounce(entity2.Position + Vector2.UnitX * 8f);
                        }
                    }

                    yield return null;
                }

                level.Shake(0.5f);
                engine.Freeze(0.1f);
                TopSolid.Y = topTo;
                BotSolid.Y = botTo;
                while (heartAlpha < 1f)
                {
                    heartAlpha = ScalarMath.Approach(heartAlpha, 1f, engine.DeltaTime * 2f, engine.ExtremaArithmetic);
                    yield return null;
                }

                yield return 0.6f;
            }

            while (!Opened && Counter < (float)Requires)
            {
                RoomPlayerSession entity3 = FirstPlayer();
                if (CanApproach(entity3))
                {
                    if (Counter == 0f && HeartGems > 0)
                    {
                        PlaySound("event:/game/09_core/frontdoor_heartfill", Position);
                    }

                    if (HeartGems < Requires)
                    {
                        level.Session.SetFlag("granny_door");
                    }

                    int num2 = (int)Counter;
                    int target = Math.Min(HeartGems, Requires);
                    Counter = ScalarMath.Approach(Counter, target, engine.DeltaTime * (float)Requires * 0.8f,
                        engine.ExtremaArithmetic);
                    if (num2 != (int)Counter)
                    {
                        yield return 0.1f;
                        if (Counter < (float)target)
                        {
                            PlaySound("event:/game/09_core/frontdoor_heartfill", Position);
                        }
                    }
                }
                else
                {
                    Counter = ScalarMath.Approach(Counter, 0f, engine.DeltaTime * (float)Requires * 4f,
                        engine.ExtremaArithmetic);
                }

                yield return null;
            }

            yield return 0.5f;
            ((ISourceScene)Scene).SourceScene.QueueSourceEntity(new HeartGemDoorWhiteLineState(Position, Size, engine));
            level.Shake();
            engine.RumbleSession.Rumble(2, 2);
            level.Flash(PackedColor.White * 0.5f);
            PlaySound("event:/game/09_core/frontdoor_unlock", Position);
            Opened = true;
            OnOpened(level);
            offset = 0f;
            yield return 0.6f;
            botFrom = TopSolid.Y;
            topFrom = TopSolid.Y - openDistance;
            botTo = BotSolid.Y;
            topTo = BotSolid.Y + openDistance;
            for (float p = 0f; p < 1f; p += engine.DeltaTime)
            {
                level.Shake();
                openPercent = engine.EasingArithmetic.CubeIn(p);
                TopSolid.MoveToY(ScalarMath.Lerp(botFrom, topFrom, openPercent, engine.ScalarArithmetic));
                BotSolid.MoveToY(ScalarMath.Lerp(botTo, topTo, openPercent, engine.ScalarArithmetic));
                if (p >= 0.4f && level.Clock.OnInterval(0.1f, engine))
                {
                    for (int i = 4; i < Size; i += 4)
                    {
                        level.ParticlesBG.Emit(engine.ParticleTypes.HeartGemDoor.P_Shimmer, 1,
                            new Vector2(TopSolid.Left + (float)i + 1f, TopSolid.Bottom - 2f), new Vector2(2f, 2f),
                            -(float)Math.PI / 2f);
                        level.ParticlesBG.Emit(engine.ParticleTypes.HeartGemDoor.P_Shimmer, 1,
                            new Vector2(BotSolid.Left + (float)i + 1f, BotSolid.Top + 2f), new Vector2(2f, 2f),
                            (float)Math.PI / 2f);
                    }
                }

                yield return null;
            }

            TopSolid.MoveToY(topFrom);
            BotSolid.MoveToY(topTo);
            openPercent = 1f;
        }

        public override void Update()
        {
            base.Update();
            if (!Opened)
            {
                offset += 12f * engine.DeltaTime;
                mist.X -= 4f * engine.DeltaTime;
                mist.Y -= 24f * engine.DeltaTime;
                for (int i = 0; i < particles.Length; i++)
                {
                    particles[i].Position.Y += particles[i].Speed * engine.DeltaTime;
                }
            }
        }

        public void RenderBloom()
        {
            if (!Opened && Visible)
            {
                DrawBloom(new IntRect((int)TopSolid.X, (int)TopSolid.Y, Size,
                    (int)(TopSolid.Height + BotSolid.Height)));
            }
        }

        private void DrawBloom(IntRect bounds)
        {
            var context = engine.CurrentContext;
            SourcePrimitiveDrawing.Rect(context, this, bounds.Left - 4, bounds.Top, 2f, bounds.Height,
                (PackedColor.White * 0.25f));
            SourcePrimitiveDrawing.Rect(context, this, bounds.Left - 2, bounds.Top, 2f, bounds.Height,
                (PackedColor.White * 0.5f));
            SourcePrimitiveDrawing.Rect(context, this, bounds.X, bounds.Y, bounds.Width, bounds.Height,
                (PackedColor.White * 0.75f));
            SourcePrimitiveDrawing.Rect(context, this, bounds.Right, bounds.Top, 2f, bounds.Height,
                (PackedColor.White * 0.5f));
            SourcePrimitiveDrawing.Rect(context, this, bounds.Right + 2, bounds.Top, 2f, bounds.Height,
                (PackedColor.White * 0.25f));
        }

        private void DrawMist(ISourceRenderContext context, IntRect bounds, Vector2 mist)
        {
            PackedColor color = PackedColor.White * 0.6f;
            AtlasEntry mTexture = engine.GameGraphics.GameAtlas["objects/heartdoor/mist"];
            int num = mTexture.FrameWidth / 2;
            int num2 = mTexture.FrameHeight / 2;
            for (int i = 0; i < bounds.Width; i += num)
            {
                for (int j = 0; j < bounds.Height; j += num2)
                {
                    mTexture.GetSubtexture((int)Mod(mist.X, num), (int)Mod(mist.Y, num2),
                        Math.Min(num, bounds.Width - i),
                        Math.Min(num2, bounds.Height - j), temp);
                    SourceAtlasDrawing.Draw(context, this, temp, new Vector2(bounds.X + i, bounds.Y + j), Vector2.Zero,
                        color);
                }
            }
        }

        private void DrawInterior(ISourceRenderContext context, IntRect bounds)
        {
            SourcePrimitiveDrawing.Rect(context, this, bounds.X, bounds.Y, bounds.Width, bounds.Height,
                InteriorColor);
            DrawMist(context, bounds, mist);
            DrawMist(context, bounds, new Vector2(mist.Y, mist.X) * 1.5f);
            Vector2 vector = (base.Scene as OriginalLevelSceneRoot).Camera.Position;
            if (Opened)
            {
                vector = Vector2.Zero;
            }

            for (int i = 0; i < particles.Length; i++)
            {
                Vector2 vector2 = particles[i].Position + vector * 0.2f;
                vector2.X = Mod(vector2.X, bounds.Width);
                vector2.Y = Mod(vector2.Y, bounds.Height);
                SourcePrimitiveDrawing.Point(context, this, new Vector2(bounds.X, bounds.Y) + vector2,
                    particles[i].Color);
            }
        }

        private void DrawEdges(ISourceRenderContext context, IntRect bounds, PackedColor color)
        {
            AtlasEntry mTexture = engine.GameGraphics.GameAtlas["objects/heartdoor/edge"];
            AtlasEntry mTexture2 = engine.GameGraphics.GameAtlas["objects/heartdoor/top"];
            int num = (int)(offset % 8f);
            if (num > 0)
            {
                mTexture.GetSubtexture(0, 8 - num, 7, num, temp);
                SourceAtlasDrawing.DrawJustified(context, this, temp, new Vector2(bounds.Left + 4, bounds.Top),
                    new Vector2(0.5f, 0f), color, new Vector2(-1f, 1f));
                SourceAtlasDrawing.DrawJustified(context, this, temp, new Vector2(bounds.Right - 4, bounds.Top),
                    new Vector2(0.5f, 0f), color, new Vector2(1f, 1f));
            }

            for (int i = num; i < bounds.Height; i += 8)
            {
                mTexture.GetSubtexture(0, 0, 8, Math.Min(8, bounds.Height - i), temp);
                SourceAtlasDrawing.DrawJustified(context, this, temp, new Vector2(bounds.Left + 4, bounds.Top + i),
                    new Vector2(0.5f, 0f), color, new Vector2(-1f, 1f));
                SourceAtlasDrawing.DrawJustified(context, this, temp, new Vector2(bounds.Right - 4, bounds.Top + i),
                    new Vector2(0.5f, 0f), color, new Vector2(1f, 1f));
            }

            for (int j = 0; j < bounds.Width; j += 8)
            {
                SourceAtlasDrawing.DrawCentered(context, this, mTexture2,
                    new Vector2(bounds.Left + 4 + j, bounds.Top + 4),
                    color);
                SourceAtlasDrawing.DrawCentered(context, this, mTexture2,
                    new Vector2(bounds.Left + 4 + j, bounds.Bottom - 4), color, new Vector2(1f, -1f));
            }
        }

        public override void Render(ISourceRenderContext context)
        {
            PackedColor color = (Opened ? (PackedColor.White * 0.25f) : PackedColor.White);
            if (!Opened && TopSolid.Visible && BotSolid.Visible)
            {
                IntRect bounds = new IntRect((int)TopSolid.X, (int)TopSolid.Y, Size,
                    (int)(TopSolid.Height + BotSolid.Height));
                DrawInterior(context, bounds);
                DrawEdges(context, bounds, color);
            }
            else
            {
                if (TopSolid.Visible)
                {
                    IntRect bounds2 = new IntRect((int)TopSolid.X, (int)TopSolid.Y, Size, (int)TopSolid.Height);
                    DrawInterior(context, bounds2);
                    DrawEdges(context, bounds2, color);
                }

                if (BotSolid.Visible)
                {
                    IntRect bounds3 = new IntRect((int)BotSolid.X, (int)BotSolid.Y, Size, (int)BotSolid.Height);
                    DrawInterior(context, bounds3);
                    DrawEdges(context, bounds3, color);
                }
            }

            if (!(heartAlpha > 0f))
            {
                return;
            }

            float num = 12f;
            int num2 = (int)((float)(Size - 8) / num);
            int num3 = (int)Math.Ceiling((float)Requires / (float)num2);
            PackedColor color2 = color * heartAlpha;
            for (int i = 0; i < num3; i++)
            {
                int num4 = (((i + 1) * num2 < Requires) ? num2 : (Requires - i * num2));
                Vector2 vector = new Vector2(base.X + (float)Size * 0.5f, base.Y) +
                                 new Vector2((float)(-num4) / 2f + 0.5f, (float)(-num3) / 2f + (float)i + 0.5f) * num;
                if (Opened)
                {
                    if (i < num3 / 2)
                    {
                        vector.Y -= openAmount + 8f;
                    }
                    else
                    {
                        vector.Y += openAmount + 8f;
                    }
                }

                for (int j = 0; j < num4; j++)
                {
                    int num5 = i * num2 + j;
                    float num6 = engine.EasingArithmetic.CubeIn(ScalarMath.ClampedMap(Counter, num5, (float)num5 + 1f));
                    SourceAtlasDrawing.DrawCentered(context, this, icon[(int)(num6 * (float)(icon.Count - 1))],
                        vector + new Vector2((float)j * num, 0f), color2);
                }
            }
        }

        private float Mod(float x, float m)
        {
            return (x % m + m) % m;
        }
    }
}
