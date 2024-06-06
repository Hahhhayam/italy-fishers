using DAL.Entity;
using DAL.Repo;
using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class WatersourcesController : Controller
    {
        private readonly ILogger<WatersourcesController> logger;

        public readonly IRepository<Watersource> repository;

        public WatersourcesController(
            ILogger<WatersourcesController> logger,
            IRepository<Watersource> repository)
        {
            this.logger = logger;
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View(this.repository.GetAll());
        }

        public IActionResult Modify(int id)
        {
            return View(this.repository.Get(id));
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Update(int id, Watersource entity) 
        {
            this.repository.Update(id, entity);
            return View("Index", this.repository.GetAll());
        }

        [HttpPost]
        public IActionResult Create(Watersource entity) 
        {
            entity.id = this.repository.GetAll().Select(a => a.id).Max() + 1;
            this.repository.Add(entity);
            return View("Index", this.repository.GetAll());
        }

        public IActionResult Delete(int id)
        {
            this.repository.Delete(id);
            return View("Index", this.repository.GetAll());
        }
    }
}