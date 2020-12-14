using System;
using System.Collections.Generic;
using System.Text;

namespace BackendLibrary.Models
{
    class LabelModel
    {
		public int Label_id { get; set; }
		public int Label_type_id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }

		public LabelModel(int label_id, int label_type_id, string name, string description)
		{
			Label_id = label_id;
			Label_type_id = label_type_id;
			Name = name;
			Description = description;
		}
	}
}
