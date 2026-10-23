using Celeste.Audio.Framework;
using Celeste.Input.Runtime;

namespace Celeste.Framework.Startup
{
    public sealed class SourceFrameworkDispatcherProcess
    {
        private readonly SourceAudioMediaDispatchState state;
        private readonly SourceFnaInputProcess input;

        public SourceFrameworkDispatcherProcess(SourceAudioMediaDispatchState state,
            SourceFnaInputProcess input)
        {
            this.state = state;
            this.input = input;
        }

        public void Update()
        {
            lock (state.Streams)
            {
                for (var i = 0; i < state.Streams.Count; i++)
                {
                    var stream = state.Streams[i];
                    stream.Update();
                    if (stream.IsDisposed) i--;
                }
            }

            if (state.Microphones.MicList != null)
                for (var j = 0; j < state.Microphones.MicList.Count; j++)
                    state.Microphones.MicList[j].CheckBuffer();

            state.MediaPlayer.Update();
            if (state.ActiveSongChanged)
            {
                state.MediaPlayer.OnActiveSongChanged();
                state.ActiveSongChanged = false;
            }

            if (state.MediaStateChanged)
            {
                state.MediaPlayer.OnMediaStateChanged();
                state.MediaStateChanged = false;
            }

            if (input.TouchPanel.TouchDeviceExists) input.UpdateTouchPanel();
        }
    }
}
