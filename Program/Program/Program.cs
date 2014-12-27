using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    abstract class Employee
    {
        public int Id { get; set; }
        public bool Free { get; set; }
    }

    class Operator : Employee
    {

    }

    class TM : Employee
    {

    }

    class M : Employee
    {

    }
}
