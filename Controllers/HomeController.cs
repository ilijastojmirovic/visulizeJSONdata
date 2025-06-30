using Microsoft.AspNetCore.Mvc;
using VisualizeJSONData.Services;

namespace VisualizeJSONData.Controllers;

public class HomeController :Controller
{
    private readonly ITimeEntryService _service;

    public HomeController(ITimeEntryService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var employees = await _service.GetSummarizedTimeEntriesAsync();
        return View(employees);
    }
}