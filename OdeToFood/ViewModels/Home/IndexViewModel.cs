using OdeToFood.Models;
using System.Collections.Generic;

namespace OdeToFood.ViewModels.Home
{
    public class IndexViewModel
    {
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public string CurrentMessage { get; set; }
    }
}
