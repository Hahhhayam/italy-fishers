using DAL.Entity;
using DAL.Repo;
using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class StatusesController : Controller
    {
        private readonly ILogger<StatusesController> logger;

        public readonly IRepository<Status> repository;

        public StatusesController(
            ILogger<StatusesController> logger,
            IRepository<Status> repository)
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
        public IActionResult Update(int id, Status entity) 
        {
            this.repository.Update(id, entity);
            return View("Index", this.repository.GetAll());
        }

        [HttpPost]
        public IActionResult Create(Status entity) 
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