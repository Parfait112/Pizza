using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaMAUI.model;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Maui.Alerts;
using PizzaMAUI.page;

namespace PizzaMAUI.ViewModel
{
    [QueryProperty(nameof(Pizza), nameof(Pizza))]
    public partial class DetailsViewModel : ObservableObject,  IDisposable
    {
        //affecter le carteviewmodel dans se code
        private readonly CartViewModel _cartViewModel;
        public DetailsViewModel(CartViewModel cartViewModel)
        {
           _cartViewModel = cartViewModel;

            _cartViewModel.CartClear += OnCartClear;
            _cartViewModel.CartItemRemoved += OnCartItemRemoved;
            _cartViewModel.CartItemUpdated += OnCartItemUpdated;
        }
        //une method pour supprimer les element
        private void OnCartClear(object? sender, EventArgs e) => Pizza.CartQuntity = 0;
        //une method affecter a une autre method pour supprimer les element
        private void OnCartItemRemoved(object? sender, Pizza p) => OnCartItemChanged(p, 0);
        //une method affecter a une autre method pour faire la mise a jour des elements
        private void OnCartItemUpdated(object? sender, Pizza p) => OnCartItemChanged(p, p.CartQuntity);
        //une method pour faire la mise a jour des element
        private void OnCartItemChanged( Pizza p, int quantity)
        {
            if(p.Name == Pizza.Name)
            {
                Pizza.CartQuntity = quantity;
            }
        }
        //declaration d'une variable depuis la une autre base de donnée
        [ObservableProperty]
        private Pizza _pizza;
        

        //c'est une method qui nous permet ajouter un element qui sera utiliser comme une commande
        [RelayCommand]
        private void AddToCart()
        {
            Pizza.CartQuntity++;
            _cartViewModel.UpdateCartItemCommand.Execute(Pizza);
        }

        //c'est une method qui nous permet réduire un element qui sera affecter a une commande 
        [RelayCommand]
        private void RemoveFromCart()
        {
            if (Pizza.CartQuntity > 0)
            {
                Pizza.CartQuntity--;
                _cartViewModel.UpdateCartItemCommand.Execute(Pizza);
            }
        }
        //une method qui condition pour que la une autre page s'affiche
        [RelayCommand]
        private async Task ViewCart()
        {
            if(Pizza.CartQuntity > 0)
            {
                await Shell.Current.GoToAsync(nameof(CartPage));
            }
            else
            {
               await Toast.Make("Please select the quantity using plus (+) button", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            }
        }
        public void Dispose()
        {
            _cartViewModel.CartClear -= OnCartClear;
            _cartViewModel.CartItemRemoved -= OnCartItemRemoved;
            _cartViewModel.CartItemUpdated -= OnCartItemUpdated;
        }
    }


}
