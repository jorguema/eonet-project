using System;

namespace Eonet.Services.Dtos
{
    public class QueryOptions
    {
        public int Limit { get; set; } = 50;
        public int Days { get; set; } = 365;
        public EventStatus Status { get; set; } = EventStatus.All;
        public DateTime? Date { get; set; }
        public string Category { get; set; }
        public OrderByPropertyType OrderByProperty { get; set; }
        public OrderType OrderType { get; set; } = OrderType.Asc;
    }
}
