using DataAccess;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace F3CManager.Services
{
    public class EventServices : IEventServices
    {
        DataContext _dataContext;

        public EventServices(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Event>> GetEvents()
        {
            var eventDTOs = await _dataContext.Events.ToListAsync();
            return eventDTOs;
        }
    }
}