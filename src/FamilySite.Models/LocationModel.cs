﻿namespace FamilySite.Models
{
    public class LocationModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string GoogleMapPlaceId { get; set; }
    }
}
