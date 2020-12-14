using System;
using System.Collections.Generic;
using System.Text;

namespace BackendLibrary.Models
{
    class LabelTypeModel
    {
		public int Label_type_id { get; set; }
		public string Name { get; set; }

		public LabelTypeModel(int label_type_id, string name)
		{
			Label_type_id = label_type_id;
			Name = name;
		}
	}
}
