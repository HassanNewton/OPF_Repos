using System.ComponentModel.DataAnnotations;

namespace TaskShared.Model
{
    public class TaskItem
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsDone { get; set; }
    }
}
