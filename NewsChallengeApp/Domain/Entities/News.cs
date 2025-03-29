using System.ComponentModel.DataAnnotations;

namespace NewsApi.Domain.Entities;

public class News
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(200)]
    public string Title { get; set; } = string.Empty;

    [Required]
    public string Body { get; set; } = string.Empty;

    [Required, Url]
    public string ImageUrl { get; set; } = string.Empty;

    [Required, MaxLength(100)]
    public string Author { get; set; } = string.Empty;

    [Required]
    public DateTime Date { get; set; } = DateTime.UtcNow;

    public bool IsDeleted { get; set; } = false; // Soft Delete
}