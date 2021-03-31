namespace BackendLibrary.Models
{
    public class EmployeeProjectModel
    {
        public int Employee_id { get; set; }
        public int Project_id { get; set; }

        public EmployeeProjectModel(int employee_id, int project_id)
        {
            Employee_id = employee_id;
            Project_id = project_id;
        }
    }
}