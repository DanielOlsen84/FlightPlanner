using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightPlanner
{
    class CompanyAccount : IUserAccount
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<Airline> Airlines { get; set; }

        public CompanyAccount(string firstName, string lastName, string email, string userName, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            UserName = userName;
            Password = password;
            Airlines = new List<Airline>();
        }
    }
}
