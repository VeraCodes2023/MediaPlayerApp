using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaPlayerCore;


namespace  UserDTO;
public class AddUserDTO
{    public string? Username { get; set; }
     public UserType Type {get; set;}
     public AddUserDTO(string userName, UserType type)
     {
        Username= userName;
        Type=type;

     }
    
}
