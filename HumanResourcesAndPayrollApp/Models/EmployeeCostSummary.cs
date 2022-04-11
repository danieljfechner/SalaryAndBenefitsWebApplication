namespace HumanResourcesAndPayrollApp.Models
{
    public class EmployeeCostSummary
    {
        public Employee? Employee { get; set; }
        
        public decimal WeeklyPayCheck
        {
            get
            {
                return TotalYearlySalary / Employee.PAYCHECKS_PER_YEAR;
            }
        }

        public decimal TotalYearlySalary { get; set; }

        public decimal TotalCostOfBenefits { get; set; }
    }
}
