﻿using _0702.Models;
using _0702.ViewModels;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace _0702.Controllers
{
  public class CoursesController : Controller
  {
    // GET: Courses
    private ApplicationDbContext _context;

    public CoursesController()
    {
      _context = new ApplicationDbContext();
    }

    // GET: Products
    [HttpGet]
    public ActionResult Index(string searchString)
    {
      var courses = _context.Courses
      .Include(c => c.Topic)
      .Include(c => c.Category);

      if (!String.IsNullOrEmpty(searchString))
      {
        courses = courses.Where(
          s => s.Name.Contains(searchString) ||
          s.Category.Name.Contains(searchString) ||
          s.Topic.Name.Contains(searchString));
      }

      return View(courses.ToList());
    }

    [HttpGet]
    //[Authorize(Roles = "admin")]
    public ActionResult Create()
    {
      var viewModel = new CourseViewModel
      {
        Categories = _context.Categories,
        Topics = _context.Topics
        .ToList()
      };
      return View(viewModel);
    }

    [HttpPost]

    public ActionResult Create(Course course)
    {
      if (!ModelState.IsValid)
      {
        return View();
      }

      if (_context.Courses.Any(c => c.Name.Contains(course.Name)))
      {
        ModelState.AddModelError("Name", "Product Name Already Exists.");
        return View();
      }

      var newCourse = new Course
      {
        Name = course.Name,
        Description = course.Description,
        CategoryId = course.CategoryId,
        TopicId = course.TopicId
      };

      _context.Courses.Add(newCourse);
      _context.SaveChanges();

      return RedirectToAction("Index");
    }

    [HttpGet]
    //[Authorize(Roles = "Staff")]

    public ActionResult Delete(int id)
    {
      var CourseInDb = _context.Courses.SingleOrDefault(c => c.Id == id);

      if (CourseInDb == null)
      {
        return HttpNotFound();
      }

      _context.Courses.Remove(CourseInDb);
      _context.SaveChanges();

      return RedirectToAction("Index");
    }

    [HttpGet]
    //[Authorize(Roles = "Staff")]

    public ActionResult Edit(int id)
    {
      var CourseInDb = _context.Courses.SingleOrDefault(c => c.Id == id);

      if (CourseInDb == null)
      {
        return HttpNotFound();
      }

      var viewModel = new CourseViewModel
      {
        Course = CourseInDb,
        Categories = _context.Categories,
        Topics = _context.Topics
        .ToList()
      };

      return View(viewModel);
    }

    [HttpPost]
    //[Authorize(Roles = "Staff")]

    public ActionResult Edit(Course course)
    {
      if (!ModelState.IsValid)
      {
        return View();
      }

      var CourseInDb = _context.Courses.SingleOrDefault(c => c.Id == course.Id);

      if (CourseInDb == null)
      {
        return HttpNotFound();
      }

      CourseInDb.Name = course.Name;
      CourseInDb.Description = course.Description;
      CourseInDb.CategoryId = course.CategoryId;
      CourseInDb.TopicId = course.TopicId;
      _context.SaveChanges();

      return RedirectToAction("Index");
    }
  }
}