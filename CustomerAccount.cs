using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightPlanner
{
    class CustomerAccount : IUserAccount
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<FlightPlan> Tickets { get; set; }

        public CustomerAccount(string firstName, string lastName, string email, string userName, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            UserName = userName;
            Password = password;
            Tickets = new List<FlightPlan>();
        }
    }
}
