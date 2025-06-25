using VisualizeJSONData.Models;

namespace VisualizeJSONData.Services;

public interface ITimeEntryService
{
    Task<List<TimeEntrySummary>> GetSummarizedTimeEntriesAsync();
}