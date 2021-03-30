using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Project_app
{

    public class UserRepository : IUserRepository
    {
        public const string FilePath = @"C:\Users\Sevka\source\repos\Project_app\Project_app\Users.txt";

        public int Add(User user)
        {
            var users = ReadFromFile();
            users.Add(user);
            var maxId = users.Any() ? users.Max(user => user.Id) : 0;
            user.Id = maxId + 1;
            File.WriteAllText(FilePath,SaveToFile(users));
            return user.Id;
        }

        public bool Delete(int userId)
        {
            var users = ReadFromFile();
            var existingUser = users.FirstOrDefault(t => t.Id == userId);
            if (existingUser == null)
            {
                return false;
            }

            File.WriteAllText(FilePath, SaveToFile(users.Where(t => t.Id !=userId).ToList()));
            return true;     
        }

        public User Get(int id)
        {
            var users = ReadFromFile();

            return users.FirstOrDefault(t => t.Id == id);
        }

        public List<User> GetAll()
        {
            var users = ReadFromFile();

            return users;
        }

        public List<User> ReadFromFile()
        {
            var usersStr =File.ReadAllText(FilePath);
            var usersStrDeserialized = JsonConvert.DeserializeObject<List<User>>(usersStr);

            return usersStrDeserialized ?? new List<User>();
        }

        public bool Update(User user)
        {
            var users = ReadFromFile();
            var existingUser = users.FirstOrDefault(t=>t.Id==user.Id);
            if(existingUser==null)
            {
                return false;
            }

             existingUser.Name = user.Name;
             existingUser.SurName = user.SurName;
             existingUser.Email = user.Email;

             File.WriteAllText(FilePath, SaveToFile(users));
             return true;
        }


        private string SaveToFile(List<User> users)
        {
            string strSave = JsonConvert.SerializeObject(users);
            return strSave;
        }

    }
}
