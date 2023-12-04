using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaDTOs;
using MediaPlayer.Service.src.Dtos.interfaces;
using MediaPlayer.Service.src.DTOs.interfaces;
using MediaPlayerCore;
namespace Servicelayer;

public class MediaPlayerService : IMediaService<IMediaDTO>
{
    private List<MediaFile> _medias = new List<MediaFile>(); 
    
    public MediaPlayerService(){}
    public List<MediaFile>GetMedias
    {
        get
        {
           return new List<MediaFile>(_medias);
        }
    }

    private MediaFile ConvertAddMediaDTOToMediaFile(AddMediaDTO<IMediaDTO> item)
    {
        MediaFile mediaFile;

        if(item.OwnProperty is AudioDTO audioProperty)
        {
            string id = GenerateId();
            bool isPlaying = false;
            mediaFile = new Audio
            (
                id,
                item.Title!,
                item.Duration,
                MediaType.Audio,
                item.Volume,
                audioProperty.SoundEffect,
                isPlaying
            );
        }
        else if(item.OwnProperty is VideoDTO videoProperty)
        {
            string id = GenerateId();
            bool isPlaying = false;
                mediaFile = new Video
            (
                id,
                item.Title!,
                item.Duration,
                MediaType.Audio,
                item.Volume,
                videoProperty.Brightness,
                isPlaying
            );
        }
        else
        {
            mediaFile = new MediaFile();
        }

            return mediaFile;
    }

    public GetMediaDTO<IMediaDTO> MapMediaFileToGetMediaDTO(MediaFile mediaFile)
    {
        GetMediaDTO<IMediaDTO> getMediaDto = new GetMediaDTO<IMediaDTO>
        {
            Id = mediaFile.Id,
            Title = mediaFile.Title,
            Duration = mediaFile.Duration,
            Volume = mediaFile.Volume
        };

        return getMediaDto;
    }

    private static  string GenerateId()
    {
        DateTime now = DateTime.Now;
        string id=now.ToString("yyMMddHHmmssfff");
        id += new Random().Next(1000,9999);
        return id;
    }

    public List<GetMediaDTO<IMediaDTO>> GetAllFiles(int limit, int offset)
    {
        List<GetMediaDTO<IMediaDTO>> mediaList = new List<GetMediaDTO<IMediaDTO>>();
        var paginatedMedias = _medias.Skip(offset).Take(limit);
        foreach (var media in paginatedMedias)
        {
            GetMediaDTO<IMediaDTO> getMediaDto = MapMediaFileToGetMediaDTO(media);
            mediaList.Add(getMediaDto);
        }

        return mediaList;
    }

    public void Add(AddMediaDTO<IMediaDTO> item)
    {
        var targetMedia = _medias.Find(m => m.Title == item.Title);
        if (targetMedia != null)
        {
            Console.WriteLine("Media already existed.");
        }
        else
        {
            MediaFile newMediaFile = ConvertAddMediaDTOToMediaFile(item);
            _medias.Add(newMediaFile);
            Console.WriteLine("Media added successfully.");
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
            else
            {
                Console.WriteLine($"Media with Id {mediaId} not existed.");
            }
        }
        catch(Exception e)
        {
            Console.WriteLine("Error occured: " + e.Message);
        }
        }
    }
    public void Update(string itemId, UpdateMediaDTO<IMediaDTO> item)
    {
        try
        {
            MediaFile mediaToUpdate = _medias.Find(m => m.Id == itemId)!;
            if (_medias is not null && mediaToUpdate != null)
            {
                mediaToUpdate.Title = item.Title;
                mediaToUpdate.Duration = item.Duration;
                mediaToUpdate.Volume = item.Volume;
                Console.WriteLine("Media updated successfully.");
            }
            else
            {
                    Console.WriteLine("Media with specified itemId not found.");
            }
        }
        catch(Exception e)
        {
            Console.WriteLine("Error occurred: " + e.Message);
        }
    }

    public bool GetById(string itemId)
    {
         try
        {
            MediaFile mediaFile = _medias?.Find(m => m.Id == itemId)!;
           if (mediaFile != null)
            {
                Console.WriteLine("Media with ID {itemId} has been found.");
                return true;
            }
            else
            {
               Console.WriteLine("Media with ID {itemId} has not been found.");
               return false;
            }

        }
        catch(Exception e)
        {
            Console.WriteLine("Error occured: " + e.Message);
            return false;
        }
    }

  
}
