using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace MediaPlayerCore;

public class Audio: MediaFile
{
    public int SoundEffect {get;set;}
    public  Audio(string id, string title, decimal duration, MediaType type, int volume,int soundEffect,bool isplaying)
        :base(id, title, duration, type, volume,isplaying)
    {
        this.SoundEffect = soundEffect;
    }

   
}
