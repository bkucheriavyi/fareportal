using System.IO;
using System.Linq;
using FPT.Business.Services.Model;
using Newtonsoft.Json;

namespace FPT.Business.Repositories
{
    public class DefaultBeveragesRepository : IBarRepository<Beverage>
    {
        private readonly RootObject _root;

        public DefaultBeveragesRepository()
        {
            using (var r = new StreamReader("Resources/data.json"))
            {
                string json = r.ReadToEnd();
                _root = JsonConvert.DeserializeObject<RootObject>(json);
            }
        }

        public Beverage[] Get(int[] ids)
        {
            return ids.Select(id => _root.Beverages.FirstOrDefault(b => b.Id == id))
                                                   .Where(b => b != null)
                                                   .ToArray();
        }

        private class RootObject
        {
            public Beverage[] Beverages { get; set; }
        }
    }
}
