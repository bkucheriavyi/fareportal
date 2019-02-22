using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FPT.Business.Services.Model
{
    public class Beverage
    {
        public Beverage()
        {
            Additives = new List<Additive>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public AdditiveGroup Group {get; set;}

        public List<Additive> Additives { get; set; }
    }
}