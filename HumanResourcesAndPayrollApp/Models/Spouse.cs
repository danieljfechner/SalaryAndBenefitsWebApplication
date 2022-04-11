namespace HumanResourcesAndPayrollApp.Models
{
    public class Spouse : PersonBase
    {
        private decimal _standardCost = 500m;

        public int SpouseId { get; set; }

        public override decimal StandardCost
        {
            get
            {
                return _standardCost;
            }
        }
    }
}
