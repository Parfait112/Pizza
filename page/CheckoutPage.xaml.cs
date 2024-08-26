namespace PizzaMAUI.page;

public partial class CheckoutPage : ContentPage
{
	public CheckoutPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();

      
    }
    //c'est une method qui donne une fonction a se button
    private async void homebtn_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}