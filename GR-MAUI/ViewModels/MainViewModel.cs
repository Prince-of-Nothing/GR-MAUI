using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GR_MAUI.Models;
using GR_MAUI.Services;

namespace GR_MAUI.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    private readonly IBookService _bookService = new SupabaseBookService();

    [ObservableProperty]
    public partial ObservableCollection<Book> Books { get; set; } = new();

    [ObservableProperty]
    public partial bool IsLoading { get; set; }

    [RelayCommand]
    private async Task LoadBooksAsync()
    {
        IsLoading = true;
        Books.Clear();
        var result = await _bookService.GetBooksAsync();
        foreach (var b in result)
            Books.Add(b);
        IsLoading = false;
    }

    public MainViewModel()
    {
        _ = LoadBooksAsync();
    }
}
