using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaPlayerService;

namespace MediaPlayerCore;
public interface IRepository<T> 
{
    List<T> GetAllFiles(int limit, int offset);
    T GetById(string mediaId);
    void Add(T item);
    void Delete(string itemId);
}
