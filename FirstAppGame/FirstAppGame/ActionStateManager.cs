using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAppGame
{
    public class ActionStateManager
    {
        StatsCalculators statsCalculators;

        private Creature tijdelijkeCreature { get; set; } = new Creature()
        {
            Name = " Simon",
            Hunger = 100.0f,
            Thirst = 100.0f,
            Bored = 100.0f,
            Lonely = 100.0f,
            OverStimulated = 100.0f,
            Sleepy = 100.0f,
            Money = 1000.0f

        };
        public ActionStateManager()
        {
            CurrentState = PlayerAction.Nothing;
            statsCalculators = new StatsCalculators();

            //Events Listenactions
            MainPage.OnGamingEvent += Gaming;
            LivingRoom.OnEatEvent += Eating;
            ChillRoom.OnGamingEvent += Gaming;
            BedRoom.OnSleepEvent += Sleeping;
            Corridor.OnWorkEvent += Working;
        }


        //public static ActionStateManager actionStateManager;
        public enum PlayerAction { Nothing, Working, Sleeping, Gaming, Eating/*, LogedOut, LogedIn */};

        public PlayerAction CurrentState;

        public void UpdateStats()
        {

            switch (CurrentState)
            {

                case PlayerAction.Nothing: Nothing(); break;
                case PlayerAction.Working: Working(); break;
                case PlayerAction.Sleeping: Sleeping(); break;
                case PlayerAction.Gaming: Gaming(); break;
                case PlayerAction.Eating: Eating(); break;

            }

            string _creatureStatsString = JsonConvert.SerializeObject(tijdelijkeCreature);
            Console.WriteLine(_creatureStatsString);
        }

        public PlayerAction CurrentPlayerAction()
        {
            return CurrentState;
        }

        private void Nothing()
        {
            CurrentState = PlayerAction.Nothing;

            tijdelijkeCreature.Hunger =statsCalculators.DecreaseHungerAndThirst(tijdelijkeCreature.Hunger);
            tijdelijkeCreature.Thirst = statsCalculators.DecreaseHungerAndThirst(tijdelijkeCreature.Thirst);
            tijdelijkeCreature.Sleepy = statsCalculators.DecreaseEnergy(tijdelijkeCreature.Sleepy);
            tijdelijkeCreature.Money = statsCalculators.DecreaseMoney(CurrentState, tijdelijkeCreature.Money);
            tijdelijkeCreature.Bored = statsCalculators.DecreaseBoredNess(tijdelijkeCreature.Bored);
            tijdelijkeCreature.OverStimulated = statsCalculators.DecreaseOverstimulation(CurrentState, tijdelijkeCreature.OverStimulated);
        }

        private void Working()
        {
            CurrentState = PlayerAction.Working;

            tijdelijkeCreature.Hunger = statsCalculators.DecreaseHungerAndThirst(tijdelijkeCreature.Hunger);
            tijdelijkeCreature.Thirst = statsCalculators.DecreaseHungerAndThirst(tijdelijkeCreature.Thirst);
            tijdelijkeCreature.Sleepy = statsCalculators.DecreaseEnergy(tijdelijkeCreature.Sleepy);
            tijdelijkeCreature.Money = statsCalculators.IncreaseMoney(tijdelijkeCreature.Money);
            tijdelijkeCreature.Bored = statsCalculators.IncreaseBoredNess(tijdelijkeCreature.Bored);
            tijdelijkeCreature.OverStimulated = statsCalculators.IncreaseOverstimulation(tijdelijkeCreature.OverStimulated);
        }

        private void Sleeping()
        {
            CurrentState = PlayerAction.Sleeping;

            tijdelijkeCreature.Hunger = statsCalculators.DecreaseHungerAndThirst(tijdelijkeCreature.Hunger);
            tijdelijkeCreature.Thirst = statsCalculators.DecreaseHungerAndThirst(tijdelijkeCreature.Thirst);
            tijdelijkeCreature.Sleepy = statsCalculators.IncreaseEnergy(tijdelijkeCreature.Sleepy);
            tijdelijkeCreature.Money = statsCalculators.DecreaseMoney(CurrentState, tijdelijkeCreature.Money);
            tijdelijkeCreature.OverStimulated = statsCalculators.DecreaseOverstimulation(CurrentState, tijdelijkeCreature.OverStimulated);


        }
        private void Gaming()
        {
            CurrentState = PlayerAction.Gaming;

            tijdelijkeCreature.Hunger = statsCalculators.DecreaseHungerAndThirst(tijdelijkeCreature.Hunger);
            tijdelijkeCreature.Thirst = statsCalculators.DecreaseHungerAndThirst(tijdelijkeCreature.Thirst);
            tijdelijkeCreature.Sleepy = statsCalculators.DecreaseEnergy(tijdelijkeCreature.Sleepy);
            tijdelijkeCreature.Money = statsCalculators.DecreaseMoney(CurrentState, tijdelijkeCreature.Money);
            tijdelijkeCreature.Bored = statsCalculators.DecreaseBoredNess(tijdelijkeCreature.Bored);
            tijdelijkeCreature.OverStimulated = statsCalculators.DecreaseOverstimulation(CurrentState, tijdelijkeCreature.OverStimulated);


        }
        private void Eating()
        {
            CurrentState = PlayerAction.Eating;

            tijdelijkeCreature.Hunger = statsCalculators.IncreaseHungerAndThirst(tijdelijkeCreature.Hunger);
            tijdelijkeCreature.Thirst = statsCalculators.IncreaseHungerAndThirst(tijdelijkeCreature.Thirst);
            tijdelijkeCreature.Sleepy = statsCalculators.DecreaseEnergy(tijdelijkeCreature.Sleepy);
            tijdelijkeCreature.Money = statsCalculators.DecreaseMoney(CurrentState, tijdelijkeCreature.Money);

        }

    }
}
