using System;
using System.Collections.Generic;

namespace UsersAndAwardsEntities
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public List<Award> Awards { get; set; } 

        public User(int id, string name, DateTime dateOfBirth, int age)
        {
            this.ID = id;
            this.Name = name;
            this.DateOfBirth = dateOfBirth;
            this.Age = age;
        }

        public User(string name, DateTime dateOfBirth, int age)
        {
            this.Name = name;
            this.DateOfBirth = dateOfBirth;
            this.Age = age;
        }

        public override string ToString()
        {
            return $"{ID} {Name} {DateOfBirth.Day}/{DateOfBirth.Month}/{DateOfBirth.Year} {Age}";
        }
    }
}