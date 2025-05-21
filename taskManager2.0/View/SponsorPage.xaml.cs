using System.Text.Json;
using taskManager2._0.Module;
namespace taskManager2._0.View;


public partial class SponsorPage : ContentPage
{
    int productAmount = 3; 
    public SponsorPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var products = await GetProductsAsync(productAmount);
        ProductsView.ItemsSource = products;
    }

    private async void ButtonProductAmount(object sender, EventArgs e)
    {
        if (int.TryParse(EntryProductAmount.Text, out int productAmount))
        {
            var products = await GetProductsAsync(productAmount);
            ProductsView.ItemsSource = products;
            EntryProductAmount.Text = string.Empty;
        }
        else
        {
            await DisplayAlert("Warning", "Please add a number, max 20", "Ok");
        }
    }
    public async Task<List<Sponsor>> GetProductsAsync(int limit)
    {
        using var httpClient = new HttpClient();
        var response = await httpClient.GetStringAsync($"https://fakestoreapi.com/products?limit={limit}");
        return JsonSerializer.Deserialize<List<Sponsor>>(response);
    }
}