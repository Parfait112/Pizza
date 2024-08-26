using CommunityToolkit.Maui.Behaviors;
using PizzaMAUI.ViewModel;

namespace PizzaMAUI.page;

public partial class DetailePage : ContentPage
{
    //nous avons un method qui nous permet de lier la base de donne et la page
    private readonly DetailsViewModel _detailsViewModel;
	public DetailePage(DetailsViewModel detailsViewModel)
	{
		InitializeComponent();
		_detailsViewModel = detailsViewModel;
		BindingContext = _detailsViewModel;

    }
    //c'est une method pour aller la page précédant
    private async void ImageButton_Clicked_1(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..", animate:true);
    }
    //c'est une method qui nous fait que les proprete de cette page ne doit pas affecter tout les autre page
    protected override void OnNavigatedFrom(NavigatedFromEventArgs args)
    {
        base.OnNavigatedFrom(args);
        Behaviors.Add(new CommunityToolkit.Maui.Behaviors.StatusBarBehavior
        {
            StatusBarColor = Colors.DarkGoldenrod,
            StatusBarStyle = CommunityToolkit.Maui.Core.StatusBarStyle.DarkContent,
        });
    }
}