using System.ComponentModel.DataAnnotations;

namespace IRWalks.API.Models.DTO;

public class AddRegionRequestDto
{
    [Required]
    [MaxLength(3,ErrorMessage="Has to be max of 3 char")]
    public string Code { get; set; }
    [Required]
    [MaxLength(100, ErrorMessage = "Has to be max of 100 char")]
    public string Name { get; set; }
    public string? RegionImageUrl { get; set; }
}
