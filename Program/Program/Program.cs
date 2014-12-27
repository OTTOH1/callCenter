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
            Operator operator1 = new Operator();
            operator1.Free = true;
            operator1.Id = 1;

            Operator operator4 = new Operator();
            operator4.Free = true;
            operator4.Id = 4;

            TM operator2 = new TM();
            operator2.Free = false;
            operator2.Id = 2;

            M operator3 = new M();
            operator3.Free = false;
            operator3.Id = 3;

            CallCenter callCenter = new CallCenter();

            callCenter.Add(operator1);
            callCenter.Add(operator2);
            callCenter.Add(operator3);
            callCenter.Add(operator4);

            Console.WriteLine(callCenter.getCallHandler().Id);

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

    class CallCenter
    {
        private List<Employee> staff = new List<Employee>();
        public void Add(Employee emp)
        {
            staff.Add(emp);
        }
        public Employee getCallHandler()
        {
            // Going through every employee and make a list of free operators.
            List<Employee> FreeOperators = new List<Employee>();
            List<Employee> FreeTM = new List<Employee>();
            List<Employee> FreeM = new List<Employee>();

            for (int i = 0; i < staff.Count; i++)
            {
                if (staff[i].Free == true)
                {
                    if (staff[i].GetType() == typeof(Operator))
                    {
                        FreeOperators.Add(staff[i]);
                    }
                    else if (staff[i].GetType() == typeof(TM))
                    {
                        FreeTM.Add(staff[i]);
                    }
                    else if (staff[i].GetType() == typeof(M))
                    {
                        FreeM.Add(staff[i]);
                    } 
                }
            }

            Random rnd = new Random((int)DateTime.Now.Ticks);

            if (FreeOperators.Count > 0)
            {
                int index = rnd.Next(FreeOperators.Count);
                return FreeOperators[index];
            }
            else if (FreeTM.Count > 0)
            {
                int index = rnd.Next(FreeTM.Count);
                return FreeTM[index];
            }
            else if (FreeM.Count > 0)
            {
                int index = rnd.Next(FreeM.Count);
                return FreeM[index];
            }
            else
            {
                throw new Exception("There is no free operators in the call center.");
            }
        }
    }
}
