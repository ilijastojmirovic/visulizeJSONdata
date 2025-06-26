using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VisualizeJSONData.Services;

namespace VisualizeJSONData.Pages;

public class ChartModel : PageModel
{
    private readonly ITimeEntryService _service;

    public ChartModel(ITimeEntryService service)
    {
        _service = service;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    public async Task<IActionResult> OnGetImageAsync()
    {
        var data = await _service.GetSummarizedTimeEntriesAsync();

        var labels = data.Select(e => e.Employee).ToArray();
        var values = data.Select(e => e.TotalHours).ToArray();
        
        var plt = new ScottPlot.Plot(800, 600);
        var pie = plt.AddPie(values);
        pie.SliceLabels = labels;
        pie.ShowPercentages = true;
        pie.ShowValues = false;
        pie.Explode = false;

        plt.Legend();
        plt.Title("Percentage of Work Hours");

        var image = plt.Render();

        var stream = new MemoryStream();
        image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
        stream.Position = 0;

        return File(stream, "image/png");
    }
}