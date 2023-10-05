using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAppGame
{
    public class Creature : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Name { get; set; }
        public float Hunger { get; set; }
        public float Thirst { get; set; }
        public float Sleepy { get; set; }
        public float Bored { get; set; }
        public float Lonely { get; set; }
        public float OverStimulated { get; set; }
        public float Money { get; set; }
        public ActionStateManager.PlayerAction PlayerAction { get; set; }

    }




}
