using System.ComponentModel.DataAnnotations;

namespace WebApi.Sample.Models.V1
{
    public class TodoModel
    {
        [Required]
        public int Id { get; set; }
        
        [Required,StringLength(50)]
        public string Description { get; set; }

        public List<TodoTaskModel> Tasks { get; set; }
    }
}
