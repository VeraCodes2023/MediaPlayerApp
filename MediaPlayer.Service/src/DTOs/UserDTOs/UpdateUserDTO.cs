using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace  UserDTO;
public class UpdateUserDTO
{
    public string? Username { get; set; }
    public UpdateUserDTO(string userName)
    {
        this.Username = userName;
    }
    
}

