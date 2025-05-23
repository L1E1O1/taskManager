using System.Diagnostics;
using System.Text.Json;
using taskManager2._0.Module;
using taskManager2._0.View;
namespace taskManager2._0.View;



public partial class SponsorPage : ContentPage
{
    int productAmount = 3;
    LoginManagerList loginManager = LoginManagerList.LoginManager;
    public SponsorPage()
	{
		InitializeComponent();
    }
    

    //  väntar på när items loadar
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var products = await GetProductsAsync(productAmount);
        ProductsView.ItemsSource = products;

        TaxPrice();


    }

    // ändrar texten i labeln beroende på vilken typ av användare som är inloggad
    private void TaxPrice()
    {

        if (loginManager.Users.Count > 0)
        {
        var user = loginManager.Users[0];

            if (user.accessLevel == 1)
            {
                Debug.WriteLine("string");
                sponsorLabel.Text = $" Hello {user.Name}, this is our Sponsor have a look at these amazing products have in mind each price is +  25% tax";

              
            }
            else if (user.accessLevel == 0)
            {
                sponsorLabel.Text =  $" Hello {user.Name}, this is our Sponsor have a look at these amazing products have in mind each price is +  0% tax";

            
            }

        } 
        else
        {
            sponsorLabel.Text = "Log In to access to purchese";
        }

    }

    // läser in en ny lista med produkter och sätter den som source för listan
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

    //hämtar in produkter från en API
    public async Task<List<Sponsor>> GetProductsAsync(int limit)
    {
        using var httpClient = new HttpClient();
        var response = await httpClient.GetStringAsync($"https://fakestoreapi.com/products?limit={limit}");
        return JsonSerializer.Deserialize<List<Sponsor>>(response);
    }
}