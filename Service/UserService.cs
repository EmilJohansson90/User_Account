using DAL;
using DAL.DTO;
using DAL.Models;

namespace Service
{
    public class UserService
    {
        private static UserService _instance;
        public static UserService Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new UserService();
                }
                return _instance;
            }
        }

        public bool CheckUserName(AddUserDTO addUserDTO)
        {
            using(var context = new AccountDBContext())
            {
                return context.Users.Any(u => u.UserName == addUserDTO.UserName);
            }
        }

        public void AddUser(AddUserDTO addUserDTO)
        {
            using(var context = new AccountDBContext())
            {
                context.Users.Add(new User()
                {
                    UserName = addUserDTO.UserName,
                    Password = addUserDTO.Password,
                    FirstName = addUserDTO.FirstName,
                    LastName = addUserDTO.LastName
                });
                context.SaveChanges();
            }
        }
    }
}