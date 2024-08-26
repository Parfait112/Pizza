
using PizzaMAUI.ViewModel;

namespace PizzaMAUI.page;

public partial class HomePage : ContentPage
{
	//nous avons un method qui nous permet de lier la base de donne et la page
	private readonly HomeViewModel _homeViewModel;
	public HomePage(HomeViewModel homeViewModel)
	{
        InitializeComponent();
        _homeViewModel = homeViewModel;
		BindingContext = _homeViewModel;
	}
}