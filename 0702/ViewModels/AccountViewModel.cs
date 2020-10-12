using System.Collections.Generic;

namespace _0702.ViewModels
{
  public class AccountViewModel
  {
    public string UserId { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string RoleName { get; set; }
    public List<AccountViewModel> Trainee { get; set; }
    public List<AccountViewModel> Trainer { get; set; }
    public List<AccountViewModel> Staff { get; set; }
    public object[] Id { get; internal set; }
  }
}