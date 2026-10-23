using System;
using Celeste.Scene.Tagging;

namespace Celeste.Scene.Scheduling
{
    public readonly struct SceneUpdatePass
    {
        private readonly Func<SourceBitTag> tag;
        private readonly Func<SourceBitTag> requiredMembership;
        public int TagIndex => tag == null ? -1 : tag().ID;
        public bool CheckActive { get; }
        public int RequiredMembershipIndex => requiredMembership == null ? -1 : requiredMembership().ID;

        public SceneUpdatePass(bool checkActive)
        {
            tag = null;
            requiredMembership = null;
            CheckActive = checkActive;
        }

        public SceneUpdatePass(Func<SourceBitTag> tag, bool checkActive,
            Func<SourceBitTag> requiredMembership = null)
        {
            this.tag = tag ?? throw new ArgumentNullException(nameof(tag));
            this.requiredMembership = requiredMembership;
            CheckActive = checkActive;
        }
    }
}
