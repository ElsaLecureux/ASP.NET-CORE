using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AppMVC.Models;
using Data;
using Microsoft.EntityFrameworkCore;

namespace AppMVC.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    // private List<Product> productsList= [];
    // private static List<Book> booksList = [
    //         new Book { Id=1, Title="Lord of the Rings", NumberOfVolume=3 },
    //         new Book { Id=2, Title="Royal Assassin", NumberOfVolume=7 },
    //     ];
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
        // this.productsList = [
        //     new Product { Id=1, Name="chouquettes", Price=3.50 },
        //     new Product { Id=2, Name="eclair au chocolat", Price=4.50 },
        // ];
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Products()
    {
       var products = await _context.Products.ToListAsync();
       return View(products);
    }

    public async Task<IActionResult> ProductDetails(int id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(product => product.Id == id);
        if (product == null){
                return NotFound();
        }
        if (ModelState.IsValid)
        {
            return View(product);
        }
        return NotFound();
    }

    // public IActionResult Products()
    // {
    //     return View(productsList);
    // }

    // public IActionResult ProductDetails(int id)
    // {
    //     Product? product = productsList.Find(product => product.Id == id);
    //     if (product == null){
    //             return NotFound();
    //     }
    //     return View(product);
    // }

    public async Task<IActionResult> Books()
    {
        List<Book> books = await _context.Books.ToListAsync();
        return View(books);
    }

    public async Task<IActionResult> BookDetails(int id)
    {
        var book = await _context.Books.FirstOrDefaultAsync(book => book.Id == id);
        if (book == null){
                return NotFound();
        }
         if (ModelState.IsValid)
        {
            return View(book);
        }
        return NotFound();
    }

    public async Task<IActionResult> DeleteBook(int id)
    {
        Book? book = await _context.Books.FirstOrDefaultAsync(book => book.Id == id);
        if (book == null){
                return NotFound();
        }
        _context.Books.Remove(book);
        await _context.SaveChangesAsync(); 

        return RedirectToAction("Books");      
    }

    // public IActionResult Books()
    // {
    //     return View(booksList);
    // }

    // public IActionResult BookDetails(int id)
    // {
    //     Book? book = booksList.Find(book => book.Id == id);
    //     if (book == null){
    //             return NotFound();
    //     }
    //     return View(book);
    // }

    // public IActionResult DeleteBook(int id)
    // {
    //     Book? book = booksList.Find(book => book.Id == id);
    //     if (book == null){
    //             return NotFound();
    //     }
    //     booksList.Remove(book);
    //     return RedirectToAction("Books");
    // }

    public IActionResult BookForm()
    {
        return View();
    }
    public async Task<IActionResult> CreateBook(Book book)
    {
       Book createdBook = new Book{Title=book.Title, NumberOfVolume=book.NumberOfVolume};
       _context.Books.Add(createdBook);
       await _context.SaveChangesAsync();
       return RedirectToAction("Books");
    }

    // public IActionResult CreateBook(Book book)
    // {
    //     Console.WriteLine(book.NumberOfVolume);
    //    Book createdBook = new Book{Id= book.Id, Title=book.Title, NumberOfVolume=book.NumberOfVolume};
    //    booksList.Add(createdBook);
    //    Console.WriteLine(createdBook.NumberOfVolume);
    //    return RedirectToAction("Books");
    // }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
