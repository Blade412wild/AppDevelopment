using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FirstAppGame.ActionStateManager;

namespace FirstAppGame
{
    //Timer
    //ActionStateManafer

    class GameManager
    {

        //Timer
        //private  ActionStateManager actionManager = new ActionStateManager();
        //private  RoomManager roomManager = new RoomManager();

        private PlayerAction currentState;

        public void GameFlow()
        {
            //actionManager.UpdateStats();
            //currentState = CheckActionState();
            
        }

        //private PlayerAction CheckActionState()
        //{
        //    PlayerAction _currentState;
        //    _currentState = actionManager.CurrentState;
        //    return _currentState;
        //}
    }
}
