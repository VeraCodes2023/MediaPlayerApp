using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace MediaPlayerCore;
public class Video: MediaFile
{
   public int Brightness {get;set;}
   public Video(string id, string title, decimal duration, MediaType type, int volume,int brightness,bool isplaying)
      :base(id, title, duration, type, volume,isplaying)
   {
         
      this.Brightness = brightness;
   }
}

