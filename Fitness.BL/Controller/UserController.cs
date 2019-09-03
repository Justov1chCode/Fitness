using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Controller
{
    public class UserController : ControllerBase
    {
        private const string USERS_FILE_NAME = "users.dat";
        public List<User> Users { get; }

        public bool IsNewUser { get; } = false;

        public User CurrentUser { get; }

        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя не может быть пропущено.", nameof(userName));
            }

            Users = GetUsersData();

            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if (CurrentUser == null) {
                CurrentUser = new User(userName);
                IsNewUser = true;
                Users.Add(CurrentUser);
                this.Save();
            }
            
        }
        public void Save()
        {
            Save(USERS_FILE_NAME, Users);
        }

        private List<User> GetUsersData()
        {
           return Load<List<User>>(USERS_FILE_NAME) ?? new List<User>();
        }

        public void SetNewUserData(string genderName, DateTime birthdate, double weight = 1, double height = 1)
        {
            //Проверка

            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthdate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();

        }
    }
}
