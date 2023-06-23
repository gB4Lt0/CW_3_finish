using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW_v3.Models
{
    public class TypeOfWork
    {
        public TypeOfWork(int id, string name, int salary)
        {
            Id = id;
            TypeOfWorkName = name;
            Salary = salary;
        }

        public int Id { get; }
        public string TypeOfWorkName { get; }
        public int Salary { get; }
    }
}
