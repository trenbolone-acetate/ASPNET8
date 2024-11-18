using System.ComponentModel.DataAnnotations;

namespace ASPNET8.Models;

public class Index
{
    [Required]
    public string CityName { get; set; }
}