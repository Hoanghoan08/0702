using _0702.Models;
using _0702.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace _0702.Controllers
{
  public class AccountViewModelsController : Controller
  {
    // GET: AccountViewModels
    ApplicationDbContext _context;
    public AccountViewModelsController()
    {
      _context = new ApplicationDbContext();
    }
    // GET: ManagerStaffViewModels
    public ActionResult Index()
    {
      var roleTrainee = (from r in _context.Roles where r.Name.Contains("Trainee") select r).FirstOrDefault();
      var trainees = _context.Users.Where(x => x.Roles.Select(y => y.RoleId).Contains(roleTrainee.Id)).ToList();
      var traineeVM = trainees.Select(user => new AccountViewModel
      {
        UserName = user.UserName,
        Email = user.Email,
        RoleName = "Trainee",
        UserId = user.Id
      }).ToList();


      var roleTrainer = (from r in _context.Roles where r.Name.Contains("Trainer") select r).FirstOrDefault();
      var trainers = _context.Users.Where(x => x.Roles.Select(y => y.RoleId).Contains(roleTrainer.Id)).ToList();

      var trainerVM = trainers.Select(user => new AccountViewModel
      {
        UserName = user.UserName,
        Email = user.Email,
        RoleName = "Trainer",
        UserId = user.Id
      }).ToList();

      var roleStaff = (from r in _context.Roles where r.Name.Contains("Staff") select r).FirstOrDefault();
      var staffs = _context.Users.Where(x => x.Roles.Select(y => y.RoleId).Contains(roleStaff.Id)).ToList();

      var staffVM = staffs.Select(user => new AccountViewModel
      {
        UserName = user.UserName,
        Email = user.Email,
        RoleName = "Staff",
        UserId = user.Id
      }).ToList();


      var model = new AccountViewModel { Trainee = traineeVM, Trainer = trainerVM, Staff = staffVM };
      return View(model);

    }
  }
}