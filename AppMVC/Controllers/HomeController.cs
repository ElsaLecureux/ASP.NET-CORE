using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AppMVC.Models;

namespace AppMVC.Controllers;

public class HomeController : Controller
{
    private List<Product> productsList= [];
    private static List<Book> booksList = [
            new Book { Id=1, Title="Lord of the Rings", NumberOfVolume=3 },
            new Book { Id=2, Title="Royal Assassin", NumberOfVolume=7 },
        ];
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        this.productsList = [
            new Product { Id=1, Name="chouquettes", Price=3.50 },
            new Product { Id=2, Name="eclair au chocolat", Price=4.50 },
        ];
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Products()
    {
        return View(productsList);
    }

    public IActionResult ProductDetails(int id)
    {
        Product? product = productsList.Find(product => product.Id == id);
        if (product == null){
                return NotFound();
        }
        return View(product);
    }

    public IActionResult Books()
    {
        return View(booksList);
    }

    public IActionResult BookDetails(int id)
    {
        Book? book = booksList.Find(book => book.Id == id);
        if (book == null){
                return NotFound();
        }
        return View(book);
    }

    public IActionResult DeleteBook(int id)
    {
        Book? book = booksList.Find(book => book.Id == id);
        if (book == null){
                return NotFound();
        }
        booksList.Remove(book);
        return RedirectToAction("Books");
    }

    public IActionResult BookForm()
    {
        return View();
    }

    public IActionResult CreateBook(Book book)
    {
        Console.WriteLine(book.NumberOfVolume);
       Book createdBook = new Book{Id= book.Id, Title=book.Title, NumberOfVolume=book.NumberOfVolume};
       booksList.Add(createdBook);
       Console.WriteLine(createdBook.NumberOfVolume);
       return RedirectToAction("Books");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
