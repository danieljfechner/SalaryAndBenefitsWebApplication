namespace HumanResourcesAndPayrollApp.Models
{
    public class Employee : PersonBase
    {
        private decimal _standardCost = 1000m;

        public const int PAYCHECKS_PER_YEAR = 26;

        public const decimal PAYCHECK_SIZE = 2000;

        public Spouse? Spouse { get; set; }

        public IEnumerable<Dependent>? Dependents { get; set; }

        public decimal Salary { get; set; }

        public bool IsMarried { get; set; }

        public override decimal StandardCost
        {
            get
            {
                return _standardCost;
            }
        }
    }
}