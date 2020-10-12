using System.Collections.Generic;
using _0702.Models;


namespace _0702.ViewModels
{
  public class TraineeCourseViewModel
  {
    public TraineeCourse TraineeCourse { get; set; }
    public IEnumerable<ApplicationUser> Trainees { get; set; }
    public IEnumerable<Course> Courses { get; set; }
  }
}

