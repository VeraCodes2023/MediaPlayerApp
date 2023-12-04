using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaPlayerCore;
namespace MediaPlayerService;

public interface IUpdate<T>
{
    void Update(T entity);
}
