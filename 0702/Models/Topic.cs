using System.ComponentModel.DataAnnotations;

namespace _0702.Models
{
  public class Topic
  {
    public int Id { get; set; }
    [Required]
    [Display(Name ="Topic Name")]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
  }
}