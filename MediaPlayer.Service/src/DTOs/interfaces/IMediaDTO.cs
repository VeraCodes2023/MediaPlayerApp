using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaPlayer.Service.src.Dtos.interfaces
{
    public interface IMediaDTO{
        public string? Id{get;set;}
        string Title { get; set; }
        int Duration { get; set; }
        int Volume { get; set; }
    }
}