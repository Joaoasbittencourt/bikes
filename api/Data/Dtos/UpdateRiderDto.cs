using System.ComponentModel.DataAnnotations;

namespace mottu;

public class UpdateRiderDto
{
    [Url]
    public string? CnhPhotoUrl { get; set; }
}
