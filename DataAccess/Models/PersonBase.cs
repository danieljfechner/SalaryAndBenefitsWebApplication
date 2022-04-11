namespace DataAccess.Models
{
    public class PersonBase : EntityBase
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }
}