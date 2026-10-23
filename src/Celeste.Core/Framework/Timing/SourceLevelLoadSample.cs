namespace Celeste.Core.Framework.Timing
{
    // Bounded aggregate: nested loads share one elapsed interval; first/last names are original references.
    public struct SourceLevelLoadSample
    {
        public int Count, OwnedWrites, BorrowedWrites, TextureUploads, BufferUploads;
        public int TextureCreates, BufferCreates, TextureDisposes, BufferDisposes;
        public int Reads, ReadSplits, Submissions;
        public long ElapsedTicks, TextureBytes, BufferBytes, SubmitTicks;
        public long SetupTicks, MapEntityTicks, MapRemainderTicks, ActorPrepareTicks;
        public long EntityCommitTicks, ActorFinalizeTicks, ObjectTileTicks, PostLoadTicks;
        public long MapClutterTicks, MapTriggersTicks, MapDecalsTicks;
        public long AwakeTicks;
        public long PlatformAttachmentTicks, GroupAwakeTicks;
        public string FirstRoom, LastRoom;
    }
}
