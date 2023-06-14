using June12Homework.Data;
using June12Homework.Web.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace June12Homework.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly string _connectionString;
        public PeopleController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConStr");
        }

        [HttpGet]
        [Route("getallpeople")]
        public List<Person> GetAll()
        {
            var repo = new PersonRepository(_connectionString);
            return repo.GetPeople();
        }

        [HttpPost]
        [Route("deleteallpeople")]
        public void DeleteAllPeople()
        {
            var repo = new PersonRepository(_connectionString);
            repo.DeleteAll();
        }

        [HttpGet]
        [Route("generate")]
        public IActionResult GeneratePeople(int amount)
        {
            var people = StaticPersonsClass.Generate(amount);
            string csv = StaticPersonsClass.BuildPeopleCsv(people);
            return File(Encoding.UTF8.GetBytes(csv), "text/csv", "people.csv");
        }
        [HttpPost]
        [Route("upload")]
        public void Upload(UploadViewModel viewModel)
        {
            string base64 = viewModel.Base64.Substring(viewModel.Base64.IndexOf(",") + 1);
            byte[] imageBytes = Convert.FromBase64String(base64);
            var people = StaticPersonsClass.GetCsvFromBytes(imageBytes);
            var repo = new PersonRepository(_connectionString);
            repo.AddPeople(people);
        }
    }
}
