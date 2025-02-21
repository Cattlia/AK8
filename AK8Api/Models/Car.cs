using System.ComponentModel.DataAnnotations;

public class Car
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string? Type { get; set; }

    [Required]
    public string? Color { get; set; }

    [Required]
    public string? WindowType { get; set; }

    public DateTime? CreatedAt { get; set; }
}