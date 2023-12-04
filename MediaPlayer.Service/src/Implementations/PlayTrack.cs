using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaPlayerCore;
namespace Servicelayer;
public class PlayTrack
{
    public HashSet<string> FileIds { get; set; }
    public string UserId { get; set; }
    public MediaFile? CurrentFile { get; set; }
    public int CurrentPosition { get; set; }
    public bool IsPlaying { get; set; }

    private Timer _playbackTimer;

    public PlayTrack(string userId)
    {
        UserId = userId;
        FileIds = new();
        IsPlaying = false;
        _playbackTimer = new Timer(TimerCallback, null, Timeout.Infinite, 500);
    }

    public bool AddFile(string fileId)
    {
        return FileIds.Add(fileId);
    }

    public bool Play(MediaFile file)
    {
        CurrentFile = file;
        Console.WriteLine($"Should play file {CurrentFile?.Title}, max {CurrentFile?.Duration}");
        IsPlaying = _playbackTimer.Change(0, 500);
        if (IsPlaying) Console.WriteLine($"Start playing file {CurrentFile?.Title}, max {CurrentFile?.Duration}");
        return true;
    }

    public bool Pause()
    {
        IsPlaying = false;
        _playbackTimer.Change(Timeout.Infinite, Timeout.Infinite);
        Console.WriteLine($"Pause playing file {CurrentFile?.Title}, current position {CurrentPosition}");
        return true;
    }

    public bool Stop()
    {
        CurrentPosition = 0;
        IsPlaying = false;
        _playbackTimer.Change(Timeout.Infinite, Timeout.Infinite);
        Console.WriteLine($"Stop playing file {CurrentFile?.Title} , current position {CurrentPosition}");
        CurrentFile = null;
        return true;
    }

    public bool Continue()
    {
        if (CurrentFile == null || IsPlaying)
        {
            return false;
        }

        IsPlaying = true;
        _playbackTimer.Change(0, 500); // Resume the timer
        Console.WriteLine("Continue to play file");
        return true;
    }

    private void TimerCallback(object? state)
    {
        if (IsPlaying)
        {
            CurrentPosition++;

            if (CurrentFile is null || CurrentPosition >= CurrentFile.Duration)
            {
                Console.WriteLine("Playing file is completed");
                Stop();
            }
            else
            {
                Console.WriteLine($"On playing, current position {CurrentPosition}");
            }
        }
    }
}
