using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LostAndFound.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LostAndFound.LostItemsController {
    public class LostItemsController : Controller
    {
        private readonly ILogger<LostItemsController> _logger;

        private readonly List<ListItem> listItems = [
           new ListItem {Id=1, Name="Sac à dos", LocationFound="Quai 3", DateFound="2024-11-20"},
           new ListItem  {Id=2, Name="Parapluie", LocationFound="Hall Principal", DateFound="2024-11-21"},
           new ListItem  {Id=3, Name="Casquette", LocationFound="Salle d'attente", DateFound="2024-11-22"},
        ];

        public LostItemsController(ILogger<LostItemsController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(listItems);
        }

        public IActionResult Details(int id)
        {
            ListItem item = listItems.Find(item => item.Id == id);
            if(item == null){
                return NotFound();
            }
            return View(item);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

};
