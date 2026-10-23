namespace Celeste.Audio.IO
{
    public interface ISourceMediaPlayerIO
    {
        void XNA_SetSongVolume(float volume);
        uint XNA_VisualizationEnabled();
        void XNA_EnableVisualization(uint enabled);
        void XNA_PauseSong();
        void XNA_ResumeSong();
        void XNA_StopSong();
        void XNA_GetSongVisualizationData(float[] frequencies, float[] samples, uint count);
        uint XNA_GetSongEnded();
        void XNA_SongQuit();
        void XNA_SongInit();
        float XNA_PlaySong(string handle);
    }
}
