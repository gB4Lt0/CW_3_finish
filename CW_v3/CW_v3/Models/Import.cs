using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW_v3.Models
{
    public class Import
    {
        public Import(int id, int importAddressesId, int importTypeId, string importName, int quantity, int price, string importDate)
        {
            Id = id;
            ImportAddressesId = importAddressesId;
            ImportTypeId = importTypeId;
            ImportName = importName;
            Quantity = quantity;
            Price = price;
            ImportDate = importDate;
        }

        public int Id { get; }
        public int ImportAddressesId { get; }
        public int ImportTypeId { get; }
        public string ImportName { get; }
        public int Quantity { get; }
        public int Price { get; }
        public string ImportDate { get; }
    }
}
