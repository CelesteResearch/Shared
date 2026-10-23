using Celeste.Core.Mathematics;
using Celeste.Simulation.Runtime.Session.Maps;

// ReSharper disable once CheckNamespace
namespace Celeste.Simulation.Runtime.Session
{
    public sealed partial class ChapterCompletionSession
    {
        private readonly IChapterSessionData sourceSessionMaps;
        private readonly IChapterSessionFactory sourceSessionFactory;
        private readonly ISourceVectorEnvironment sourceVectorEnvironment;

        public bool IsCreatedBy(IChapterSessionFactory factory)
        {
            return ReferenceEquals(sourceSessionFactory, factory);
        }

        public ChapterCompletionSession(IChapterSessionData actualMaps,
            IChapterSessionFactory actualFactory,
            ISourceVectorEnvironment actualVectorEnvironment)
        {
            sourceSessionMaps = actualMaps;
            sourceSessionFactory = actualFactory;
            sourceVectorEnvironment = actualVectorEnvironment;
        }
    }
}
