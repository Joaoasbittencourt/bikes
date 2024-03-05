using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace mottu;

[Index(nameof(Cnpj), IsUnique = true)]
[Index(nameof(CnhNumber), IsUnique = true)]
public class Rider
{
    [Key]
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Cnpj { get; set; }
    public DateTime Birthdate { get; set; }
    public required string CnhNumber { get; set; }
    public required CnhType CnhType { get; set; }
    public string? CnhPhotoUrl { get; set; }
}
