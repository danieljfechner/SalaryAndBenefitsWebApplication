using System.ComponentModel.DataAnnotations;

namespace HumanResourcesAndPayrollApp.Models
{
    public class Dependent : PersonBase
    {
        private int _employeeId;
        private decimal _standardCost = 500m;

        [Required]
        public int EmployeeId
        {
            get
            {
                return _employeeId;
            }
            set
            {
                _employeeId = value;
            }
        }

        public override decimal StandardCost
        {
            get
            {
                return _standardCost;
            }
        }
    }
}
