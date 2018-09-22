using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesInfo.Interfaces
{
    public interface IAudio
    {
        void Play(string pathToAudioFile);
        void Play();
        void Pause();
        Action OnFinishedPlaying { get; set; }
    }
}
