using Eonet.Services.Dtos;
using System;

namespace Eonet.Services.Helpers
{
    public static class EonetUrlHelper
    {
        public const string baseUrl = "https://eonet.sci.gsfc.nasa.gov/api/v2.1/{0}";
        private const string eventEndpoint = "events";

        public static string EventsById(string eventId)
        {
            var url = SetDomainEndpoint(eventEndpoint);
            return url + "/" + eventId;
        }

        public static string FindEvents(QueryOptions queryOptions)
        {
            var url = SetDomainEndpoint(eventEndpoint);
            if (queryOptions == null) return baseUrl;

            url = url + "/?limit=" + queryOptions.Limit;
            url = url + "&days=" + queryOptions.Days;
            if (queryOptions.Date.HasValue || queryOptions.OrderByProperty == OrderByPropertyType.Closed)
            {
                return url + "&status=" + Enum.GetName(typeof(EventStatus),EventStatus.Closed).ToLower();
            }

            if (queryOptions.Status == EventStatus.Open) url = url + "&status=" + Enum.GetName(typeof(EventStatus), EventStatus.Open).ToLower();
            if (queryOptions.Status == EventStatus.Closed) url = url + "&status=" + Enum.GetName(typeof(EventStatus), EventStatus.Closed).ToLower();
            return url;
        }

        private static string SetDomainEndpoint(string domainEndpoint) => string.Format(baseUrl, domainEndpoint);
    }
}
