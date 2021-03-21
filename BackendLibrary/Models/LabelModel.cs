namespace BackendLibrary.Models
{
    public class LabelModel
    {
        public int Label_id { get; set; }
        public int Company_id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public LabelModel()
        {
        }

        public LabelModel(string name, int company_id)
        {
            Name = name;
            Company_id = company_id;
        }

        public LabelModel(int label_id, int company_id, string name, string description)
        {
            Label_id = label_id;
            Company_id = company_id;
            Name = name;
            Description = description;
        }

        public LabelModel(int company_id, string name, string description)
        {
            Company_id = company_id;
            Name = name;
            Description = description;
        }
    }
}