using AnimalsShelter.Models;
using AnimalsShelter.IServices;
using AutoMapper;
using Data;
using Data.Enteties;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AnimalsShelter.Controllers
{
    public class AnimalsController(IMapper mapper, AnimalsShelterDbContext context, IFilesService filesService) : Controller
    {
		private AnimalsShelterDbContext context = context;
        private readonly IMapper mapper = mapper;
        private readonly IFilesService filesService = filesService;

        public IActionResult Index()
        {
            var Animals = context.Animals.Include(x => x.Gender).Include(x => x.AnimalType).ToList();

            return View(Animals);
        }

        private void Load()
        {
            ViewBag.Genders = new SelectList(context.Genders.ToList(), "Id", "Name");
            ViewBag.AnimalTypes = new SelectList(context.AnimalTypes.ToList(), "Id", "Name");
        }

        [HttpGet]
        public IActionResult Add()
        {
            Load();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddAnimalModel model)
        {
            if (!ModelState.IsValid)
            {
                Load();

                return View(model);
            }

            Animal animal = mapper.Map<Animal>(model);

            if (model.Image != null)
            {
                animal.ImageUrl = await filesService.SaveImage(model.Image);
            }

            context.Animals.Add(animal);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var Animal = context.Animals.Find(Id);

            if (Animal == null) { return NotFound(); }
            Load();
            EditAnimalModel model = mapper.Map<EditAnimalModel>(Animal);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditAnimalModel model)
        {
            if (!ModelState.IsValid)
            {
                Load();

                return View(model);
            }

            Animal animal = mapper.Map<Animal>(model);
            if (model.Image != null)
            {
                animal.ImageUrl = await filesService.EditImage(model.Image, model.ImageUrl!);
            }

            context.Animals.Update(animal);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Info(int Id)
        {
            var Animal = context.Animals.Include(x => x.Gender).Include(x => x.AnimalType).FirstOrDefault(x => x.Id == Id);

            if (Animal == null) { return NotFound(); }

            return View(Animal);
        }

        public async Task<IActionResult> Delete(int Id) {
            var Animal = context.Animals.Find(Id);
            if (Animal == null) {
                return NotFound();
            }

            if (Animal.ImageUrl != null)
            {
                await filesService.DeleteImage(Animal.ImageUrl);
            }

            context.Animals.Remove(Animal);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
