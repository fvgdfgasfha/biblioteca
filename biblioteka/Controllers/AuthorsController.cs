using Microsoft.AspNetCore.Mvc;
using biblioteka.Data;
using biblioteka.Models;

namespace biblioteka.Controllers;

public class AuthorsController : Controller
{
    private readonly LibraryContext _context;

    public AuthorsController(LibraryContext context)
    {
        _context = context;
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Author author)
    {
        if (ModelState.IsValid)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Books");
        }
        return View(author);
    }
}