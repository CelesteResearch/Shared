using Celeste.Simulation.Runtime.Session.Maps;

namespace Celeste.Simulation.Runtime.Session
{
    public sealed partial class ChapterCompletionSession
    {
        private readonly IChapterSessionData sourceSessionMaps;
        private readonly IChapterSessionFactory sourceSessionFactory;
        private readonly global::Celeste.Core.Mathematics.ISourceVectorEnvironment sourceVectorEnvironment;

        public bool IsCreatedBy(IChapterSessionFactory factory) => ReferenceEquals(sourceSessionFactory, factory);

        public ChapterCompletionSession(IChapterSessionData actualMaps,
            IChapterSessionFactory actualFactory,
            global::Celeste.Core.Mathematics.ISourceVectorEnvironment actualVectorEnvironment)
        {
            sourceSessionMaps = actualMaps;
            sourceSessionFactory = actualFactory;
            sourceVectorEnvironment = actualVectorEnvironment;
        }
    }
}
