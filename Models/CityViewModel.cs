using System.ComponentModel.DataAnnotations;

namespace ASPNET8.Models;

public class CityViewModel
{
    [Required]
    public string CityName { get; set; }
}