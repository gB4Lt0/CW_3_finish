using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW_v3.Models
{
    public class Animal
    {
        public Animal(int id, int landAddressesId, int animalTypeId, string gender, int quantity, int consumption)
        {
            Id = id;
            LandAddressesId = landAddressesId;
            AnimalTypeId = animalTypeId;
            Gender = gender;
            Quantity = quantity;
            Consumption = consumption;
        }

        public int Id { get; }
        public int LandAddressesId { get; }
        public int AnimalTypeId { get; }
        public string Gender { get; }
        public int Quantity { get; }
        public int Consumption { get; }
    }
}
