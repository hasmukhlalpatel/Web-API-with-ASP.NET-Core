using System.ComponentModel.DataAnnotations;

namespace WebApi.Sample.Db.Entities
{
    public class Todo
    {
        [Required]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Description { get; set; }

    }
}
