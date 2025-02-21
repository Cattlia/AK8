using System;
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

    // This property can be optional; it will be set by the database
    public DateTime? CreatedAt { get; set; } // Nullable to allow database to set the value
}
