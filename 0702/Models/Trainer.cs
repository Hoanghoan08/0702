﻿using System.ComponentModel.DataAnnotations;

namespace _0702.Models
{
  public class Trainer
  {
    public int Id { get; set; }
    [Required]
    [Display(Name ="Full Name")]
    public string FullName { get; set; }
    [Required]
    [Display(Name ="Working Place")]
    public string WorkingPlace { get; set; }
    [Required]
    [Display(Name ="Phone Number")]
    public string PhoneNumber { get; set; }
  }
}