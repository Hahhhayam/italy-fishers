using Microsoft.AspNetCore.Mvc;
using DAL.Entity;
using DAL.Repo;

namespace PL.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly ILogger<ReservationsController> logger;

        public readonly IRepository<Reservation> repository;

        public ReservationsController(
            ILogger<ReservationsController> logger,
            IRepository<Reservation> repository)
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
        public IActionResult Update(int id, Reservation entity) 
        {
            entity.created_at = DateTime.Now;
            this.repository.Update(id, entity);
            return View("Index", this.repository.GetAll());
        }

        [HttpPost]
        public IActionResult Create(Reservation entity) 
        {
            entity.id = this.repository.GetAll().Select(a => a.id).Max() + 1;
            entity.created_at = DateTime.Now;
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