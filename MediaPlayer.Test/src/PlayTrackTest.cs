using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaPlayerCore;
using Servicelayer;
using Moq;
using Xunit;

namespace MediaPlayer.Test
{
    public class PlayTrackTest
    {
        [Fact]
        public void TestPlayMethod()
        {
            var playTrack = new Servicelayer.PlayTrack("5");
            Assert.True(playTrack is not null);
        }
        [Fact]
        public void TestPauseMethod()
        {
            var playTrack = new Servicelayer.PlayTrack("5");
            var result=playTrack.Pause();
            Assert.False(playTrack.IsPlaying);
        }
        [Fact]
         public void TestAddFileMethod()
         {
             var playTrack = new Servicelayer.PlayTrack("5");
             var added=playTrack.AddFile("10");
             Assert.True(added);
         }

        [Fact]
         public void TestStopMethod()
         {
             var playTrack = new Servicelayer.PlayTrack("5");
             playTrack.Stop();
             Assert.False(playTrack.IsPlaying);
         }

        [Fact]
        public void TestContinueMethod_WhenCurrentFileIsNull_ReturnsFalse()
        {
        var playTrack = new Servicelayer.PlayTrack("5");
        playTrack.CurrentFile = null;
        var result = playTrack.Continue();
        Assert.False(result);
        }
        [Fact]
        public void TestContinueMethod_WhenIsPlayingIsTrue_ReturnsFalse()
        {
        var playTrack = new Servicelayer.PlayTrack("5");
        playTrack.IsPlaying = true;
        var result = playTrack.Continue();
        Assert.False(result); 
        }
        [Fact]
        public void TestContinueMethod_WhenValidCondition_ReturnsTrueAndChangesPlayingStatus()
        {
            var playTrack = new Servicelayer.PlayTrack("5");
            playTrack.CurrentFile = new MediaFile();
            playTrack.IsPlaying = false;
            var result = playTrack.Continue();
            Assert.True(result); 
            Assert.True(playTrack.IsPlaying);
        }
    }
}