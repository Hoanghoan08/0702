using System.Linq;
using System.Web.Mvc;
using _0702.Models;

namespace _0702.Controllers
{
  public class TraineesController : Controller
  {
    // GET: Trainee
    private readonly ApplicationDbContext _context;
    public TraineesController()
    {
      _context = new ApplicationDbContext();
    }

    // GET: Categories
    public ActionResult Index()
    {
      return View(_context.Trainees.ToList());
    }
    public ActionResult Create()
    {
      return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Trainee trainee)
    {
      /*if (!ModelState.IsValid)
      {
        return View();
      }
      if (_context.Trainees.Any(c => c.FullName.Contains(trainee.FullName)))
      {
        ModelState.AddModelError("Name", "Your Name is already exists.");
        return View(trainee);
      }

      var newtrainee = new Trainee
      {
        FullName = trainee.FullName
      };*/
      _context.Trainees.Add(trainee);
      _context.SaveChanges();
      return RedirectToAction("Index");
    }
    [HttpGet]
    public ActionResult Delete(int id)
    {
      var traineeInDb = _context.Trainees.SingleOrDefault(t => t.Id == id);
      if (traineeInDb == null)
      {
        return HttpNotFound();
      }
      _context.Trainees.Remove(traineeInDb);
      _context.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}