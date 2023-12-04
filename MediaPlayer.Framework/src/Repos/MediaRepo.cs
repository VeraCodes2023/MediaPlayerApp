using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaPlayerService;
using MediaPlayerCore;

namespace MediaPlayerFramework;
public class MediaRepo : IRepository<MediaFile>
{
    private List<MediaFile>? _medias { get; set; }
    private readonly AdminLogin _adminLogin;
    public MediaRepo(AdminLogin adminLogin, bool isAuth,Database database)
    {
        this._adminLogin= adminLogin;
        if(adminLogin.Authenticate())
        {
            isAuth=true;
            _medias=database.GetData<MediaFile>();
        }
       
    }
    public List<MediaFile> GetAllFiles(int limit, int offset)
    {
        if(_medias is not null)
        {
            try
            {
                List<MediaFile>filteredMedias=_medias.Skip(offset).Take(limit).ToList();
                return filteredMedias;
            }
            catch
            (System.Data.SqlClient.SqlException e)
            {
                Console.WriteLine($"Database connection error: {e.Message}");
                return new List<MediaFile>(); 
            }
            catch
            (Exception e)
            {
                Console.WriteLine($"Data retrieval failed: {e.Message}");
                return new List<MediaFile>();
            }
        }
        else
        {
            return new List<MediaFile>();
        }
    }
    public MediaFile GetById(string mediaId)
    {
        try
        {
            return _medias?.Find(m =>m.Id == mediaId)!;
        }
        catch(Exception e)
        {
            Console.WriteLine("Error occured: " + e.Message);
            return new MediaFile();
        }
    }
    public void Add(MediaFile media)
    {
        try
        {
            var existedMedia = _medias?.Any(m=>m.Id == media.Id);
            if((bool) !existedMedia!)
            {
                _medias?.Add(media);
            }
        }
        catch
        (Exception e)
        {
            Console.WriteLine("An error occurred:"+ e.Message);
        }
    }
   
    public void Delete(string mediaId)
    {
        if(_medias is not null){
        try
        {
            var targetMedia = _medias.Find(m => m.Id == mediaId);
            if(targetMedia is not null)
            {
                _medias.Remove(targetMedia);
                Console.WriteLine($"Media with Id {mediaId} has been removed from database.");
            }
        }
        catch(Exception e)
        {
            Console.WriteLine("Error occured: " + e.Message);
        }
        }
    }
    public void Update(string Id,UpdateMediaDTO item)
    {
        if(_medias is not null)
        {
            try
            {
            var targetMedia = _medias.Find(m=>m.Id == Id);
            {
                if(targetMedia is not null && item is not null)
                {
                    targetMedia.Title = item.Title;
                    targetMedia.Duration = item.Duration;
                    targetMedia.Volume = item.Volume;
                }
                else
                {
                    Console.WriteLine("Media not exist.");
                }
            }
            }
            catch(Exception e)
            {
                Console.WriteLine("Error occured: " + e.Message);
            }
        }
    }
}
