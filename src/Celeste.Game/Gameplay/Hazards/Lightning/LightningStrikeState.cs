using Celeste.Core.Display;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Scene.Entities;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Core.Mathematics;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;

namespace Celeste.Game.Gameplay.Hazards.Lightning
{
    public class LightningStrikeState : SceneEntityState
    {
        private class Node
        {
            public Vector2 Position;

            public float Size;

            public List<Node> Children;

            public Node(float x, float y, float size)
                : this(new Vector2(x, y), size)
            {
            }

            public Node(Vector2 position, float size)
            {
                Position = position;
                Children = new List<Node>();
                Size = size;
            }

            public void Wiggle(ISourceRandom rand)
            {
                Position.X += SourceRandomMath.Range(rand, -2, 2);
                if (Position.Y != 0f)
                {
                    Position.Y += SourceRandomMath.Range(rand, -1, 1);
                }

                foreach (Node child in Children)
                {
                    child.Wiggle(rand);
                }
            }

            public void Render(ISourceRenderContext context, object actualEntity, ISourceVectorArithmetic arithmetic,
                Vector2 offset, float scale)
            {
                float num = Size * scale;
                foreach (Node child in Children)
                {
                    Vector2 vector = arithmetic.SafeNormalize(child.Position - Position);
                    SourcePrimitiveDrawing.Line(context, actualEntity, offset + Position,
                        offset + child.Position + vector * num * 0.5f, PackedColor.White, num, arithmetic);
                    child.Render(context, actualEntity, arithmetic, offset, scale);
                }
            }
        }

        private readonly ISourceEngineContext engine;
        private bool on;

        private float scale;

        private ISourceRandom rand;

        private float strikeHeight;

        private Node strike;

        public LightningStrikeState(Vector2 position, int seed, float height, ISourceEngineContext engine,
            float delay = 0f)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            Position = position;
            base.Depth = 10010;
            this.engine = engine;
            rand = ((ISourceRandomProcessEnvironment)engine).RandomProcess.Factory.CreateSeeded(seed);
            strikeHeight = height;
            OwnedComponents.Add(new SimulationCoroutine(engine, Routine(delay)));
        }

        private IEnumerator Routine(float delay)
        {
            if (delay > 0f)
            {
                yield return delay;
            }

            scale = 1f;
            GenerateStikeNodes(-1, 10f);
            for (int j = 0; j < 5; j++)
            {
                on = true;
                yield return (1f - (float)j / 5f) * 0.1f;
                scale -= 0.2f;
                on = false;
                strike.Wiggle(rand);
                yield return 0.01f;
            }

            RemoveSelf();
        }

        private void GenerateStikeNodes(int direction, float size, Node parent = null)
        {
            if (parent == null)
            {
                parent = (strike = new Node(0f, 0f, size));
            }

            if (!(parent.Position.Y >= strikeHeight))
            {
                float num = direction * SourceRandomMath.Range(rand, -8, 20);
                float num2 = SourceRandomMath.Range(rand, 8, 16);
                float size2 = (0.25f + (1f - (parent.Position.Y + num2) / strikeHeight) * 0.75f) * size;
                Node node = new Node(parent.Position + new Vector2(num, num2), size2);
                parent.Children.Add(node);
                GenerateStikeNodes(direction, size, node);
                if (SourceRandomMath.NextFloat(rand) < 0.1f)
                {
                    Node node2 = new Node(parent.Position + new Vector2(0f - num, num2 * 1.5f), size2);
                    parent.Children.Add(node2);
                    GenerateStikeNodes(-direction, size, node2);
                }
            }
        }

        public override void Render(ISourceRenderContext context)
        {
            if (on)
            {
                strike.Render(context, this, ((ISourceVectorEnvironment)engine).VectorArithmetic, Position, scale);
            }
        }
    }
}
