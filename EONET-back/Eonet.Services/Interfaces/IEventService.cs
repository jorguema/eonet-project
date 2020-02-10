using Eonet.Services.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eonet.Services.Interfaces
{
    public interface IEventService
    {
        Task<List<EventDto>> FindAsync(QueryOptions queryOptions);
        Task<EventDto> FindById(string eventId);
    }
}
