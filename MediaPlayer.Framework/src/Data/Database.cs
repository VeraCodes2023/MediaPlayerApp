using MediaPlayerCore;
using Servicelayer;
public class Database
{
    public List<User> Users { get; set; }
    public List<MediaFile> Medias { get; set; }
    public List<PlayTrack> PlayTracks { get; set; }
    private Dictionary<Type, object> _collections;
    public Database()
    {
        Users= new List<User>{
            new User( "1", "user1", UserType.Admin),
            new User( "2", "user2", UserType.Admin),
            new User( "3", "user3", UserType.Admin),
            new User( "4", "user4", UserType.Customer),
            new User( "5", "user4", UserType.Customer),
            new User( "6", "user4", UserType.Customer),
            new User( "7", "user4", UserType.Customer),
            new User( "8", "user4", UserType.Customer),
            new User( "9", "user4", UserType.Customer),
            new User( "10", "user4", UserType.Customer),
            new User( "11", "user4", UserType.Customer),
            new User( "12", "user4", UserType.Customer)
        };

        Medias = new List<MediaFile>{
            new Video("1","Media 1", 97, MediaType.Video,20,12,false),
            new Video("2","Media 2", 45, MediaType.Video,20,12,false),
            new Video("3","Media 3", 42, MediaType.Video,20,12,false),
            new Video("4","Media 4", 67, MediaType.Video,20,12,false),
            new Video("5","Media 5", 34, MediaType.Video,20,12,false),
            new Video("6","Media 6", 25, MediaType.Video,20,12,false),
            new Audio("7","Media 7", 37, MediaType.Video,20,12,false),
            new Audio("8","Media 8", 129, MediaType.Video,20,12,false),
            new Audio("9","Media 9", 100, MediaType.Video,20,12,false),
            new Audio("10","Media 10", 234, MediaType.Video,20,12,false),
            new Audio("11","Media 11", 46, MediaType.Video,20,12,false),
            new Audio("12","Media 12", 57, MediaType.Video,20,12,false),
            new Audio("13","Media 13", 59, MediaType.Video,20,12,false),
            new Audio("14","Media 14", 144, MediaType.Video,20,12,false)
        };
        PlayTracks = new List<PlayTrack>{
            new PlayTrack("1"),
            new PlayTrack("2"),
            new PlayTrack("3")
        };
        _collections = new Dictionary<Type, object>
        {
            { typeof(MediaFile), Medias },
            { typeof(User), Users },
            { typeof(PlayTrack), PlayTracks}
        };
    }

    public List<T>? GetData<T>()
    {
        Type type = typeof(T);

        if (_collections.TryGetValue(type, out object? collection))
        {
            return collection as List<T>;
        }

        throw new InvalidOperationException($"No collection found for type {type}");
    }
   
}
