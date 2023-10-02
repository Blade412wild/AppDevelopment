using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAppGame
{
    class RoomManager : ContentPage
    {
        private ActionStateManager actionStateManager;
        private int room;

        public RoomManager(ActionStateManager _actionStateManager)
        {
            actionStateManager = _actionStateManager;
            MainPage.RoomButtonIsPressed += RoomSaver;
            AddListenersToEvent();
        }

        private void RoomSaver(int _room)
        {
            Console.WriteLine("RoomSaver Is Activated");

            room = _room;
            Console.WriteLine("RoomID = " + room);

            RoomDecider(actionStateManager.CurrentState);
            Console.WriteLine("CurrentAction = " + actionStateManager.CurrentState);

        }

        private void RoomDecider(ActionStateManager.PlayerAction _currentPlayerAction)
        {
            switch (room)
            {
                //case 0: Navigation.PushAsync(new StartMenu()); break;
                case 0: ChangeToCorridor(_currentPlayerAction); break;
                case 1: ChangeToLivingRoom(_currentPlayerAction); break;
                case 2: ChangeToChillRoom(_currentPlayerAction); break;
                case 3: ChangeToBedRoom(_currentPlayerAction); break;
            }
        }

        private void ChangeToCorridor(ActionStateManager.PlayerAction _currentPlayerAction)
        {
            if (_currentPlayerAction == ActionStateManager.PlayerAction.Working)
            {
                Console.WriteLine("Changed To CorridorP");
                Navigation.PushAsync(new CorridorP());
            }
            else
            {
                Console.WriteLine("Changed To Corridor");
                Navigation.PushAsync(new Corridor());
            }
        }
        private void ChangeToLivingRoom(ActionStateManager.PlayerAction _currentPlayerAction)
        {
            if (_currentPlayerAction == ActionStateManager.PlayerAction.Eating)
            {
                Navigation.PushAsync(new LivingRoomP());
            }
            else
            {
                Navigation.PushAsync(new LivingRoom());
            }
        }
        private void ChangeToChillRoom(ActionStateManager.PlayerAction _currentPlayerAction)
        {
            if (_currentPlayerAction == ActionStateManager.PlayerAction.Gaming)
            {
                Navigation.PushAsync(new ChillRoomP());
            }
            else
            {
                Navigation.PushAsync(new ChillRoom());
            }
        }
        private void ChangeToBedRoom(ActionStateManager.PlayerAction _currentPlayerAction)
        {
            if (_currentPlayerAction == ActionStateManager.PlayerAction.Sleeping)
            {
                Navigation.PushAsync(new BedRoomP());
            }
            else
            {
                Navigation.PushAsync(new BedRoom());
            }
        }

        private void AddListenersToEvent()
        {
            MainPage.RoomButtonIsPressed += RoomSaver;
            Corridor.RoomButtonIsPressed += RoomSaver;
            CorridorP.RoomButtonIsPressed += RoomSaver;
            LivingRoom.RoomButtonIsPressed += RoomSaver;
            LivingRoomP.RoomButtonIsPressed += RoomSaver;
            ChillRoom.RoomButtonIsPressed += RoomSaver;
            ChillRoomP.RoomButtonIsPressed += RoomSaver;
            BedRoom.RoomButtonIsPressed += RoomSaver;
            BedRoomP.RoomButtonIsPressed += RoomSaver;

        }
    }
}
