using Microsoft.AspNetCore.Components;

namespace HumanResourcesAndPayrollApp.Pages
{
    public partial class NewDependent
    {
        private Models.Dependent newDependent = new Models.Dependent();

        [Parameter]
        public EventCallback<int> OnDependentAdded { get; set; }

        protected async void AddDependent()
        {
            newDependent.EmployeeId = EmployeeId;
            await employeeService.AddNewEmployeeDependent(newDependent);
            newDependent = new Models.Dependent();
            await OnDependentAdded.InvokeAsync(EmployeeId);            
        }

        [CascadingParameter]
        public int EmployeeId { get; set; }
    }
}
