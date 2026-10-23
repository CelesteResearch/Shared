using Celeste.Game.Execution.Startup;
using Celeste.Scene.Scheduling;

namespace Celeste.Game.Entities
{
    public static class OriginalScenePolicy
    {
        public static SceneUpdatePolicy CreatePlain(bool entityUpdateEvents = false)
        {
            var normal = (SceneUpdatePass[])[new(true)];
            return new([normal], [normal], [normal],
                entityUpdateEvents: entityUpdateEvents);
        }

        public static SceneUpdatePolicy CreateLevel(OriginalGameTags sameTags, bool entityUpdateEvents = false)
        {
            var normal = (SceneUpdatePass[])[new(true)];
            var transition = (SceneUpdatePass[])[new(() => sameTags.TransitionUpdate, false)];
            var frozen = (SceneUpdatePass[])
            [
                new(() => sameTags.FrozenUpdate, true),
                new(() => sameTags.PauseUpdate, true),
            ];
            var paused = (SceneUpdatePass[])[new(() => sameTags.PauseUpdate, true)];
            var modes = (SceneUpdatePass[][])[normal, transition, frozen, paused];
            return new(modes, modes, modes, "Celeste.PostUpdateHook",
                entityUpdateEvents: entityUpdateEvents);
        }
    }
}
