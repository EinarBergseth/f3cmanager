using F3CManager.Models.DTOs;
using F3CManager.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace F3CManager.Controllers
{
    /// <summary>
    /// Events.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("/api/events")]
    public class EventController : Controller
    {
        private readonly IEventServices _eventServices;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="eventServices"></param>
        public EventController(IEventServices eventServices)
        {
            _eventServices = eventServices;
        }

        /// <summary>
        /// Get all events for current user.
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<List<EventDTO>>> GetEvents()
        {
            //TODO
            var events = await _eventServices.GetEvents();
            return Ok(events);

            // if (User.Identity == null || !User.Identity.IsAuthenticated)
            // {
            //     return Ok(new List<EventDTO>());
            // }
            // return Ok(new List<EventDTO>());
        }

        [HttpPost]
        public async Task<ActionResult<EventDTO>> CreateEvent(EventDTO eventDTO)
        {
            //TODO
            return Ok(eventDTO);
        }

        [HttpPut]
        public async Task<ActionResult<EventDTO>> UpdateEvent(EventDTO eventDTO)
        {
            //TODO
            return Ok(eventDTO);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteEvent(Guid eventId)
        {
            //TODO
            return Ok();
        }
    }
}