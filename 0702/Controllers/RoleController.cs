using _0702.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Linq;
using System.Web.Mvc;

namespace _0702.Controllers
{
  public class RoleController : Controller
  {
    ApplicationDbContext context;

    public RoleController()
    {
      context = new ApplicationDbContext();
    }

    public ActionResult Index()
    {
      var Roles = context.Roles.ToList();
      return View(Roles);
    }

    public ActionResult Create()
    {
      var Role = new IdentityRole();
      return View(Role);
    }

    /// <param name="Role"></param>
    [HttpPost]
    public ActionResult Create(IdentityRole Role)
    {

      context.Roles.Add(Role);
      context.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult SetRoleToUser()
    {
      var list = context.Roles.OrderBy(role => role.Name).ToList().Select(role => new SelectListItem { Value = role.Name.ToString(), Text = role.Name }).ToList();
      ViewBag.Roles = list;
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult UserAddToRole(string uname, string rolename)
    {
      ApplicationUser user = context.Users.Where(usr => usr.UserName.Equals(uname, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

      // Display All Roles in DropDown

      var list = context.Roles.OrderBy(role => role.Name).ToList().Select(role => new SelectListItem { Value = role.Name.ToString(), Text = role.Name }).ToList();
      ViewBag.Roles = list;

      if (user != null)
      {
        var account = new AccountController();
        account.UserManager.AddToRoleAsync(user.Id, rolename);

        ViewBag.ResultMessage = "Role created successfully !";

        return View("SetRoleToUser");
      }
      else
      {
        ViewBag.ErrorMessage = "Sorry user is not available";
        return View("SetRoleToUser");
      }

    }
  }
}