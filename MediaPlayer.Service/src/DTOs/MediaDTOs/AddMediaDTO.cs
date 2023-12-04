using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaPlayer.Service.src.Dtos.interfaces;

namespace MediaDTOs
{
    public class AddMediaDTO<T> where T:IMediaDTO
    {
        public string? Title { get; set;}
        public decimal Duration { get; set;}
        public int Volume{ get; set; }
        public T? OwnProperty { get; set; }
    }
}