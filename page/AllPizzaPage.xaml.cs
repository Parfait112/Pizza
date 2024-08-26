using PizzaMAUI.ViewModel;

namespace PizzaMAUI.page;

public partial class AllPizzaPage : ContentPage
{
    //nous avons un method qui nous permet de lier la base de donne et la page
    private readonly AllPizzaViewModel _allPizzaViewModel;

    public AllPizzaPage(AllPizzaViewModel allPizzaViewModel)
	{
		InitializeComponent();
        _allPizzaViewModel = allPizzaViewModel;
        BindingContext = _allPizzaViewModel;
    }
    //nous avons un method qui nous montre se qui vient en premier
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (_allPizzaViewModel.FromSearch)
        {
            await Task.Delay(100);
            searchBar.Focus();
        }
    }
    //nous avons un method qui est attribuer la barre de recherche sa nous montre si le page est vide ou pas
    private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        if(!string.IsNullOrWhiteSpace(e.OldTextValue) && string.IsNullOrWhiteSpace(e.NewTextValue))
        {
            _allPizzaViewModel.SearchPizzasCommand.Execute(null);
        }
    }
}