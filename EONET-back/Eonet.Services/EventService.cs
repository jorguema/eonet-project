using Eonet.Services.Dtos;
using Eonet.Services.Helpers;
using Eonet.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Eonet.Services
{
    public class EventService : IEventService
    {
        public async Task<List<EventDto>> FindAsync(QueryOptions queryOptions)
        {
            using (var httpClient = new HttpClient())
            {
                var httpResponse = await httpClient.GetAsync(EonetUrlHelper.FindEvents(queryOptions));

                if (!httpResponse.IsSuccessStatusCode)
                {
                    throw new Exception("Cannot retrieve events");
                }

                var content = await httpResponse.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<EventResponse>(content);

                var events = FilterByDate(response.Events, queryOptions);
                return SortEvents(events, queryOptions);
            }
        }

        public async Task<EventDto> FindById(string eventId)
        {
            using (var httpClient = new HttpClient())
            {
                var httpResponse = await httpClient.GetAsync(EonetUrlHelper.EventsById(eventId));

                if (!httpResponse.IsSuccessStatusCode)
                {
                    throw new Exception("Cannot retrieve event detail");
                }

                var content = await httpResponse.Content.ReadAsStringAsync();
                var eventDto = JsonConvert.DeserializeObject<EventDto>(content);

                return eventDto;
            }
        }

        private List<EventDto> SortEvents(List<EventDto> events, QueryOptions queryOptions)
        {
            if (queryOptions.OrderByProperty == OrderByPropertyType.Undefined) return events;
            var orderType = queryOptions.OrderType;
            var sortedEvents = events;

            if(queryOptions.OrderByProperty == OrderByPropertyType.Closed)
            {
                if (orderType == OrderType.Asc) sortedEvents = events.OrderBy(ev => ev.Closed).ToList();
                else sortedEvents = events.OrderByDescending(ev => ev.Closed).ToList();
            }

            return sortedEvents;
        }

        private List<EventDto> FilterByDate(List<EventDto> events, QueryOptions queryOptions)
        {
            if (!queryOptions.Date.HasValue) return events;

            events = events.Where(ev => ev.Closed.Value.Date == queryOptions.Date.Value.Date).ToList();
            return events;
        }
    }
}
