using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaDTOs;
using MediaPlayer.Service.src.Dtos.interfaces;

namespace MediaPlayer.Service.src.DTOs.interfaces
{
    public interface IMediaService<T> where T : IMediaDTO
    {
        List< GetMediaDTO<T> > GetAllFiles(int limit, int offset);
        bool GetById(string itemId);
        void Add(AddMediaDTO<T> item);
        void Delete(string itemId);
        void Update(string itemId, UpdateMediaDTO<T> item );
    }
}