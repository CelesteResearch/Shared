using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Graphics.Animation.Replay;
using Celeste.Simulation.Gameplay.Player.Presentation.Sprites;
using Celeste.Simulation.Gameplay.Tutorial.Replay;

namespace Celeste.Game.Entities.Playback
{
// Classic map construction is separate from the reusable replay entity body.
    public sealed class OriginalPlayerPlaybackState : PlayerPlaybackState
    {
        public static OriginalPlayerPlaybackState CreateFromMapData(ISourceEngineContext engine,
            EntityData data, Vector2 offset, IPlayerPlaybackAudio audio)
        {
            var start = data.Position + offset;
            var tutorial = EntityAttributeReader.Attr(data.Values, "tutorial");
            var timeline = ((ISourcePlaybackTimelineEnvironment)engine).PlaybackTimelines[tutorial];
            return new(engine, start, timeline, data, offset, audio);
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
                var nodes = data.NodesOffset(offset);
                for (var i = 0; i < nodes.Length; i++)
                {
                    var node = nodes[i];
                    rangeMinX = Math.Min(rangeMinX, node.X);
                    rangeMaxX = Math.Max(rangeMaxX, node.X);
                }
            }

            startDelay = 1f;
        }
    }
}
