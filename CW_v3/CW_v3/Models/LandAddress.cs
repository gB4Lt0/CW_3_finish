using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW_v3.Models
{
    public class LandAddress
    {
        public LandAddress(int id, int locationTypeId, string branchName, string address)
        {
            Id = id;
            LocationTypeId = locationTypeId;
            BranchName = branchName;
            Address = address;
        }

        public int Id { get; }
        public int LocationTypeId { get; }
        public string BranchName { get; }
        public string Address { get; }
    }
}
