using Microsoft.AspNetCore.Mvc;

namespace USAApi.Controllers
{
    [Route("/")]
    [ApiController] //this attribute let's asp.net core know that I am building a controller meant for an API. This adds features like automated model validation.
    public class RootController : ControllerBase
    {
        [HttpGet(Name = nameof(GetRoot))] // this explicitly tells asp.net core that it should handle the GET Verb
        public IActionResult GetRoot()
        {
            var response = new
            {
                href = Url.Link(nameof(GetRoot), null),
                rooms = new
                {
                    href = Url.Link(nameof(RoomsController.GetRooms), null)
                }
            };
            return Ok(response);
        }
    }
}
