using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaPlayerCore;

namespace Servicelayer;

public class FakeDataBase
{
    
    public List<User> _fakeUsers { get; set; }
    public List<MediaFile>_fakeMedias {get; set;}
    private Dictionary<Type, object> _collections;
    public FakeDataBase()
    {
        _fakeUsers = new List<User>
        {
            new User("1", "User 1", UserType.Customer),
            new User("2", "User 2", UserType.Customer),
            new User("3", "User 3", UserType.Customer),
            new User("4", "User 4", UserType.Customer),
            new User("5", "User 5", UserType.Customer),
        };
       _fakeMedias = new List<MediaFile>
        {
            new Video("1","Movie1",2,MediaType.Video,5,6,false),
            new Video("2","Movie2",1,MediaType.Video,3,5,false),
            new Video("3","Movie3",4,MediaType.Video,4,6,false),
            new Video("4","Movie4",2,MediaType.Video,5,5,false),
        };
          _collections = new Dictionary<Type, object>
        {
            { typeof(MediaFile), _fakeMedias },
            { typeof(User), _fakeUsers },
        };
    }



    public virtual List<T>? GetData<T>()
    {
        Type type = typeof(T);

        if (_collections.TryGetValue(type, out object? collection))
        {
            return collection as List<T>;
        }

        throw new InvalidOperationException($"No collection found for type {type}");
    }

}
