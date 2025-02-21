using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySwagger.Model;

namespace MySwagger.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MyController : ControllerBase
    {
        [HttpPost, Route("MyPost")]
        public ActionResult MyPost(Student student)
        {
            return Ok("Hello MyPost " + student.Name);
        }

        [HttpPut, Route("MyPut")]
        public ActionResult MyPut()
        {
            return Ok("Hello MyPut");
        }

        [HttpGet, Route("MyGet/{id}")]
        public ActionResult MyGet(string id)
        {
            return Ok("Hello MyGet " + id);
        }

    }
}
