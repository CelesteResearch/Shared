using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Rendering;
using Celeste.Scene.Entities;

namespace Celeste.Game.Gameplay.Hazards.Lightning
{
    public class LightningStrikeState : SceneEntityState
    {
        private class Node
        {
            public Vector2 Position;

            public readonly float Size;

            public readonly List<Node> Children;

            public Node(float x, float y, float size)
                : this(new(x, y), size)
            {
            }

            public Node(Vector2 position, float size)
            {
                Position = position;
                Children = [];
                Size = size;
            }

            public void Wiggle(ISourceRandom rand)
            {
                Position.X += SourceRandomMath.Range(rand, -2, 2);
                if (Position.Y != 0f) Position.Y += SourceRandomMath.Range(rand, -1, 1);

                foreach (var child in Children) child.Wiggle(rand);
            }

            public void Render(ISourceRenderContext context, object actualEntity, ISourceVectorArithmetic arithmetic,
                Vector2 offset, float scale)
            {
                var num = Size * scale;
                foreach (var child in Children)
                {
                    var vector = arithmetic.SafeNormalize(child.Position - Position);
                    SourcePrimitiveDrawing.Line(context, actualEntity, offset + Position,
                        offset + child.Position + vector * num * 0.5f, PackedColor.White, num, arithmetic);
                    child.Render(context, actualEntity, arithmetic, offset, scale);
                }
            }
        }

        private readonly ISourceEngineContext _engine;
        private bool _on;

        private float _scale;

        private readonly ISourceRandom _rand;

        private readonly float _strikeHeight;

        private Node _strike;

        public LightningStrikeState(Vector2 position, int seed, float height, ISourceEngineContext engine,
            float delay = 0f)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            Position = position;
            Depth = 10010;
            _engine = engine;
            _rand = ((ISourceRandomProcessEnvironment)engine).RandomProcess.Factory.CreateSeeded(seed);
            _strikeHeight = height;
            OwnedComponents.Add(new SimulationCoroutine(engine, Routine(delay)));
        }

        private IEnumerator Routine(float delay)
        {
            if (delay > 0f) yield return delay;

            _scale = 1f;
            GenerateStikeNodes(-1, 10f);
            for (var j = 0; j < 5; j++)
            {
                _on = true;
                yield return (1f - j / 5f) * 0.1f;
                _scale -= 0.2f;
                _on = false;
                _strike.Wiggle(_rand);
                yield return 0.01f;
            }

            RemoveSelf();
        }

        private void GenerateStikeNodes(int direction, float size, Node parent = null)
        {
            if (parent == null) parent = _strike = new(0f, 0f, size);

            if (!(parent.Position.Y >= _strikeHeight))
            {
                float num = direction * SourceRandomMath.Range(_rand, -8, 20);
                float num2 = SourceRandomMath.Range(_rand, 8, 16);
                var size2 = (0.25f + (1f - (parent.Position.Y + num2) / _strikeHeight) * 0.75f) * size;
                var node = new Node(parent.Position + new Vector2(num, num2), size2);
                parent.Children.Add(node);
                GenerateStikeNodes(direction, size, node);
                if (SourceRandomMath.NextFloat(_rand) < 0.1f)
                {
                    var node2 = new Node(parent.Position + new Vector2(0f - num, num2 * 1.5f), size2);
                    parent.Children.Add(node2);
                    GenerateStikeNodes(-direction, size, node2);
                }
            }
        }

        public override void Render(ISourceRenderContext context)
        {
            if (_on)
                _strike.Render(context, this, ((ISourceVectorEnvironment)_engine).VectorArithmetic, Position, _scale);
        }
    }
}
