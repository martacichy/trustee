﻿namespace BackendLibrary.Models
{
    /// <summary>
    /// Klasa reprezentująca parę zadanie i etykieta.
    /// </summary>
    public class TaskLabelModel
    {
        public int Task_id { get; set; }
        public int Label_id { get; set; }

        public TaskLabelModel(int task_id, int label_id)
        {
            Task_id = task_id;
            Label_id = label_id;
        }
    }
}