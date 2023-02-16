using VirtualStore.Domain.Models.Shared;
using System;

namespace VirtualStore.Domain.Models
{
    public class Person : BaseModel
    {
        public string? Id { get; set; }

        public string Name { get; set; }

        public string Username { get; set; }

        private string Password;

        public Person(string name, string username, string password)
        {
            Name = name;
            Username = username;
            Password = password;
        }

        public void SetPassword(string password)
        {
            Password = password;
        }

        public string GetPassword()
        {
            return Password;
        }
    }
}

