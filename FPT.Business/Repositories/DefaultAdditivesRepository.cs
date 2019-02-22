using System.IO;
using System.Linq;
using FPT.Business.Services.Model;
using Newtonsoft.Json;

namespace FPT.Business.Repositories
{
    public class DefaultAdditivesRepository : IBarRepository<Additive>
    {
        private readonly RootObject _root;

        public DefaultAdditivesRepository()
        {
            using (var r = new StreamReader("Resources/data.json"))
            {
                string json = r.ReadToEnd();
                _root = JsonConvert.DeserializeObject<RootObject>(json);
            }
        }

        public Additive[] Get(int[] ids)
        {
            return ids.Select(id => _root.Additives.FirstOrDefault(b => b.Id == id))
                                                   .Where(b => b != null)
                                                   .ToArray();
        }

        private class RootObject
        {
            public Additive[] Additives { get; set; }
        }
    }
}
