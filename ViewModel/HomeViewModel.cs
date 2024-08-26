using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PizzaMAUI.model;
using PizzaMAUI.page;
using PizzaMAUI.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMAUI.ViewModel
{
    public partial class HomeViewModel : ObservableObject
    {
        //nous avons un method qui nous permet de lier la base de donne et la page
        private readonly PizzaService _pizzaService;
        public  HomeViewModel(PizzaService pizzaService)
        {
            _pizzaService = pizzaService;
            Pizzas = new(_pizzaService.GetPopularPizzas());
        }
        //nous avons un method qui nous permet de faire une collection de tout les element de la base de donnée
        public ObservableCollection<Pizza> Pizzas { get; set; }
       
        //nous avons un method qui nous permet de recupere tout les variable definir mais cette method sera en forme de command
        [RelayCommand]
        private async Task GoToAllPizzasPage(bool fromSearch = false)
        {
            var parameters = new Dictionary<string, object>()
            {
                [nameof(AllPizzaViewModel.FromSearch)] = fromSearch
            };
            await Shell.Current.GoToAsync(nameof(AllPizzaPage), animate:true, parameters);
        }

        //nous avons un method qui nous permet de partir sur une page pour avoir plus d'infos sur la variable mais cette method sera en forme de command
        [RelayCommand]
        private async Task GoToDetailsPage(Pizza pizza)
        {
            var parameters = new Dictionary<string, object>()
            {
                [nameof(DetailsViewModel.Pizza)] = pizza
            };
            await Shell.Current.GoToAsync(nameof(DetailePage), animate: true, parameters);
        } 

    }
}
