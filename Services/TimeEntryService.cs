using System.Text.Json;
using VisualizeJSONData.Models;

namespace VisualizeJSONData.Services;

public class TimeEntryService : ITimeEntryService
{
    
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _config;
    
    public TimeEntryService(HttpClient httpClient, IConfiguration config)
    {
        _httpClient = httpClient;
        _config = config;
    }
    
    public async Task<List<TimeEntrySummary>> GetSummarizedTimeEntriesAsync()
    {
        var apiUrl = _config["TimeEntryApi:Url"];
        var response = await _httpClient.GetStringAsync(apiUrl);
        var rawEntries = JsonSerializer.Deserialize<List<RawEntry>>(response);
        var totals = new Dictionary<string, double>();

        foreach (var rawEntry in rawEntries!)
        {
            if(rawEntry.DeletedOn != null || rawEntry.EndTimeUtc <= rawEntry.StarTimeUtc || string.IsNullOrWhiteSpace(rawEntry.EmployeeName))
                continue;
            
            var duration = (rawEntry.EndTimeUtc - rawEntry.StarTimeUtc).TotalHours;

            if (totals.ContainsKey(rawEntry.EmployeeName))
                totals[rawEntry.EmployeeName] += duration;
            else
                totals[rawEntry.EmployeeName] = duration;
            
        }
        
        var result = totals.Select(e => new TimeEntrySummary
        {
            Employee = e.Key,
            TotalHours = e.Value
        }).OrderByDescending(e => e.TotalHours).ToList();
        
        return result;
    }
}