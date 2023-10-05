using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAppGame
{
    internal class PastTimeDataStore : IDataStore<OwnTime>
    {
        public bool CreateItem(OwnTime item)
        {
            if (Preferences.ContainsKey("MyLastTime"))
            {
                return false;
            }

            string timeString = JsonConvert.SerializeObject(item);
            Preferences.Set("MyLastTime", timeString);
            return Preferences.ContainsKey("MyLastTime");
        }


        public OwnTime ReadItem()
        {
            string timeString = Preferences.Get("MyLastTime", "");
            OwnTime lastTime = JsonConvert.DeserializeObject<OwnTime>(timeString);

            return lastTime;
        }

        public bool UpdateItem(OwnTime item)
        {
            string timeJsonText = JsonConvert.SerializeObject(item);
            Preferences.Set("MyLastTime", timeJsonText);


            return true;
        }
        public bool DeleteItem(OwnTime item)
        {
            Preferences.Default.Remove("MyCreature");
            return true;
        }
    }
}
