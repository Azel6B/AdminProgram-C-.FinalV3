using System;
using System.Collections.Generic;

namespace Admin_Program_C_
{
    internal class Program
    {
        private static List<User> users = new List<User>();

        static void Main(string[] args)
        {
            Console.WriteLine("Wekker");

            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("\n--- ADMIN SYSTEM ---");
                Console.WriteLine("1. Add User");
                Console.WriteLine("2. View All");
                Console.WriteLine("3. Edit User");
                Console.WriteLine("4. Remove User");
                Console.WriteLine("5. Search (Age)");
                Console.WriteLine("6. Quit");
                Console.Write("Pick one: ");

                string input = Console.ReadLine() ?? "";

                if (input == "1") AddUser();
                else if (input == "2") ViewUsers();
                else if (input == "3") EditUser();
                else if (input == "4") DeleteUser();
                else if (input == "5") SearchByAge();
                else if (input == "6") isRunning = false;
                else Console.WriteLine("Not a valid choice, try again.");
            }
        }

        /// Asks for details and adds a new user to the list.
        private static void AddUser()
        {
            Console.Write("Name: ");
            string name = Console.ReadLine() ?? "";
            Console.Write("Address: ");
            string address = Console.ReadLine() ?? "";
            Console.Write("Email: ");
            string email = Console.ReadLine() ?? "";
            Console.Write("Phone: ");
            string phone = Console.ReadLine() ?? "";

            Console.Write("Age: ");
            if (int.TryParse(Console.ReadLine(), out int age))
            {
                User newUser = new User(name, address, email, phone, age);
                users.Add(newUser);
                Console.WriteLine("User added!");
            }
            else
            {
                Console.WriteLine("Invalid input. User not added.");
            }
        }

        /// Loops through the list and prints all users.
        private static void ViewUsers()
        {
            Console.WriteLine("\nShowing all users:");
            if (users.Count == 0) Console.WriteLine("The list is empty right now.");

            for (int i = 0; i < users.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + users[i].GetUserInfo());
            }
        }

        /// Lets you pick a user by their number and change a part.
        private static void EditUser()
        {
            ViewUsers();
            if (users.Count == 0) return;

            Console.Write("Enter the number of the user to edit: ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= users.Count)
            {
                User target = users[choice - 1];
                Console.WriteLine("Editing " + target.Name + ". What do you want to change?");
                Console.WriteLine("1. Name\n2. Age\n3. Email\n4. Address\n5. Phone");
                string field = Console.ReadLine() ?? "";

                if (field == "1") { Console.Write("New Name: "); target.Name = Console.ReadLine() ?? target.Name; }
                else if (field == "2") { Console.Write("New Age: "); if (int.TryParse(Console.ReadLine(), out int newAge)) target.Age = newAge; }
                else if (field == "3") { Console.Write("New Email: "); target.Email = Console.ReadLine() ?? target.Email; }
                else if (field == "4") { Console.Write("New Address: "); target.Address = Console.ReadLine() ?? target.Address; }
                else if (field == "5") { Console.Write("New Phone: "); target.Phone = Console.ReadLine() ?? target.Phone; }
                else Console.WriteLine("Not a valid choice.");

                Console.WriteLine("Done!");
            }
        }

        /// Removes a user from the list.
        private static void DeleteUser()
        {
            ViewUsers();
            if (users.Count == 0) return;

            Console.Write("Number to delete: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= users.Count)
            {
                users.RemoveAt(index - 1);
                Console.WriteLine("Removed.");
            }
        }

        /// Filters the list by age.
        private static void SearchByAge()
        {
            Console.Write("Enter age to check: ");
            if (int.TryParse(Console.ReadLine(), out int checkAge))
            {
                Console.WriteLine("1. Younger than | 2. Older than");
                string mode = Console.ReadLine() ?? "";

                if (mode == "1" || mode == "2")
                {
                    Console.WriteLine("-- Results --");
                    foreach (User u in users)
                    {
                        if (mode == "1" && u.Age < checkAge) Console.WriteLine(u.GetUserInfo());
                        if (mode == "2" && u.Age > checkAge) Console.WriteLine(u.GetUserInfo());
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please pick 1 or 2.");
                }
            }
            else
            {
                Console.WriteLine("Invalid age.");
            }
        }
    }
}
