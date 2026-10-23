using System;

namespace Celeste.Simulation.Runtime.Randomness
{
    // One session owns the retained SpriteBank random source. Optional adapters mirror
    // explicit Calc.PushRandom scopes into an external instrumentation stack.
    public sealed class SpriteRandomContext
    {
        private Random scoped;
        public Random RuntimeRandom { get; set; } = new();
        public Func<Random> OverrideRandom { get; set; }
        public Func<Random, IDisposable> ExternalPush { get; set; }
        public Random Proxy { get; }
        public Random Current => OverrideRandom?.Invoke() ?? scoped ?? RuntimeRandom;

        public SpriteRandomContext()
        {
            Proxy = new ProxyRandom(this);
        }

        public IDisposable Push(Random random)
        {
            if (random == null) throw new ArgumentNullException(nameof(random));
            return new Scope(this, random);
        }

        private sealed class Scope : IDisposable
        {
            private readonly SpriteRandomContext owner;
            private readonly Random previous;
            private readonly IDisposable external;
            private bool disposed;

            public Scope(SpriteRandomContext owner, Random random)
            {
                this.owner = owner;
                previous = owner.scoped;
                owner.scoped = random;
                try
                {
                    external = owner.ExternalPush?.Invoke(random);
                }
                catch
                {
                    owner.scoped = previous;
                    throw;
                }
            }

            public void Dispose()
            {
                if (disposed) return;
                disposed = true;
                try
                {
                    external?.Dispose();
                }
                finally
                {
                    owner.scoped = previous;
                }
            }
        }

        private sealed class ProxyRandom : Random
        {
            private readonly SpriteRandomContext owner;

            public ProxyRandom(SpriteRandomContext owner)
            {
                this.owner = owner;
            }

            public override int Next()
            {
                return owner.Current.Next();
            }

            public override int Next(int maxValue)
            {
                return owner.Current.Next(maxValue);
            }

            public override int Next(int minValue, int maxValue)
            {
                return owner.Current.Next(minValue, maxValue);
            }

            public override double NextDouble()
            {
                return owner.Current.NextDouble();
            }

            public override void NextBytes(byte[] buffer)
            {
                owner.Current.NextBytes(buffer);
            }

            public override void NextBytes(Span<byte> buffer)
            {
                owner.Current.NextBytes(buffer);
            }

            protected override double Sample()
            {
                return owner.Current.NextDouble();
            }
        }
    }
}
