namespace PizzaMAUI.page
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        //nous avons une method qui renvoie a une page 
        private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
        }

    }

}
