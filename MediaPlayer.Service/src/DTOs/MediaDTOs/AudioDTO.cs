using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaPlayer.Service.src.Dtos.interfaces;

namespace MediaDTOs
{
    public class AudioDTO:IMediaDTO
    {
   
        public string? Id { get; set;}
        public string? Title {get; set; }
        public int Duration { get; set; }
        public int Volume { get; set; }
        public int SoundEffect {get;set;}
    }


}