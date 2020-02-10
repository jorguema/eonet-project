using System;
using System.Collections.Generic;

namespace Eonet.Services.Dtos
{
    public class EventDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public DateTime? Closed { get; set; }
        public EventStatus Status => Closed.HasValue? EventStatus.Closed: EventStatus.Open;
        public List<CategoryDto> Categories { get; set; }
    }
}
