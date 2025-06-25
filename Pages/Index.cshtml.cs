using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VisualizeJSONData.Models;
using VisualizeJSONData.Services;

namespace VisualizeJSONData.Pages;

public class IndexModel : PageModel
{
    private readonly ITimeEntryService _service;

    public IndexModel(ITimeEntryService service)
    {
        _service = service;
    }

    public List<TimeEntrySummary> Employees { get; set; }

    public async Task OnGetAsync()
    {
        Employees = await _service.GetSummarizedTimeEntriesAsync();
    }
}
