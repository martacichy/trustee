namespace BackendLibrary.Models
{
    /// <summary>
    /// Klasa reprezentująca parę projekt i pracownik.
    /// </summary>
    public class EmployeeProjectModel
    {
        public int Project_id { get; set; }
        public int Employee_id { get; set; }

        public EmployeeProjectModel(int project_id, int employee_id)
        {
            Project_id = project_id;
            Employee_id = employee_id;
        }
    }
}