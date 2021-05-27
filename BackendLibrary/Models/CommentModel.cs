using System;

namespace BackendLibrary.Models
{
    /// <summary>
    /// Klasa reprezentująca komentarz do zadania.
    /// </summary>
    public class CommentModel
    {
        public int Comment_id { get; set; }
        public int Task_id { get; set; }
        public int Employee_id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public CommentModel(int comment_id, int task_id, int employee_id, DateTime date, string description)
        {
            Comment_id = comment_id;
            Task_id = task_id;
            Employee_id = employee_id;
            Date = date;
            Description = description;
        }

        public CommentModel(int comment_id, int task_id, int employee_id)
        {
            Comment_id = comment_id;
            Task_id = task_id;
            Employee_id = employee_id;
        }

        public CommentModel(int task_id, int employee_id, DateTime date, string description)
        {
            Task_id = task_id;
            Employee_id = employee_id;
            Date = date;
            Description = description;
        }
        public CommentModel()
        {

        }

    }
}