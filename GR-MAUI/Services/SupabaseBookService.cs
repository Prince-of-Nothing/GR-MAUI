using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using GR_MAUI.Models;

namespace GR_MAUI.Services;

public class SupabaseBookService : IBookService
{
    private readonly HttpClient _http = new();
    private const string SupabaseUrl = "https://mbikuyuhcttkcqpgiihr.supabase.co/rest/v1/books";
    private const string ApiKey = "sb_publishable_0Z2sgGgw8f9RqCwxxJNCbw_mUrMQXfE";

    public SupabaseBookService()
    {
        _http.DefaultRequestHeaders.Add("apikey", ApiKey);
        _http.DefaultRequestHeaders.Add("Authorization", "Bearer " + ApiKey);
    }

    public async Task<List<Book>> GetBooksAsync()
    {
        try
        {
            var books = await _http.GetFromJsonAsync<List<Book>>(SupabaseUrl);
            return books ?? new List<Book>();
        }
        catch
        {
            return new List<Book>();
        }
    }
}
