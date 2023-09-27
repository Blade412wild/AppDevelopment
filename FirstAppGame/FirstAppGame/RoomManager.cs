using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAppGame
{
    class RoomManager: ContentPage
    {
        private int room;

        public delegate void RoomSwitchButton(int amount);
        public static event RoomSwitchButton RoomButtonIsPressed; 
        public RoomManager()
        {
            RoomButtonIsPressed += RoomDecider;
            RoomButtonIsPressed.Invoke(1);
        }
        
        private void RoomDecider(int amount)
        {
            room = room + amount;

            if(room == -1)
            {
                room = 3;
            }

            switch (room)
            {
                case 0: Navigation.PushAsync(new Corridor()); break;
                case 1: Navigation.PushAsync(new LivingRoom()); break;
                case 2: Navigation.PushAsync(new ChillRoom()); break;
                case 3: Navigation.PushAsync(new BedRoom()); break;

            }
        }
    }
}
