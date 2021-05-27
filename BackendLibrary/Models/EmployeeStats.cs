using System;

namespace BackendLibrary.Models
{
    public class EmployeeStats
    {
        public int Employee_id { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }

        public double TaskDensity { get; set; }
        public int EmpLabelMatches { get; set; }
        public int TaskLabelMatches { get; set; }

        public double FinalFactor { get; set; }

        public void CalculateFinalFactor(double weight1, double weight2, double weight3)
        {
            FinalFactor =
                1 / (TaskDensity > 0 ? TaskDensity : 0.5) * weight1
                + EmpLabelMatches * weight2
                + TaskLabelMatches * weight3;

            FinalFactor = Math.Round(FinalFactor, 2);
        }
    }
}