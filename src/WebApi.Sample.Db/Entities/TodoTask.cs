using System.ComponentModel.DataAnnotations;

namespace WebApi.Sample.Db.Entities;

public class TodoTask
{
    public int Id { get; set; }

    public int Number { get; set; }

    [Required, MaxLength(50)]
    public string Description { get; set; }

}