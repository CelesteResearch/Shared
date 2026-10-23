namespace Celeste.Core.Audio
{
    public interface ISourceCassetteTimingPolicy
    {
        int TransformLeadBeats(int leadBeats);
    }
}
