using System;

namespace TaxiHandler.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public string InitialAmount { get; set; }
        public string NumberOfPeople { get; set; }
        public string Change { get; set; }
    }
}