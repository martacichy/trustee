using System;
using System.Collections.Generic;
using System.Text;

namespace BackendLibrary.Models
{
    public class LabelTypeModel
    {
		public int Label_type_id { get; set; }
		public int Company_id { get; set; }
		public string Name { get; set; }

		public LabelTypeModel(int label_type_id, int company_id, string name)
		{
			Company_id = company_id;
			Label_type_id = label_type_id;
			Name = name;
		}

        public LabelTypeModel(int company_id, string name) {
            Company_id = company_id;
            Name = name;
        }
    }
}
