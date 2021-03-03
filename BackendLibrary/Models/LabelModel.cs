using System;
using System.Collections.Generic;
using System.Text;

namespace BackendLibrary.Models
{
    public class LabelModel
    {
		public int Label_id { get; set; }
		public int Company_id { get; set; }
		public int Label_type_id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }

		public LabelModel() {}
		public LabelModel(string name) {
			Name = name;
		}
		public LabelModel(int label_id, int company_id, int label_type_id, string name, string description)
		{
			Label_id = label_id;
			Company_id = company_id;
			Label_type_id = label_type_id;
			Name = name;
			Description = description;
		}

        public LabelModel(int company_id, int label_type_id, string name, string description) {
            Company_id = company_id;
            Label_type_id = label_type_id;
            Name = name;
            Description = description;
        }
    }
}
