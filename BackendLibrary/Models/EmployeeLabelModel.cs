namespace BackendLibrary.Models
{
    public class EmployeeLabelModel
    {
        public int Employee_id { get; set; }
        public int Label_id { get; set; }

        public EmployeeLabelModel(int employee_id, int label_id)
        {
            Employee_id = employee_id;
            Label_id = label_id;
        }
    }
}