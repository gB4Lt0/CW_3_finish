using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW_v3.Models
{
    public class ExportType
    {
        public ExportType(int id, string exportTypeName)
        {
            Id = id;
            ExportTypeName = exportTypeName;
        }

        public int Id { get; }
        public string ExportTypeName { get; }
    }
}
