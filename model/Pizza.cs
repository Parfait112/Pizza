using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMAUI.model
{
    public partial class Pizza : ObservableObject
    {
        //tout se sont des variables de la de l'application
        public string Name { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }

        [ObservableProperty, NotifyPropertyChangedFor(nameof(Amount))]
        private int _cartQuntity;

        //ici nous affectons plusieurs variables a une autre variable
        public double Amount => CartQuntity * Price;
        //nous avons un method pour double notre element
        public Pizza Clone() => MemberwiseClone() as Pizza;
    }
}
