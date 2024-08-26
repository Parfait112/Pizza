using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using PizzaMAUI.model;

namespace PizzaMAUI.Service
{
    public class PizzaService 
    {
        //nous donnons des valeur a ses variable définir dans la base de donnée
        private readonly static IEnumerable<Pizza> _pizzas = new List<Pizza>
        {
            new Pizza
            {
                Name = "Pizza 1",
                Image = "pi2",
                Price = 5.1
            },
            new Pizza
            {
                Name = "Pizza 2",
                Image = "pi3",
                Price = 15.5
            },
            new Pizza
            {
                Name = "Pizza 3",
                Image = "pi4",
                Price = 20.5
            },
            new Pizza
            {
                Name = "Pizza 4",
                Image = "pi5",
                Price = 10.5
            },
            new Pizza
            {
                Name = "Pizza 5",
                Image = "pi6",
                Price = 13.5
            }
        };

        //nous avons une method qui nous permet de récupère tout les valeur définir en dessous
        public IEnumerable<Pizza> GetAllPizzas() => _pizzas;
        //nous avons une method qui nous permet de conter les valeur et leur arrange
        public IEnumerable<Pizza> GetPopularPizzas(int count = 6) => _pizzas.OrderBy(p => Guid.NewGuid()).Take(count);
        //nous avons une method qui nous permet  de fair la recherche en fonction des valeur
        public IEnumerable<Pizza> SearchPizzas(string searchTerm) => string.IsNullOrWhiteSpace(searchTerm) ? _pizzas : _pizzas.Where(p => p.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
    }
}