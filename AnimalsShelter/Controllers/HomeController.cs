using AnimalsShelter.Models;
using AutoMapper;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AnimalsShelter.Controllers
{
    public class HomeController(IMapper mapper, AnimalsShelterDbContext context) : Controller
    {
        private readonly AnimalsShelterDbContext context = context;
        private readonly IMapper mapper = mapper;

        public IActionResult Index()
        {
            var Animals = context.Animals.Include(x => x.Gender).Include(x => x.AnimalType).ToList();

            return View(mapper.Map<IEnumerable<AnimalModel>>(Animals));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
