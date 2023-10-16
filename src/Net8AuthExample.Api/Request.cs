using System.ComponentModel.DataAnnotations;

namespace Net8AuthExample.Api;

public class Request
{
    [Range(1, int.MaxValue, ErrorMessage = "Value should be greater than zero.")]
    public required long PersonalId { get; set; }
}