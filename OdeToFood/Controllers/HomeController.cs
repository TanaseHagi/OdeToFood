using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;
using OdeToFood.Services;
using OdeToFood.ViewModels.Home;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;
        private IGreeter _greeter;

        public HomeController(IRestaurantData restaurantData, IGreeter greeter)
        {
            _restaurantData = restaurantData;
            _greeter = greeter;
        }

        public IActionResult Index()
        {
            var model = new IndexViewModel()
            {
                Restaurants = _restaurantData.GetAll(),
                CurrentMessage = _greeter.getMessageOfTheDay(),
            };

            // return View(model);
            return new ObjectResult(model);

            // return new ObjectResult(model);
            // return Content("Hello from the HomeController!");
        }

        public IActionResult Details(int id)
        {
            var model = _restaurantData.Get(id);
            if (model == null)
            {
                return new ObjectResult(new object());
            }
            return new ObjectResult(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RestaurantEditModel model)
        {
            if (ModelState.IsValid)
            {
                var newRestaurant = new Restaurant
                {
                        Name = model.Name,
                        Cuisine = model.Cuisine,
                };

                newRestaurant = _restaurantData.Add(newRestaurant);

                // POST redirect GET problem
                // return new ObjectResult(model);
                return RedirectToAction(nameof(Details), new { id = newRestaurant.Id });
            }
            return View();
        }
    }
}
