using Microsoft.AspNetCore.Mvc;

namespace VarApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DetailingController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetTodoItems()
        {
            return default;
        }

    }
}
