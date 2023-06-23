using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW_v3.Models
{
    public class AnimalType
    {
        public AnimalType(int id, string animalTypeName)
        {
            Id = id;
            AnimalTypeName = animalTypeName;
        }

        public int Id { get; }
        public string AnimalTypeName { get; }
    }
}
