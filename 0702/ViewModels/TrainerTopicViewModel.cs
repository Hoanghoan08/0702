using _0702.Models;
using System.Collections.Generic;

namespace _0702.ViewModels
{
  public class TrainerTopicViewModel
  {
    public TrainerTopic TrainerTopic { get; set; }
    public IEnumerable<ApplicationUser> Trainers { get; set; }
    public IEnumerable<Topic> Topics { get; set; }
  }
}