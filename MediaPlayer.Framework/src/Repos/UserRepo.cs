using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaPlayerCore;
using MediaPlayerService;

namespace MediaPlayerFramework;
public class UserRepo: IRepository<User> 
{
    private List<User>? _users {get;set;}
    private readonly AdminLogin _adminLogin;
    public UserRepo(){}
    public UserRepo(AdminLogin adminLogin, bool isAuth,Database database)
    {
         this._adminLogin= adminLogin;
          if(adminLogin.Authenticate())
          {
            isAuth=true;
            _users = database.GetData<User>();
          }
    }
    
    public List<User> GetAllFiles(int limit, int offset)
    {
        if(_users is not null)
        {
            try
            {
                List<User> filteredUsers = _users.Skip(offset).Take(limit).ToList();
                return filteredUsers;
            }
            catch(System.Data.SqlClient.SqlException e)
            {
                Console.WriteLine($"Database connection error: {e.Message}");
                return new List<User>(); 
            }
            catch(Exception e)
            {
                Console.WriteLine($"Data retrieval failed: {e.Message}");
                return new List<User>(); 
            }

        }
        else
        {
            return new List<User>(); 
        }
       
    }
    public User GetById(string userId)
    {
        return _users?.Find(u => u.Id == userId)!;
    }
    public void Add(User user)
    {
        try
        {
            var existedUser=_users?.Any(u=>u.Id ==user.Id);
            if((bool)!existedUser!)
            {
                _users?.Add(user);
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
    public void Delete(string userId)
    {
        if(_users is not null)
        {
            try
            {
                var targetUser = _users.Find(u=>u.Id == userId);
                if(targetUser is not null)
                {
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
        
    }

   
}
