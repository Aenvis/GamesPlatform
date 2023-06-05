using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesPlatform.Domain.Models
{
    public class Localization
    {
        public string Country { get; protected set; }
        public string Region { get; protected set; }
        public string City { get; protected set; }

        public Localization(string country, string region, string city)
        {
            Country = country;
            Region = region;
            City = city;
        }
    }
}