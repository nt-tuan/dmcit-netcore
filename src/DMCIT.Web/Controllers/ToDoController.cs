using DMCIT.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DMCIT.Web.Controllers
{
    public class ToDoController : Controller
    {
        private readonly IRepository _repository;

        public ToDoController(IRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View(null);
        }

        public IActionResult Populate()
        {
            //int recordsAdded = DatabasePopulator.PopulateDatabase(_repository);
            return Ok();
        }
    }
}
