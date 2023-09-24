using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_Hospital_Management_System
{
    public class Doctor : User
    {
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string StreetNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        private static Random random = new Random();

        public Doctor(int id, string name, string password, string fn, string email, string phone, string stNum, string st, string city, string state) : base(id, name, password)
        {

            FirstName = fn;
            Email = email;
            Phone = phone;
            StreetNumber = stNum;
            Street = st;
            City = city;
            State = state;
        }

        public override string ToString()
        {
            return $"ID: {ID}\nFirst Name: {FirstName}\nLast Name: {Name}\nEmail: {Email}\nPhone: {Phone}\nStreet Number: {StreetNumber}\nStreet: {Street}\nCity: {City}\nState: {State}";
        }

        public int GenerateRandomID()
        {
            return random.Next(10, 100);  
        }

        public string GenerateRandomPassword(int length = 8)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }

}
