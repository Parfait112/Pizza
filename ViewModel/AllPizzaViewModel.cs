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
    [QueryProperty(nameof(FromSearch), nameof(FromSearch))]
    public partial class AllPizzaViewModel : ObservableObject
    {
        //nous avons un method qui nous permet de lier la base de donne et la page
        private readonly PizzaService _pizzaService;
        public AllPizzaViewModel(PizzaService pizzaService) 
        {
            _pizzaService = pizzaService;
            Pizzas = new(_pizzaService.GetAllPizzas());
        }
        //nous avons un method qui nous permet de faire une collection de tout les element de la base de donnée
        public ObservableCollection<Pizza> Pizzas { get; set; }

        //nous avons variable
        [ObservableProperty]
        private bool _fromSearch;

        [ObservableProperty]
        private bool _searching;

        //nous avons un method qui nous permet de faire des recherche mais cette method sera en forme de command
        [RelayCommand]
        private async Task SearchPizzas(string searchTerm)
        {
            Pizzas.Clear();
            Searching = true;
            await Task.Delay(1000);
            foreach(var pizza in _pizzaService.SearchPizzas(searchTerm))
            {
                Pizzas.Add(pizza);
            }
            Searching = false;
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
