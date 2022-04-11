using System.Collections.Generic;

namespace DataAccess.Models
{
    public class Employee : PersonBase
    {
        public Spouse Spouse { get; set; }
        public IEnumerable<Dependent> Dependents { get; set; }
        public decimal Salary { get; set; }
    }
}
