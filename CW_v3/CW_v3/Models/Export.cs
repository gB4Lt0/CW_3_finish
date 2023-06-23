using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW_v3.Models
{
    public class Export
    {
        public Export(int id, int exportAddressesId, int exportWarehouseId, int exportTypeId, string exportName, int quantity, int price, string saleDate)
        {
            Id = id;
            ExportAddressesId = exportAddressesId;
            ExportWarehouseId = exportWarehouseId;
            ExportTypeId = exportTypeId;
            ExportName = exportName;
            Quantity = quantity;
            Price = price;
            SaleDate = saleDate;
        }

        public int Id { get; }
        public int ExportAddressesId { get; }
        public int ExportWarehouseId { get; }
        public int ExportTypeId { get; }
        public string ExportName { get; }
        public int Quantity { get; }
        public int Price { get; }
        public string SaleDate { get; }
    }
}

