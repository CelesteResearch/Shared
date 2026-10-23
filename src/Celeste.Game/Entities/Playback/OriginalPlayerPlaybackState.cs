using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Graphics;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Simulation.Gameplay.Player.Presentation;
using Celeste.Simulation.Gameplay.Player.Presentation.Sprites;
using Celeste.Simulation.Gameplay.Tutorial.Replay;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Animation.Replay;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Game.Entities.Playback
{
// Classic map construction is separate from the reusable replay entity body.
    public sealed class OriginalPlayerPlaybackState : PlayerPlaybackState
    {
        public static OriginalPlayerPlaybackState CreateFromMapData(ISourceEngineContext engine,
            EntityData data, Vector2 offset, IPlayerPlaybackAudio audio)
        {
            Vector2 start = data.Position + offset;
            string tutorial = EntityAttributeReader.Attr(data.Values, "tutorial");
            var timeline = ((ISourcePlaybackTimelineEnvironment)engine).PlaybackTimelines[tutorial];
            return new OriginalPlayerPlaybackState(engine, start, timeline, data, offset, audio);
        }

        private OriginalPlayerPlaybackState(ISourceEngineContext engine, Vector2 start,
            List<CharacterReplayFrame> timeline, EntityData data, Vector2 offset,
            IPlayerPlaybackAudio audio)
            : base(engine, start, PlayerSpriteMode.Playback, timeline, audio)
        {
            if (data.Nodes != null && data.Nodes.Length != 0)
            {
                rangeMinX = Position.X;
                rangeMaxX = Position.X;
                Vector2[] nodes = data.NodesOffset(offset);
                for (int i = 0; i < nodes.Length; i++)
                {
                    Vector2 node = nodes[i];
                    rangeMinX = Math.Min(rangeMinX, node.X);
                    rangeMaxX = Math.Max(rangeMaxX, node.X);
                }
            }

            startDelay = 1f;
        }
    }
}
