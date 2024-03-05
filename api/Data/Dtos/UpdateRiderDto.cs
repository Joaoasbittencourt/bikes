using System.ComponentModel.DataAnnotations;

namespace bikes;

public class UpdateRiderDto
{
    [Url]
    public string? CnhPhotoUrl { get; set; }
}
