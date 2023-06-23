using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW_v3.Models
{
    public class ImportAddress
    {
        public ImportAddress(int id, int locationTypeId, string companyName, string address)
        {
            Id = id;
            LocationTypeId = locationTypeId;
            CompanyName = companyName;
            Address = address;
        }

        public int Id { get; }
        public int LocationTypeId { get; }
        public string CompanyName { get; }
        public string Address { get; }
    }
}
