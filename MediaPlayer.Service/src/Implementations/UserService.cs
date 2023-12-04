using MediaPlayer.Service.src.AutoMapper;
using MediaPlayer.Service.src.DTOs;
using MediaPlayer.Service.src.DTOs.interfaces;
using MediaPlayerCore;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using UserDTO;

namespace Servicelayer;

public class UserService : IUserService
{
    private List<User> _users = new List<User>(); 
    public UserService(){}
    private static GetUserDTO ConvertToGetUserDto(User user)
    {
        return new GetUserDTO
        {
            Id = user.Id,
            Username= user.Username,
            Type= user.Type,
        };
    }
    private static  User ConvertUserDTOToUser(AddUserDTO addUserDto)
    {
        User user = new User(GenerateId(),addUserDto.Username!,addUserDto.Type);
        return user;
    }
 
    private static  string GenerateId()
    {
        DateTime now = DateTime.Now;
        string id=now.ToString("yyMMddHHmmssfff");
        id += new Random().Next(1000,9999);
        return id;
    }
    public void Add(AddUserDTO user)
    {
        try
        {
            var existedUser=_users?.Any(u=>u.Id ==user.Username);
            if( (bool) !existedUser !)
            {
                var newUser=ConvertUserDTOToUser(user);
                _users?.Add(newUser);
                Console.WriteLine($"User {newUser.Username} added.");
            }
            else
            {
                Console.WriteLine("User already existed.");
                return;
            }
            
        }
        catch(Exception e)
        {
        Console.WriteLine("An error occurred:"+ e.Message);
        }
    }
    public List<GetUserDTO>GetUsers
    {
        get 
        {
            return _users.Select(user => ConvertToGetUserDto(user)).ToList();
        }
    }
   
    public void Delete(string userId)
    {
        if(_users is not null)
        {
            try
            {
                var targetUser = _users.Find(u=>u.Id == userId);
                if(targetUser is not null)
                {
                    var userDto = ConvertToGetUserDto(targetUser);
                    _users.Remove(targetUser);
                    Console.WriteLine($"User with Id {userId} has been removed from database.");
                }
                else
                {
                    Console.WriteLine("Can not find the user.");
                }
            
            }
            catch
            (Exception e)
            {
                Console.WriteLine("Error occured" + e.Message);
            }
        }
        else
        {
            Console.WriteLine("User collection not exists.");
        }
        
    }

    public List<GetUserDTO> GetAllFiles(int limit, int offset)
    {
        if(_users is not null)
        {
            try
            {
                List<User> filteredUsers = _users.Skip(offset).Take(limit).ToList();
                List<GetUserDTO> userDTOs = filteredUsers.Select(user => ConvertToGetUserDto(user)).ToList();
                return userDTOs;
            }
            catch(System.Data.SqlClient.SqlException e)
            {
                Console.WriteLine($"Database connection error: {e.Message}");
                return new List<GetUserDTO>(); 
            }
            catch(Exception e)
            {
                Console.WriteLine($"Data retrieval failed: {e.Message}");
                return new List<GetUserDTO>(); 
            }

        }
        else
        {
            return new List<GetUserDTO>(); 
        }
    
    }

    public GetUserDTO GetById(string userId)
    {
        try
        {
            var user = _users?.Find(u => u.Id == userId)!;
            if(user is not null)
            {
                return ConvertToGetUserDto(user);
            }
            else
            {
                Console.WriteLine("User not found.");
                return new GetUserDTO();
            }
      
        }
        catch(Exception e)
        {
                Console.WriteLine("Error occured: " + e.Message);
                return new GetUserDTO();
        }
        
    }
    public void Update(string id, UpdateUserDTO item)
    {
        if(_users is not null)
        {
            try
            {
                var targetUser = _users.Find(u=> u.Id == id);
                if(targetUser is not null && item is not null)
                {
                    targetUser.Username = item.Username;
                }
                else
                {
                    Console.WriteLine("User not exist.");
                }
            }
            catch
            (Exception e)
            {
                Console.WriteLine("Error occured" + e.Message);
            }
        }
    }
}
