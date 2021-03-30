using System;
using System.Collections.Generic;
using System.Text;

namespace Project_app
{
    class UserService
    {
      private UserRepository repository = new UserRepository();

        public void PrintAll()
        {
            var users = repository.ReadFromFile();

            foreach(var user in users)
            {
                Console.WriteLine($"Id: {user.Id} Name: {user.Name} Surname: {user.SurName} Email: {user.Email} ");
            }
        }

        public void Add()
        {
            Console.WriteLine("Enter SurName:");
            string addSurname = Console.ReadLine();

            Console.WriteLine("Enter Name:");
            string addName = Console.ReadLine();

            Console.WriteLine("Enter Email:");
            string addEmail = Console.ReadLine();

            var newUser=repository.Add(new User
            {
              Name = addName,
              SurName = addSurname,
              Email = addEmail
                            
            });
        }

        public void Delete()
        {
            Console.WriteLine("Enter id: ");
            var userId=int.Parse(Console.ReadLine());

            if(repository.Delete(userId))
            {
               Console.WriteLine($"User with ID: {userId} was deleted");
            }
            else
            {
                Console.WriteLine($"User with ID: {userId} is not found");
            }
        }

        public void Update()
        {
            Console.WriteLine("Enter id: ");
            var userId = int.Parse(Console.ReadLine());

            var existingUser = repository.Get(userId);
            if(existingUser==null)
            {
                Console.WriteLine($"User with ID: {userId} not found");
                return;
            }

            Console.WriteLine("Enter SurName:");
            existingUser.SurName = Console.ReadLine();

            Console.WriteLine("Enter Name:");
            existingUser.Name = Console.ReadLine();

            Console.WriteLine("Enter Email:");
            existingUser.Email = Console.ReadLine();
            repository.Update(existingUser);

        }
    }
}
