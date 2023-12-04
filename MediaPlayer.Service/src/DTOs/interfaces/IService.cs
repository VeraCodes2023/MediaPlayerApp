using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaPlayer.Service.src.DTOs.interfaces
{
    public interface IService<T>
    {
        List<T> GetAllFiles(int limit, int offset);
        T GetById(string itemId);
        void Add(T item);
        void Delete(string itemId);
        void Update(string itemId, T item);
    }
}

