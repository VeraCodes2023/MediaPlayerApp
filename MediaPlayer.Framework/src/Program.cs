using Microsoft.Extensions.DependencyInjection;
using MediaPlayerService;
using MediaPlayerCore;
using MediaPlayerFramework;
using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using MediaDTOs;
using  UserDTO;
using MediaPlayerCore.UserDTO;
class Program 
{
    public static void Main()
    {
        // **********************userRepo starts 
        AdminLogin adminLogin = new AdminLogin(new User("9","newuser9",UserType.Admin));
        var database = new Database();
        var userRepo = new UserRepo(adminLogin,true,database);
        var allusers=userRepo.GetAllFiles(10,0);
        if(allusers is not null)
        Console.WriteLine(allusers.Count); // 10 
        userRepo.Add(new User("16", "user16", UserType.Customer));
        userRepo.Add(new User("17", "user17", UserType.Customer));
        userRepo.Add(new User("18", "user18", UserType.Customer));
        userRepo.Add(new User("19", "user19", UserType.Customer));
        userRepo.Add(new User("20", "user20", UserType.Customer));
        userRepo.GetById("20");
        userRepo.Delete("8");
        userRepo.Update("17", new UpdateUserDTO("Updated news"));
        // **********************userRepo ends
        // **********************mediaRepo starts 
        var mediaRepo = new MediaRepo(adminLogin,true,database);
        var allMedia=mediaRepo.GetAllFiles(5,0);
        if(allMedia is not null)
        Console.WriteLine(allMedia.Count);
        mediaRepo.Add(new Audio("14","Song 14", 56, MediaType.Video,22,13,true));
        mediaRepo.Add(new Audio("15","Song 15", 23, MediaType.Video,23,12,true));
        mediaRepo.Add(new Audio("16","Song 16", 66, MediaType.Video,24,17,true));
        mediaRepo.Add(new Audio("17","Song 17", 43, MediaType.Video,26,23,true));
        mediaRepo.Add(new Audio("18","Song 18", 54, MediaType.Video,27,16,true));
        mediaRepo.Add(new Audio("19","Song 19", 65, MediaType.Video,28,27,true));
        mediaRepo.GetById("18");
        mediaRepo.Delete("19");
        mediaRepo.Update("14", new UpdateMediaDTO("Updated 14", 300, 50));
        // **********************mediaRepo ends
        // **********************playtracks starts
        var myPlayTrack= new PlayTrack("2");
        myPlayTrack.Play(new Audio("19","Song 19", 65, MediaType.Video,28,27,true));
        myPlayTrack.Pause();
        myPlayTrack.Pause();
        myPlayTrack.Continue();
        myPlayTrack.AddFile("16");
        myPlayTrack.AddFile("17");
        myPlayTrack.AddFile("18");
        myPlayTrack.AddFile("19");
        // **********************playtracks ends
    
    }
}
