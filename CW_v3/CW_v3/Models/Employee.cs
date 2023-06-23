using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW_v3.Models
{
    public class Employee
    {
        public Employee(int id, int typeOfWorkId, int landAddressesId, string fullName, string addressOfResidence, string phoneNumber)
        {
            Id = id;
            TypeOfWorkId = typeOfWorkId;
            LandAddressesId = landAddressesId;
            FullName = fullName;
            AddressOfResidence = addressOfResidence;
            PhoneNumber = phoneNumber;
        }

        public int Id { get; }
        public int TypeOfWorkId { get; }
        public int LandAddressesId { get; }
        public string FullName { get; }
        public string AddressOfResidence { get; }
        public string PhoneNumber { get; }
    }
}
