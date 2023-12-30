using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace F3CManager.AddControllers
{
    /// <summary>
    /// Manouvers.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("/api/manouvers")]
    public class ManouverController : Controller
    {

        /// <summary>
        /// Get all manouvers.
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<string>> GetManouvers()
        {
            return Ok("[{\"id\": \"123\", \"name\": \"loop1\", \"factor\": 1.5}]");
        }
    }
}