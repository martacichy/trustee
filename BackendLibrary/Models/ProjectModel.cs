namespace BackendLibrary.Models
{
    public class ProjectModel
    {
        public int Project_id { get; set; }
        public int Company_id { get; set; }
        public string Name { get; set; }

        public ProjectModel(int project_id, int company_id, string name)
        {
            Company_id = company_id;
            Project_id = project_id;
            Name = name;
        }

        public ProjectModel(int company_id, string name)
        {
            Company_id = company_id;
            Name = name;
        }
    }
}