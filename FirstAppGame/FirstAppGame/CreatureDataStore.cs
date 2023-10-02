using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace FirstAppGame
{
    public class CreatureDataStore : IDataStore<Creature>
    {
        public string NameTest = "TestTest";

        public bool CreateItem(Creature item)
        {
            if (Preferences.ContainsKey("MyCreature"))
            {
                return false;
            }

            string creatureString = JsonConvert.SerializeObject(item);
            Preferences.Set("MyCreature", creatureString);
            return Preferences.ContainsKey("MyCreature");
        }

        public Creature ReadItem()
        {
            string creatureString = Preferences.Get("MyCreature","");
            Creature creature = JsonConvert.DeserializeObject<Creature>(creatureString);

            return creature;
        }

        public bool UpdateItem(Creature item)
        {
            if (Preferences.ContainsKey("MyCreature"))
            {
                return false;
            }

            string creatureJsonText = JsonConvert.SerializeObject(item);
            Preferences.Set("MyCreature", creatureJsonText);

            return true;

        }
        public bool DeleteItem(Creature item)
        {
            throw new NotImplementedException();
        }
    }
}
