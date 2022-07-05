using System.ComponentModel.DataAnnotations;

namespace Personal.Tasket.Client.Models;

public class TisketModel
{
    public int Id { get; set; }

    [Required]
    [DataType(DataType.Text), MaxLength(50)]
    public string Title { get; set; } = string.Empty;

    [DataType(DataType.Text), MaxLength(250)]
    public string Description { get; set; } = string.Empty;

    [DataType(DataType.DateTime)]
    public DateTime WhenAdded { get; set; } = DateTime.UtcNow;

    [DataType(DataType.DateTime)]
    public DateTime? WhenCompleted { get; set; } = null;
    public bool IsCompleted { get; set; } = false;
}
