using System.ComponentModel.DataAnnotations;

namespace Personal.Tasket.Client.Models;

public class TisketModel
{
    //public TisketModel(int id, string title, string description, DateTime whenAdded, DateTime? whenCompleted, bool isCompleted)
    //{
    //    Id = id;
    //    Title = title ?? throw new ArgumentNullException(nameof(title));
    //    Description = description ?? throw new ArgumentNullException(nameof(description));
    //    WhenAdded = whenAdded;
    //    WhenCompleted = whenCompleted;
    //    IsCompleted = isCompleted;
    //}

    public int Id { get; set; }

    [Required]
    [DataType(DataType.Text), MaxLength(50)]
    public string Title { get; set; } = string.Empty;

    [DataType(DataType.Text), MaxLength(250)]
    public string Description { get; set; } = string.Empty;

    [DataType(DataType.DateTime)]
    public DateTime WhenAdded { get; set; } = DateTime.Now.ToLocalTime();

    [DataType(DataType.DateTime)]
    public DateTime? WhenCompleted { get; set; } = null;
    public bool IsCompleted { get; set; } = false;
}
