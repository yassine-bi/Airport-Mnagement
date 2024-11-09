using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        public int PassengerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PassportNumber { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<Flight>? Flights { get; set; }

        public override string ToString()
        {
            return $"PassengerId : {PassengerId} - " +
                $" FirstName :{FirstName} - LastName : {LastName} - PassportNumber: {PassportNumber} -" +
                $" EmailAddress : {EmailAddress} - PhoneNumber : {PhoneNumber} - BirthDate : {BirthDate}";
        }

        public bool CheckProfile(string LastName, string FirstName)
        {
            return this.LastName == LastName && this.FirstName == FirstName;
        }

        public bool CheckProfile(string LastName, string FirstName, string EmailAddress)
        {
            return this.LastName == LastName && this.FirstName == FirstName && this.EmailAddress == EmailAddress;
        }

        public virtual void PassengerType()
        {
            Console.WriteLine("I am a passanger ");
        }
    }
}
