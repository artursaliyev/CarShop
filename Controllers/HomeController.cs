using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CarShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CarShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICarRepository _carRepository;

        public HomeController(ILogger<HomeController> logger, ICarRepository carRepository)
        {
            _logger = logger;
            _carRepository = carRepository;
        }

        public IActionResult Index()
        {
            var cars = _carRepository.GetAll();
            return View(cars);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Car car)
        {
            var newCar = _carRepository.Create(car);
            return RedirectToAction("index");
        }

        public IActionResult Search(int startPrice, int endPrice)
        {
            var cars = _carRepository.Search(startPrice, endPrice);
            return View("Index", cars);
        }


    }
}
