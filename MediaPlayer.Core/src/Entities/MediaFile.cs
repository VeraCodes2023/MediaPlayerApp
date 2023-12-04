using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace  MediaPlayerCore;

public class MediaFile
{
    public string? Id {get; set; }
    public string? Title {get; set; }
    public decimal Duration { get; set; }
    public MediaType Type { get; set; }
    public int Volume{ get; set; }
    public bool IsPlaying {get;set;}
    public MediaFile(){}
    public MediaFile(string id, string title, decimal duration,MediaType type,int volume,bool isplaying )
    {
        this.Id = id;
        this.Title = title;
        this.Duration = duration;
        this.Type = type;
        this.Volume = volume;
        this.IsPlaying = isplaying;
    }

    public MediaFile(string id, string title)
    {
        Id = id;
        Title = title;
    }
}
