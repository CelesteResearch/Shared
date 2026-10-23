using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using JetBrains.Annotations;
using MTexture = Celeste.Graphics.Content.Atlas.AtlasEntry;

namespace Celeste.Graphics.Animation
{
    public partial class Sprite : SpriteImage
    {
        public class Animation
        {
            public float Delay;

            public MTexture[] Frames;

            public Chooser<string> Goto;
        }

        public float Rate = 1f;

        public bool UseRawDeltaTime;

        public Vector2? Justify;

        public Action<string> OnFinish;

        public Action<string> OnLoop;

        public Action<string> OnFrameChange;

        public Action<string> OnLastFrame;

        public Action<string, string> OnChange;

        private IAnimationFrameSource atlas;
        private readonly ISourceEngineContext engine;
        private ISourceRandom Random => ((ISourceRandomEnvironment)engine).Random;

        public IEnumerable<string> AnimationIds => animations.Keys;

        public string Path;

        public void SetFrameSource(IAnimationFrameSource source)
        {
            atlas = source;
        }

        [UsedImplicitly(ImplicitUseKindFlags.Access)]
        private Dictionary<string, Animation> animations;

        public Dictionary<string, Animation> Animations => animations;

        private Animation currentAnimation;

        private float animationTimer;

        private int width;

        private int height;

        public Vector2 Center => new(Width / 2f, Height / 2f);

        public bool Animating { get; private set; }

        public string CurrentAnimationID { get; private set; }

        public string LastAnimationID { get; private set; }

        public int CurrentAnimationFrame { get; private set; }

        public int CurrentAnimationTotalFrames
        {
            get
            {
                if (currentAnimation != null) return currentAnimation.Frames.Length;

                return 0;
            }
        }

        public override float Width => width;

        public override float Height => height;

        public Sprite(ISourceEngineContext engine,
            IAnimationFrameSource atlas, string path)
            : base(null, true)
        {
            this.atlas = atlas;
            this.engine = engine;
            Path = path;
            animations = new(StringComparer.OrdinalIgnoreCase);
            CurrentAnimationID = "";
        }

        public void Reset(IAnimationFrameSource atlas, string path)
        {
            this.atlas = atlas;
            Path = path;
            animations = new(StringComparer.OrdinalIgnoreCase);
            currentAnimation = null;
            CurrentAnimationID = "";
            OnFinish = null;
            OnLoop = null;
            OnFrameChange = null;
            OnChange = null;
            Animating = false;
        }

        public MTexture GetFrame(string animation, int frame)
        {
            return animations[animation].Frames[frame];
        }

        public override void Update()
        {
            if (!Animating) return;

            if (UseRawDeltaTime)
                animationTimer += engine.RawDeltaTime * Rate;
            else
                animationTimer += engine.DeltaTime * Rate;

            if (!(Math.Abs(animationTimer) >= currentAnimation.Delay)) return;

            CurrentAnimationFrame += Math.Sign(animationTimer);
            animationTimer -= Math.Sign(animationTimer) * currentAnimation.Delay;
            if (CurrentAnimationFrame < 0 || CurrentAnimationFrame >= currentAnimation.Frames.Length)
            {
                var currentAnimationId = CurrentAnimationID;
                if (OnLastFrame != null) OnLastFrame(CurrentAnimationID);

                if (!(currentAnimationId == CurrentAnimationID)) return;

                if (currentAnimation.Goto != null)
                {
                    CurrentAnimationID = currentAnimation.Goto.Choose(Random);
                    if (OnChange != null) OnChange(LastAnimationID, CurrentAnimationID);

                    LastAnimationID = CurrentAnimationID;
                    currentAnimation = animations[LastAnimationID];
                    if (CurrentAnimationFrame < 0)
                        CurrentAnimationFrame = currentAnimation.Frames.Length - 1;
                    else
                        CurrentAnimationFrame = 0;

                    SetFrame(currentAnimation.Frames[CurrentAnimationFrame]);
                    if (OnLoop != null) OnLoop(CurrentAnimationID);
                }
                else
                {
                    if (CurrentAnimationFrame < 0)
                        CurrentAnimationFrame = 0;
                    else
                        CurrentAnimationFrame = currentAnimation.Frames.Length - 1;

                    Animating = false;
                    var currentAnimationId2 = CurrentAnimationID;
                    CurrentAnimationID = "";
                    currentAnimation = null;
                    animationTimer = 0f;
                    if (OnFinish != null) OnFinish(currentAnimationId2);
                }
            }
            else
            {
                SetFrame(currentAnimation.Frames[CurrentAnimationFrame]);
            }
        }

