using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using biblioteka.Data;
using biblioteka.Models;

namespace biblioteka.Controllers;

public class BooksController : Controller
{
    private readonly LibraryContext _context;

    public BooksController(LibraryContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var books = await _context.Books.Include(b => b.Author).ToListAsync();
        return View(books);
    }

    public IActionResult Create()
    {
        ViewBag.Authors = new SelectList(_context.Authors, "Id", "Name");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Book book)
    {
        if (ModelState.IsValid)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewBag.Authors = new SelectList(_context.Authors, "Id", "Name", book.AuthorId);
        return View(book);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book != null)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }
}