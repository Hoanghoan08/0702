using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace _0702.Models
{
  public class Course
  {
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public int TopicId { get; set; }
    public Topic Topic { get; set; }
  }
}