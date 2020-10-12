using System.ComponentModel.DataAnnotations;

namespace _0702.Models
{
  public class Trainee
  {
    public int Id { get; set; }
    [Required]
    [Display(Name = "Full Name")]
    public string FullName { get; set; }
    [Required]
    public int PhoneNumber { get; set; }
    [Required]
    [Display(Name = "Working Place")]
    public string WorkingPlace { get; set; }
  }
}