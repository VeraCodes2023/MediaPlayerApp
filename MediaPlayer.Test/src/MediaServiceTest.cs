using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Servicelayer;
using MediaPlayerCore;
using Moq;
using MediaDTOs;
using MediaPlayer.Service.src.Dtos.interfaces;

namespace MediaPlayer.Test
{
  public class MediaServicecTest
  {
    [Fact]
    public void Add_MediaToList_WhenMediaDoesNotExist()
    {
      var mediaService =  new Servicelayer.MediaPlayerService();
      var addMediaDTO = new AddMediaDTO<IMediaDTO>
      {
        Title = "Song1",
        Duration = 3,
        Volume = 3,
        OwnProperty = new AudioDTO {SoundEffect = 4 }
      };
      mediaService.Add(addMediaDTO);
        var updatedMediaList = mediaService.GetAllFiles(limit: 10, offset: 0);
      Assert.True( updatedMediaList.Count >0);
    }
    [Fact]
    public void Add_MediaToList_WhenMediaAlreadyExist()
    {
      var mediaService=new Servicelayer.MediaPlayerService();
      var existingMediaDTO = new AddMediaDTO<IMediaDTO>
        {
          Title = "Song1",
          Duration = 3,
          Volume = 3,
          OwnProperty = new AudioDTO {SoundEffect = 4 }
        };
        mediaService.Add(existingMediaDTO);
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        var newMediaDTO = new AddMediaDTO<IMediaDTO>
        {
          Title = "Song1",
          Duration = 3,
          Volume = 3,
          OwnProperty = new AudioDTO {SoundEffect = 4 }
        };
        mediaService.Add(newMediaDTO);
        var output = stringWriter.ToString().Trim();
        Assert.Contains("Media already existed.", output);
    }
    [Fact]
    public void Delete_Media_WhenCollectionAndMediaExist()
    {
      var mediaService=new Servicelayer.MediaPlayerService();
      var newMediaDTO = new AddMediaDTO<IMediaDTO>
      {
          Title = "Song1",
          Duration = 3,
          Volume = 3,
          OwnProperty = new AudioDTO {Id="1", SoundEffect = 4 }
      };
      mediaService.Add(newMediaDTO);
      mediaService.Delete("1");
      var stringWriter = new StringWriter();
      var output = stringWriter.ToString().Trim();
      // Assert.Contains("Media has been removed from database.", output);
      var medias=mediaService.GetMedias;
      foreach(MediaFile m in medias)
      {
        Console.WriteLine(m.Id);
      }
      //var deletedMedia = mediaService.GetById("2311271048150682214");
      //Assert.Null(deletedMedia);
    }
    //[Fact]
    // public void Delete_Media_WhenCollectionExistsButMediaDoesNotExist()
    // {
    //     var mediaService=new Servicelayer.MediaPlayerService();
    //     mediaService.Delete("1");
    //     var deletedMedia = mediaService.GetById("1");
    //     Assert.Null(deletedMedia);
    // }
   // [Fact]
    // public void GetById_ReturnsCorrectMedia_WhenMediaExists()
    // {
    //     var mediaService=new Servicelayer.MediaPlayerService();
    //     var newMediaDTO = new AddMediaDTO<IMediaDTO>
    //     {
    //         Title = "Song1",
    //         Duration = 3,
    //         Volume = 3,
    //         OwnProperty = new AudioDTO { Id = "1", SoundEffect = 4 }
    //     };
    //     mediaService.Add(newMediaDTO);
    //     var result = mediaService.GetById("1");
    //     Assert.True(result);
    // }
    [Fact]
    public void GetById_ReturnsNull_WhenMediaDoesNotExist()
    {
        var mediaService=new Servicelayer.MediaPlayerService();
        var result = mediaService.GetById("1000");
        Assert.Null(result);
    }
    [Fact]
    public void GetById_ReturnsNull_WhenMediaCollectionIsNull()
    {
        var mediaService=new Servicelayer.MediaPlayerService();
        mediaService.GetType().GetField("_medias", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(mediaService,null);
        var result = mediaService.GetById("1");
        Assert.Null(result);
    }
    [Fact]
    public void GetAllFiles_ReturnsFilteredFiles_WhenMediaExists()
    {
      var mediaService=new Servicelayer.MediaPlayerService();
      var newMedia1 = new AddMediaDTO<IMediaDTO>
      {
          Title = "Movie1",
          Duration = 2,
          Volume = 5,
          OwnProperty = new VideoDTO { Id = "1", Brightness = 6 }
      };
      var newMedia2 = new AddMediaDTO<IMediaDTO>
      {
          Title = "Movie2",
          Duration = 1,
          Volume = 3,
          OwnProperty = new VideoDTO { Id = "2", Brightness = 5 }
      };
      var newMedia3 = new AddMediaDTO<IMediaDTO>
      {
          Title = "Movie3",
          Duration = 4,
          Volume = 4,
          OwnProperty = new VideoDTO { Id = "3", Brightness = 6 }
      };
      var newMedia4 = new AddMediaDTO<IMediaDTO>
      {
          Title = "Movie4",
          Duration = 2,
          Volume = 5,
          OwnProperty = new VideoDTO { Id = "4", Brightness = 5 }
      };
      mediaService.Add(newMedia1);
      mediaService.Add(newMedia2);
      mediaService.Add(newMedia3);
      mediaService.Add(newMedia4);
      var result = mediaService.GetAllFiles(2, 0);
      Assert.Equal(2, result.Count);
      Assert.Equal("Movie1", result[0].Title);
      Assert.Equal("Movie2", result[1].Title);
    }
    [Fact]
    public void GetAllFiles_ReturnsEmptyList_WhenNoMediaExist()
    {
          var mediaService=new Servicelayer.MediaPlayerService();
          var result = mediaService.GetAllFiles(10, 0);
          Assert.True(result.Count==0);
    }
    [Fact]
    public void GetData_ThrowsException_WhenInvalidTypeProvided()
    {
        var mockDatabase = new Mock<FakeDataBase>();
        var invalidType = typeof(WrongType); 
        mockDatabase.Setup(x => x.GetData<WrongType>()).Throws<InvalidOperationException>();
        Assert.Throws<InvalidOperationException>(() => mockDatabase.Object.GetData<WrongType>());
    }
  }

    internal class WrongType{}
}
