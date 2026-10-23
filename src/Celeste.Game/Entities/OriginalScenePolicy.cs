using Celeste.Scene.Scheduling;
using Celeste.Game.Execution.Startup;

namespace Celeste.Game.Entities
{
    public static class OriginalScenePolicy
    {
        public static SceneUpdatePolicy CreatePlain(bool entityUpdateEvents = false)
        {
            var normal = new[] { new SceneUpdatePass(true) };
            return new SceneUpdatePolicy(new[] { normal }, new[] { normal }, new[] { normal },
                entityUpdateEvents: entityUpdateEvents);
        }

        public static SceneUpdatePolicy CreateLevel(OriginalGameTags sameTags, bool entityUpdateEvents = false)
        {
            var normal = new[] { new SceneUpdatePass(true) };
            var transition = new[] { new SceneUpdatePass(() => sameTags.TransitionUpdate, false) };
            var frozen = new[]
            {
                new SceneUpdatePass(() => sameTags.FrozenUpdate, true),
                new SceneUpdatePass(() => sameTags.PauseUpdate, true)
            };
            var paused = new[] { new SceneUpdatePass(() => sameTags.PauseUpdate, true) };
            var modes = new[] { normal, transition, frozen, paused };
            return new SceneUpdatePolicy(modes, modes, modes, "Celeste.PostUpdateHook",
                entityUpdateEvents: entityUpdateEvents);
        }
    }
}
