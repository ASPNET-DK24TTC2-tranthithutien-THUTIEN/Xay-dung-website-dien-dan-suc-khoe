using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealthForumMVC.Models;

namespace HealthForumMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var categories = await _context.Categories
            .OrderBy(c => c.DisplayOrder)
            .ToListAsync();

        var recentTopics = await _context.Topics
            .Include(t => t.Author)
            .Include(t => t.Category)
            .Where(t => !t.IsDeleted)
            .OrderByDescending(t => t.CreatedDate)
            .Take(10)
            .ToListAsync();

        var popularTopics = await _context.Topics
            .Include(t => t.Author)
            .Include(t => t.Category)
            .Where(t => !t.IsDeleted)
            .OrderByDescending(t => t.ViewCount)
            .Take(5)
            .ToListAsync();

        ViewData["Categories"] = categories;
        ViewData["RecentTopics"] = recentTopics;
        ViewData["PopularTopics"] = popularTopics;

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

