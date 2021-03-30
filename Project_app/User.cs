using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Project_app
{
    public class User
    {
        public const string FilePath = @"C:\Users\Sevka\source\repos\Project_app\Project_app\Users.txt";
        public int Id { get; set; }
        public string SurName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        
    }
}
