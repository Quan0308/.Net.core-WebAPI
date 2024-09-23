using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataService.Entities;

[Table("users")]
public class User
{
    [Key]
    [Column("id")]
    public int Id { get; init; }
    
    [Column("name")]
    public string Name { get; init; } = "";
    
    [Column("email")]
    [Required]
    public string Email { get; init; } = "";
    
    [Column("password")]
    [Required]
    public string Password { get; init; } = "";
}