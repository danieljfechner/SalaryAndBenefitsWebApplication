using System.ComponentModel.DataAnnotations;

namespace HumanResourcesAndPayrollApp.Models
{
    public class PersonBase : EntityBase
    {
        public const decimal StartsWithADiscount = .9m;

        [Required(ErrorMessage = "First Name is required.")]
        [MinLength(2, ErrorMessage = "Must be longer than 1 letter")]
        [MaxLength(50, ErrorMessage = "Must be 50 letters or less")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Must be letters only")]
        public string? FirstName { get; set; }

        [StringLength(50, MinimumLength = 2, ErrorMessage = "Must be between 2 and 50 character in length")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Must be letters only")]
        public string? MiddleName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [MinLength(2, ErrorMessage = "Must be longer than 1 letter.")]
        [MaxLength(50, ErrorMessage = "Must be 50 letters or less.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Must be letters only.")]
        public string? LastName { get; set; }

        public virtual decimal StandardCost { get; set; }
        public decimal Cost { get; set; }        
    }
}
