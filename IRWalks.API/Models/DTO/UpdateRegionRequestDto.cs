using System.ComponentModel.DataAnnotations;

namespace IRWalks.API.Models.DTO;

public class UpdateRegionRequestDto
{
    [Required]
    [MaxLength(3, ErrorMessage = "Has to be max of 3 char")]
    public string Code { get; set; }
    [Required]
    [MaxLength(3, ErrorMessage = "Has to be max of 3 char")]

    public string Name { get; set; }
    public string? RegionImageUrl { get; set; }
}
