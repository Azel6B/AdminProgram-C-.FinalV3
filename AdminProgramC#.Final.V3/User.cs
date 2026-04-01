using System;

namespace Admin_Program_C_
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }

        public User(string name, string address, string email, string phone, int age)
        {
            Name = name;
            Address = address;
            Email = email;
            Phone = phone;
            Age = age;
        }

        public string GetUserInfo()
        {
            return "Name: " + Name + " | Age: " + Age + " | Email: " + Email + " | Phone: " + Phone + " | Address: " + Address;
        }
    }
}
