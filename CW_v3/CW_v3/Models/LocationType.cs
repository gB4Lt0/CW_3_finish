using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW_v3.Models
{
    public class LocationType
    {
        public LocationType(int id, string locationTypeName)
        {
            Id = id;
            LocationTypeName = locationTypeName;
        }

        public int Id { get; }
        public string LocationTypeName { get; }
    }
}
