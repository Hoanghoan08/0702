using _0702.Models;
using System.Linq;
using System.Web.Mvc;


namespace _0702.Controllers
{
  public class CategoriesController : Controller
  {
    private readonly ApplicationDbContext _context;
    public CategoriesController()
    {
      _context = new ApplicationDbContext();
    }

    // GET: Categories
    public ActionResult Index()
    {
      return View(_context.Categories.ToList());
    }


    public ActionResult Create()
    {
      return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Category category)
    {
      if (!ModelState.IsValid)
      {
        return View();
      }
      if (_context.Categories.Any(c => c.Name.Contains(category.Name)))
      {
        ModelState.AddModelError("Name", "Category Name is already exists.");
        return View(category);
      }
      var newcategory = new Category
      {
        Name = category.Name,
        Description = category.Description
      };
      _context.Categories.Add(newcategory);
      _context.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpGet]
    public ActionResult Edit(int id)
    {
      var cateInDb = _context.Categories.SingleOrDefault(c => c.Id == id);
      if (cateInDb == null)
      {
        return HttpNotFound();
      }
      return RedirectToAction("Index");
    }
    public ActionResult Edit(Category category)
    {
      if (!ModelState.IsValid)
      {
        return View();
      }
      if (_context.Categories.Any(c => c.Name.Contains(category.Name)))
      {
        ModelState.AddModelError("Name", "The Category Name is already exists.");
        return View(category);
      }
      var cateInDb = _context.Categories.SingleOrDefault(c => c.Id == category.Id);
      if (cateInDb == null)
      {
        return HttpNotFound();
      }
      cateInDb.Name = category.Name;
      _context.SaveChanges();
      return RedirectToAction("Index");
    }
    [HttpGet]
    public ActionResult Delete(int id)
    {
      var cateInDb = _context.Categories.SingleOrDefault(c => c.Id == id);
      if (cateInDb == null)
      {
        return HttpNotFound();
      }
      _context.Categories.Remove(cateInDb);
      _context.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
