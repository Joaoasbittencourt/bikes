using System.ComponentModel.DataAnnotations;

namespace bikes;

public enum CnhType
{
    A,
    B,
    AB
}

public class CreateRiderDto
{
    [Required]
    [StringLength(100, MinimumLength = 4)]
    public required string Name { get; set; }

    [Required]
    [StringLength(14, MinimumLength = 14)]
    public required string Cnpj { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime Birthdate { get; set; }

    [Required]
    [StringLength(11, MinimumLength = 11)]
    public required string CnhNumber { get; set; }

    [Required]
    [EnumDataType(typeof(CnhType))]
    public required CnhType CnhType { get; set; }

    [Url]
    public string? CnhPhotoUrl { get; set; }
}
