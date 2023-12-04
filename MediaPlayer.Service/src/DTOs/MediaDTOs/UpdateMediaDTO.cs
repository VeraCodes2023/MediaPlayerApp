using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaPlayer.Service.src.Dtos.interfaces;
using MediaPlayerCore;



namespace MediaDTOs;
// public class UpdateMediaDTO
// {
//     public string? Title { get; set;}
//     public decimal Duration { get; set;}
//     public int Volume{ get; set; }

//     public UpdateMediaDTO(string title, decimal duration, int volume)
//     {
//         this.Title = title;
//         this.Duration = duration;
//         this.Volume = volume;
//     }
// }

public class UpdateMediaDTO<T> where T:IMediaDTO
{
    public string? Title { get; set;}
    public decimal Duration { get; set;}
    public int Volume{ get; set; }
    public T? OwnProperty { get; set; }

}