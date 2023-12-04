using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Servicelayer;
using MediaPlayerCore;
using Moq;
using UserDTO;

namespace MediaPlayer.Test
{
    public class UserServiceTest 
    {
       
        [Fact]
        public void Add_UserToList_WhenUserDoesNotExist()
        {
            var userService=new UserService();
            var user = new AddUserDTO("John Doe", UserType.Customer);
            userService.Add(user);
            var updatedusers=userService.GetUsers;
            var addedUser=userService.GetById("7");
            var added=updatedusers.Count;
            Assert.True(added >0);
            Assert.NotNull(addedUser);
        }

      

        [Fact]
        public void Add_UserToList_WhenUserAlreadyExist()
        {
            var userService=new UserService();
            var existingUser = new AddUserDTO("John Doe", UserType.Customer);
            userService.Add(existingUser);
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
           
            var newUser = new AddUserDTO("John Doe", UserType.Customer);
            userService.Add(newUser);
            var output = stringWriter.ToString().Trim();
            Assert.Contains("User already existed.", output);

        }

        [Fact]
        public void Delete_RemovesUser_WhenCollectionAndUserExist()
        {
            var userService = new UserService();
            var newUser = new AddUserDTO("John Doe", UserType.Customer);
            userService.Add(newUser);
            userService.Delete("3");
            var deletedUser = userService.GetById("3");
            Xunit.Assert.Null(deletedUser);
        }

        [Fact]
        public void Delete_RemoveUser_WhenCollectionExistsButUserDoesNotExist()
        {
            var userService = new UserService();
            userService.Delete("1");
            var deletedUser = userService.GetById("1");
            Xunit.Assert.Null(deletedUser);
        }

        [Fact]
        public void Delete_PrintMessage_WhenCollectionDoesNotExist()
        {
            var userService = new UserService();
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            userService.Delete("1");
            var output = stringWriter.ToString().Trim();
            Xunit.Assert.Contains("Can not find the user.", output);
        }

        [Fact]
        public void GetById_ReturnsCorrectUser_WhenUserExists()
        {
            var userService = new UserService();
            var newUser = new AddUserDTO("John Doe", UserType.Customer);
            userService.Add(newUser);
            var updatedUserList = userService.GetUsers;
            var result=userService.GetById("3");
            Assert.NotNull(result);
            Assert.Equal("John Doe", result.Username);
        }

        [Fact]
        public void GetById_ReturnsNull_WhenUserDoesNotExist()
        {
             var userService = new UserService();
             var result = userService.GetById("1");
             Xunit.Assert.Null(result);
        }

        [Fact]
        public void GetById_ReturnsNull_WhenUsersCollectionIsNull()
        {
            var userService = new UserService();
            userService.GetType().GetField("_users", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(userService,null);
            var result = userService.GetById("1");
            Xunit.Assert.Null(result);
        }

        [Fact]
        public void GetAllFiles_ReturnsFilteredUsers_WhenUsersExists()
        {
            var userService = new UserService();
            var user1 = new AddUserDTO("John Doe", UserType.Customer);
            var user2 = new AddUserDTO("Emily Juhanus", UserType.Customer);
            var user3 = new AddUserDTO("Alice Johnson", UserType.Customer);
            var user4 = new AddUserDTO("Jim Chong", UserType.Customer);
            userService.Add(user1);
            userService.Add(user2);
            userService.Add(user3);
            userService.Add(user4);
            var result = userService.GetAllFiles(2, 0);
            Assert.Equal(2, result.Count);            
            Assert.Equal("John Doe", result[0].Username);
            Assert.Equal("Emily Juhanus", result[1].Username);
        }
        [Fact]
        public void GetAllFiles_ReturnsEmptyList_WhenNoUsersExist()
        {
             var userService = new UserService();
             var result = userService.GetAllFiles(10, 0);
             Assert.True(result.Count==0);
        }
    }
}