        private void SetFrame(MTexture texture)
        {
            if (texture != Texture)
            {
                Texture = texture;
                if (width == 0) width = texture.FrameWidth;

                if (height == 0) height = texture.FrameHeight;

                if (Justify.HasValue)
                    Origin = new(Texture.FrameWidth * Justify.Value.X,
                        Texture.FrameHeight * Justify.Value.Y);

                if (OnFrameChange != null) OnFrameChange(CurrentAnimationID);
            }
        }

        public void SetAnimationFrame(int frame)
        {
            animationTimer = 0f;
            CurrentAnimationFrame = frame % currentAnimation.Frames.Length;
            SetFrame(currentAnimation.Frames[CurrentAnimationFrame]);
        }

        public void AddLoop(string id, string path, float delay)
        {
            animations[id] = new()
            {
                Delay = delay,
                Frames = GetFrames(path),
                Goto = new(id, 1f),
            };
        }

        public void AddLoop(string id, string path, float delay, params int[] frames)
        {
            animations[id] = new()
            {
                Delay = delay,
                Frames = GetFrames(path, frames),
                Goto = new(id, 1f),
            };
        }

        public void AddLoop(string id, float delay,
            params MTexture[] frames)
        {
            animations[id] = new()
            {
                Delay = delay,
                Frames = frames,
                Goto = new(id, 1f),
            };
        }

        public void Add(string id, string path, float delay, string into)
        {
            animations[id] = new()
            {
                Delay = delay,
                Frames = GetFrames(path),
                Goto = Chooser<string>.FromString<string>(into),
            };
        }

        public void Add(string id, string path, float delay, string into, params int[] frames)
        {
            animations[id] = new()
            {
                Delay = delay,
                Frames = GetFrames(path, frames),
                Goto = Chooser<string>.FromString<string>(into),
            };
        }

        public void Add(string id, float delay, string into, params MTexture[] frames)
        {
            animations[id] = new()
            {
                Delay = delay,
                Frames = frames,
                Goto = Chooser<string>.FromString<string>(into),
            };
        }

        public void Add(string id, string path)
        {
            animations[id] = new()
            {
                Delay = 0f,
                Frames = GetFrames(path),
                Goto = null,
            };
        }

        public void Add(string id, string path, float delay)
        {
            animations[id] = new()
            {
                Delay = delay,
                Frames = GetFrames(path),
                Goto = null,
            };
        }

        public void Add(string id, string path, float delay, params int[] frames)
        {
            animations[id] = new()
            {
                Delay = delay,
                Frames = GetFrames(path, frames),
                Goto = null,
            };
        }

        public void Add(string id, string path, float delay, Chooser<string> into)
        {
            animations[id] = new()
            {
                Delay = delay,
                Frames = GetFrames(path),
                Goto = into,
            };
        }

        public void Add(string id, float delay, Chooser<string> into,
            params MTexture[] frames)
        {
            animations[id] = new()
            {
                Delay = delay,
                Frames = frames,
                Goto = into,
            };
        }

        public void Add(string id, string path, float delay, Chooser<string> into,
            params int[] frames)
        {
            animations[id] = new()
            {
                Delay = delay,
                Frames = GetFrames(path, frames),
                Goto = into,
            };
        }

        private MTexture[] GetFrames(string path, int[] frames = null)
        {
            MTexture[] array;
            if (frames == null || frames.Length == 0)
            {
                array = [.. atlas.Frames(Path + path)];
            }
            else
            {
                var text = Path + path;
                var array2 =
                    new MTexture[frames.Length];
                for (var i = 0; i < frames.Length; i++)
                {
                    var atlasSubtexturesAt =
                        atlas.Frame(text, frames[i]);
                    if (atlasSubtexturesAt == null) throw new("Can't find sprite " + text + " with index " + frames[i]);

                    array2[i] = atlasSubtexturesAt;
                }

                array = array2;
            }

            width = Math.Max(array[0].FrameWidth, width);
            height = Math.Max(array[0].FrameHeight, height);
            return array;
        }

