using System.ComponentModel.DataAnnotations;

namespace WebApi.Sample.Models.V1;

public class TodoTaskModel
{
    [Required]
    public int Number { get; set; }

    [Required, StringLength(50)]
    public string Description { get; set; }
}