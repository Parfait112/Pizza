using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PizzaMAUI.model;
using PizzaMAUI.page;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMAUI.ViewModel
{
    public partial class CartViewModel : ObservableObject
    {
        //nous introduisons un évènement pour que quand tout la page est vide quelque chose s'affiche
        public event EventHandler<Pizza> CartItemRemoved;
        //nous introduisons un évènement pour que quand la pge se maitre a jour quelque chose s'affiche
        public event EventHandler<Pizza> CartItemUpdated;
        //un autre évènement créer
        public event EventHandler CartClear;
        //la déclaration de la variable comme une collection
        public ObservableCollection<Pizza> Items { get; set; } = new();
        //la variable
        [ObservableProperty]
        private double _totalAmount;
        //une method pour calculer le montant 
        private void RecalculateTotalAmount() => TotalAmount = Items.Sum(i => i.Amount);
        //une method pour la mise a jour de la page sur forme de command
        [RelayCommand]
        private void UpdateCartItem(Pizza pizza)
        {
            var item = Items.FirstOrDefault(i => i.Name == pizza.Name);
            if (item != null)
            {
                item.CartQuntity = pizza.CartQuntity;
            }
            else
            {
                Items.Add(pizza.Clone()); 
            }
            RecalculateTotalAmount();
        }
        //une method pour enlever les element de la page
        [RelayCommand]
        private async void RemoveCartItem(string name)
        {
            var item = Items.FirstOrDefault(i => i.Name == name);
            if (item != null)
            {
                Items.Remove(item);
                RecalculateTotalAmount();

                CartItemRemoved?.Invoke(this, item);

                var snackbarOptions = new SnackbarOptions
                {
                    CornerRadius =10,
                    BackgroundColor = Colors.PaleGoldenrod
                };
                 var snakbar = Snackbar.Make($"'{item.Name}' remove from cart", () =>
                {
                    Items.Add(item);
                    RecalculateTotalAmount();
                    CartItemUpdated?.Invoke(this, item);
                }, "Undo", TimeSpan.FromSeconds(5), snackbarOptions);
                await snakbar.Show();
            }
        }
        //une method pour supprimer les element avec un message de confirmation
        [RelayCommand]
        private async void ClearCart()
        {
           if (await Shell.Current.DisplayAlert("Confirm Clear Cart?", "Do you really want to clear the cart items", "Yes", "No"))
            {
                Items.Clear();
                RecalculateTotalAmount();
                CartClear?.Invoke(this, EventArgs.Empty);
                await Toast.Make("Cart Cleared", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            }
           
        }
        //une method pour placer le l'ordre du produit
        [RelayCommand]
        private async Task PlaceOrder()
        {
            Items.Clear();
            CartClear?.Invoke(this, EventArgs.Empty);
            RecalculateTotalAmount();
            await Shell.Current.GoToAsync(nameof(CheckoutPage), animate: true);
        }
    }
}