        public void ClearAnimations()
        {
            animations.Clear();
        }

        // LevelLoader's SpriteBank merge copies animation entries by key, retaining
        // the original Sprite object and its existing animations.
        public void MergeAnimationsFrom(Sprite other)
        {
            foreach (var pair in other.animations) animations[pair.Key] = pair.Value;
        }

        public void Play(string id, bool restart = false, bool randomizeFrame = false)
        {
            if (CurrentAnimationID != id || restart)
            {
                if (OnChange != null) OnChange(LastAnimationID, id);

                var lastAnimationId = CurrentAnimationID = id;
                LastAnimationID = lastAnimationId;
                currentAnimation = animations[id];
                Animating = currentAnimation.Delay > 0f;
                if (randomizeFrame)
                {
                    animationTimer = (float)Random.NextDouble() * currentAnimation.Delay;
                    CurrentAnimationFrame = Random.Next(currentAnimation.Frames.Length);
                }
                else
                {
                    animationTimer = 0f;
                    CurrentAnimationFrame = 0;
                }

                SetFrame(currentAnimation.Frames[CurrentAnimationFrame]);
            }
        }

        public void PlayOffset(string id, float offset, bool restart = false)
        {
            if (!(CurrentAnimationID != id || restart)) return;

            if (OnChange != null) OnChange(LastAnimationID, id);

            var lastAnimationId = CurrentAnimationID = id;
            LastAnimationID = lastAnimationId;
            currentAnimation = animations[id];
            if (currentAnimation.Delay > 0f)
            {
                Animating = true;
                var num = currentAnimation.Delay * currentAnimation.Frames.Length * offset;
                CurrentAnimationFrame = 0;
                while (num >= currentAnimation.Delay)
                {
                    CurrentAnimationFrame++;
                    num -= currentAnimation.Delay;
                }

                CurrentAnimationFrame %= currentAnimation.Frames.Length;
                animationTimer = num;
                SetFrame(currentAnimation.Frames[CurrentAnimationFrame]);
            }
            else
            {
                animationTimer = 0f;
                Animating = false;
                CurrentAnimationFrame = 0;
                SetFrame(currentAnimation.Frames[0]);
            }
        }

        public IEnumerator PlayRoutine(string id, bool restart = false)
        {
            Play(id, restart);
            return PlayUtil();
        }

        public IEnumerator ReverseRoutine(string id, bool restart = false)
        {
            Reverse(id, restart);
            return PlayUtil();
        }

        private IEnumerator PlayUtil()
        {
            while (Animating) yield return null;
        }

        public void Reverse(string id, bool restart = false)
        {
            Play(id, restart);
            if (Rate > 0f) Rate *= -1f;
        }

        public bool Has(string id)
        {
            if (id != null) return animations.ContainsKey(id);

            return false;
        }

        public void Stop()
        {
            Animating = false;
            currentAnimation = null;
            CurrentAnimationID = "";
        }

        internal Sprite(ISourceEngineContext engine)
            : base(null, true)
        {
            this.engine = engine;
        }

        public Sprite CreateClone()
        {
            return CloneInto(new(engine));
        }

        public Sprite CloneInto(
            Sprite clone)
        {
            clone.Texture = Texture;
            clone.Position = Position;
            clone.Justify = Justify;
            clone.Origin = Origin;
            clone.animations = new(animations, StringComparer.OrdinalIgnoreCase);
            clone.currentAnimation = currentAnimation;
            clone.animationTimer = animationTimer;
            clone.width = width;
            clone.height = height;
            clone.Animating = Animating;
            clone.CurrentAnimationID = CurrentAnimationID;
            clone.LastAnimationID = LastAnimationID;
            clone.CurrentAnimationFrame = CurrentAnimationFrame;
            return clone;
        }
    }
}
