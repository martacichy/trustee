﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BackendLibrary.Models
{
    class TaskModel
    {
		public int Task_id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime Start_time { get; set; }
		public DateTime Deadline { get; set; }
		public string Status { get; set; }
		public byte Auto_assigned { get; set; }

		public TaskModel(int task_id, string name, string description,
			DateTime start_time, DateTime deadline, string status, byte auto_assigned)
		{
			Task_id = task_id;
			Name = name;
			Description = description;
			Start_time = start_time;
			Deadline = deadline;
			Status = status;
			Auto_assigned = auto_assigned;
		}
	}
}
