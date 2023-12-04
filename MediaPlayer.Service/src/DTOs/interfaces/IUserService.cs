using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaPlayer.Service.src.DTOs.interfaces;
using UserDTO;

namespace MediaPlayer.Service.src.DTOs
{
    public interface IUserService
    {
        List<GetUserDTO> GetAllFiles(int limit, int offset);
        GetUserDTO GetById(string itemId);
        void Add(AddUserDTO item);
        void Delete(string itemId);
        void Update(string itemId, UpdateUserDTO item);
    }
}