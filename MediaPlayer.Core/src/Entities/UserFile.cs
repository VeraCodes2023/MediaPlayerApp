using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace MediaPlayerCore;
public class User 
{
    public string? Id{ get; set; }
    public string? Username { get; set; }
    public UserType Type {get; set;}
    public User(string id,string username, UserType type)
    {
        this.Id=id;
        this.Username = username;
        this.Type = type;
    }
}
   


