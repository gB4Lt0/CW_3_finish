using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW_v3.Models
{
    public class Plantation
    {
        public Plantation(int id, int landAddressesId, string plantationTypeName, int quantity, string plantingDate)
        {
            Id = id;
            LandAddressesId = landAddressesId;
            PlantationTypeName = plantationTypeName;
            Quantity = quantity;
            PlantingDate = plantingDate;
        }

        public int Id { get; }
        public int LandAddressesId { get; }
        public string PlantationTypeName { get; }
        public int Quantity { get; }
        public string PlantingDate { get; }
    }
}
