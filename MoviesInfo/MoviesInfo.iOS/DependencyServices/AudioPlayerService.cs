using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AVFoundation;
using Foundation;
using MoviesInfo.Interfaces;
using MoviesInfo.iOS;
using MoviesInfo.iOS.DependencyServices;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(AudioPlayerService))]
namespace MoviesInfo.iOS.DependencyServices
{
    public class AudioPlayerService : IAudio
    {
        private AVAudioPlayer _audioPlayer = null;
        public Action OnFinishedPlaying { get; set; }

        public AudioPlayerService()
        {
        }
      
        public void Play(string pathToAudioFile)
        {
            // Check if _audioPlayer is currently playing  
            if (_audioPlayer != null)
            {
                _audioPlayer.FinishedPlaying -= Player_FinishedPlaying;
                _audioPlayer.Stop();
            }

            string localUrl = pathToAudioFile;
            _audioPlayer = AVAudioPlayer.FromUrl(NSUrl.FromFilename(localUrl));
            _audioPlayer.FinishedPlaying += Player_FinishedPlaying;
            _audioPlayer.Play();
        }

        private void Player_FinishedPlaying(object sender, AVStatusEventArgs e)
        {
            OnFinishedPlaying?.Invoke();
        }

        public void Pause()
        {
            _audioPlayer?.Pause();
        }

        public void Play()
        {
            _audioPlayer?.Play();
        }

       
    }
}