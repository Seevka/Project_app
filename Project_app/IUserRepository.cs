using System;
using System.Collections.Generic;
using System.Text;

namespace Project_app
{
    public interface IUserRepository
    {
        List<User> ReadFromFile();

        User Get(int id);

        int Add(User user);

        bool Delete(int userId);

        bool Update(User user);


    }
}
