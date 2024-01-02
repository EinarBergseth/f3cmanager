using DataAccess.Models;

namespace F3CManager.Services
{
    public interface IEventServices
    {
        Task<List<Event>> GetEvents();
    }
}