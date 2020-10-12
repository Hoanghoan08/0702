using _0702.Models;
using System.Linq;
using System.Web.Mvc;

namespace _0702.Controllers
{
  public class TopicsController : Controller
  {
    private readonly ApplicationDbContext _context;
    public TopicsController()
    {
      _context = new ApplicationDbContext();
    }

    // GET: Categories
    public ActionResult Index()
    {
      return View(_context.Topics.ToList());
    }


    public ActionResult Create()
    {
      return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Topic topic)
    {
      if (!ModelState.IsValid)
      {
        return View();
      }
      if (_context.Topics.Any(c => c.Name.Contains(topic.Name)))
      {
        ModelState.AddModelError("Name", "Topic Name is already exists.");
        return View(topic);
      }

      _context.Topics.Add(topic);
      _context.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpGet]
    public ActionResult Edit(int id)
    {

      Topic topic = _context.Topics.Find(id);
      if (topic == null)
      {
        return HttpNotFound();
      }
      return View(topic);
    }
    public ActionResult Edit(Topic topic)
    {
      if (ModelState.IsValid)
      {
        return View();
      }
      /*if (_context.Categories.Any(c => c.Name.Contains(category.Name)))
      {
        ModelState.AddModelError("Name", "The Category Name is already exists.");
        return View(category);
      }*/
      var topicInDb = _context.Topics.SingleOrDefault(t => t.Id == topic.Id);
      if (topicInDb == null)
      {
        return HttpNotFound();
      }
      topicInDb.Name = topic.Name;
      _context.SaveChanges();
      return RedirectToAction("Index");
    }
    [HttpGet]
    public ActionResult Delete(int id)
    {
      var topicInDb = _context.Topics.SingleOrDefault(t => t.Id == id);
      if (topicInDb == null)
      {
        return HttpNotFound();
      }
      _context.Topics.Remove(topicInDb);
      _context.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
