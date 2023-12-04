using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaPlayerCore;

namespace MediaPlayerService;
public class AdminLogin
{
    private User? _currentUser;
    public AdminLogin(User currnetUser)
    {
        this._currentUser = currnetUser;
    }
    public void SetCurrentUser(User user)
    {
        _currentUser = user;
    }
    public bool Authenticate()
    {
        if (_currentUser == null)
        {
            Console.WriteLine("User not set. Call SetCurrentUser before Authenticate.");
            return false;
        }
        else
        {
             Console.WriteLine("Admin login successfully!");
            return _currentUser.Type == UserType.Admin;
        }
    }
}
