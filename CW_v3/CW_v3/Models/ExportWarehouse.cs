using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW_v3.Models
{
    public class ExportWarehouse
    {
        public ExportWarehouse(int id, int exportTypeId, string productName, int quantity, int pricePerKilo)
        {
            Id = id;
            ExportTypeId = exportTypeId;
            ProductName = productName;
            Quantity = quantity;
            PricePerKilo = pricePerKilo;
        }

        public int Id { get; }
        public int ExportTypeId { get; }
        public string ProductName { get; }
        public int Quantity { get; }
        public int PricePerKilo { get; }
    }
}
