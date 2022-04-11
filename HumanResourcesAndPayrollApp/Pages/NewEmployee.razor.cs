namespace HumanResourcesAndPayrollApp.Pages
{
    public partial class NewEmployee
    {
        private Models.Employee newEmployee = new Models.Employee();
        protected async void CreateEmployee()
        {
            var employeeId = await employeeService.AddEmployee(newEmployee);
            NavigationManager.NavigateTo("Employee/" + employeeId);
        }

        void Cancel()
        {
            NavigationManager.NavigateTo("/", true);
        }

        bool isMarried { get; set; }

        private void ToggleIsMarried()
        {
            isMarried = !isMarried;

            if (isMarried)
            {
                newEmployee.Spouse = new Models.Spouse();
            }
            else
            {
                newEmployee.Spouse = null;
            }
        }
    }
}
