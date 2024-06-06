using Microsoft.AspNetCore.Mvc;
using DAL.Entity;
using DAL.Repo;

namespace PL.Controllers
{
    public class PersonsController: Controller
    {
        private readonly ILogger<PersonsController> logger;

        public readonly IRepository<Person> repository;

        public PersonsController(
            ILogger<PersonsController> logger,
            IRepository<Person> repository)
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
        public IActionResult Update(int id, Person person) 
        {
            this.repository.Update(id, person);
            return View("Index", this.repository.GetAll());
        }

        [HttpPost]
        public IActionResult Create(Person person) 
        {
            person.id = this.repository.GetAll().Select(a => a.id).Max() + 1;
            this.repository.Add(person);
            return View("Index", this.repository.GetAll());
        }

        public IActionResult Delete(int id)
        {
            this.repository.Delete(id);
            return View("Index", this.repository.GetAll());
        }
    }
}
