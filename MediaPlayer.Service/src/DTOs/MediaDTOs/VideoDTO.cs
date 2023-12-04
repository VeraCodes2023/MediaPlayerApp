using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaPlayer.Service.src.Dtos.interfaces;

namespace MediaDTOs
{
    public class VideoDTO:IMediaDTO
    {
        public string? Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Title { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Duration { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Volume { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Brightness {get;set;}
    }
}