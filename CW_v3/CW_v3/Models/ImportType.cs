using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW_v3.Models
{
    public class ImportType
    {
        public ImportType(int id, string importTypeName)
        {
            Id = id;
            ImportTypeName = importTypeName;
        }

        public int Id { get; }
        public string ImportTypeName { get; }
    }
}
