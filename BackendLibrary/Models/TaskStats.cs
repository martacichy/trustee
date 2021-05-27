using System;

namespace BackendLibrary.Models
{
    public class TaskStats
    {
        public int Task_id { get; set; }

        public int EmpLabelMatches { get; set; }
        public int ArchivalTaskLabelMatches { get; set; }

        public double FinalFactor { get; set; }

        public void CalculateFinalFactor(double weight1, double weight2)
        {
            FinalFactor =
                + EmpLabelMatches * weight1
                + ArchivalTaskLabelMatches * weight2;

            FinalFactor = Math.Round(FinalFactor, 2);
        }
    }
}