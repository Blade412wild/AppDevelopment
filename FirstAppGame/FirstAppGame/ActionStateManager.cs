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
        //public static ActionStateManager actionStateManager;
        public enum PlayerAction { Nothing, Working, Sleeping, Gaming, Eating};

        public PlayerAction CurrentState;

        private Creature tijdelijkeCreature;
        private IDataStore<Creature> creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
        private IDataStore<OwnTime> pastTimeDataStore = DependencyService.Get<IDataStore<OwnTime>>();
        private float timePast = 1.0f;
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
            StartMenu.OnOpenGameEvent += StartAppStatsUpdate;
        }

        private StatsCalculators statsCalculators;

        
        public void UpdateStats()
        {
            tijdelijkeCreature = creatureDataStore.ReadItem();

            switch (CurrentState)
            {

                case PlayerAction.Nothing: Nothing(); break;
                case PlayerAction.Working: Working(); break;
                case PlayerAction.Sleeping: Sleeping(); break;
                case PlayerAction.Gaming: Gaming(); break;
                case PlayerAction.Eating: Eating(); break;

            }

            creatureDataStore.UpdateItem(tijdelijkeCreature);

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

            tijdelijkeCreature.Hunger = statsCalculators.DecreaseHungerAndThirst(tijdelijkeCreature.Hunger, timePast) ;
            tijdelijkeCreature.Thirst = statsCalculators.DecreaseHungerAndThirst(tijdelijkeCreature.Thirst, timePast);
            tijdelijkeCreature.Sleepy = statsCalculators.DecreaseEnergy(tijdelijkeCreature.Sleepy, timePast);
            tijdelijkeCreature.Money = statsCalculators.DecreaseMoney(CurrentState, tijdelijkeCreature.Money, timePast);
            tijdelijkeCreature.Bored = statsCalculators.DecreaseBoredNess(tijdelijkeCreature.Bored, timePast);
            tijdelijkeCreature.OverStimulated = statsCalculators.DecreaseOverstimulation(CurrentState, tijdelijkeCreature.OverStimulated, timePast);
            tijdelijkeCreature.Lonely = statsCalculators.DecreaseLonely(tijdelijkeCreature.Lonely, timePast);


        }

        private void Working()
        {
            CurrentState = PlayerAction.Working;

            tijdelijkeCreature.Hunger = statsCalculators.DecreaseHungerAndThirst(tijdelijkeCreature.Hunger, timePast);
            tijdelijkeCreature.Thirst = statsCalculators.DecreaseHungerAndThirst(tijdelijkeCreature.Thirst, timePast);
            tijdelijkeCreature.Sleepy = statsCalculators.DecreaseEnergy(tijdelijkeCreature.Sleepy, timePast);
            tijdelijkeCreature.Money = statsCalculators.IncreaseMoney(tijdelijkeCreature.Money, timePast);
            tijdelijkeCreature.Bored = statsCalculators.IncreaseBoredNess(tijdelijkeCreature.Bored, timePast);
            tijdelijkeCreature.OverStimulated = statsCalculators.IncreaseOverstimulation(tijdelijkeCreature.OverStimulated, timePast);
        }

        private void Sleeping()
        {
            CurrentState = PlayerAction.Sleeping;

            tijdelijkeCreature.Hunger = statsCalculators.DecreaseHungerAndThirst(tijdelijkeCreature.Hunger, timePast);
            tijdelijkeCreature.Thirst = statsCalculators.DecreaseHungerAndThirst(tijdelijkeCreature.Thirst, timePast);
            tijdelijkeCreature.Sleepy = statsCalculators.IncreaseEnergy(tijdelijkeCreature.Sleepy, timePast);
            tijdelijkeCreature.Money = statsCalculators.DecreaseMoney(CurrentState, tijdelijkeCreature.Money, timePast);
            tijdelijkeCreature.OverStimulated = statsCalculators.DecreaseOverstimulation(CurrentState, tijdelijkeCreature.OverStimulated, timePast);
            tijdelijkeCreature.Lonely = statsCalculators.DecreaseLonely(tijdelijkeCreature.Lonely, timePast);


        }
        private void Gaming()
        {
            CurrentState = PlayerAction.Gaming;

            tijdelijkeCreature.Hunger = statsCalculators.DecreaseHungerAndThirst(tijdelijkeCreature.Hunger, timePast);
            tijdelijkeCreature.Thirst = statsCalculators.DecreaseHungerAndThirst(tijdelijkeCreature.Thirst, timePast);
            tijdelijkeCreature.Sleepy = statsCalculators.DecreaseEnergy(tijdelijkeCreature.Sleepy, timePast);
            tijdelijkeCreature.Money = statsCalculators.DecreaseMoney(CurrentState, tijdelijkeCreature.Money, timePast);
            tijdelijkeCreature.Bored = statsCalculators.DecreaseBoredNess(tijdelijkeCreature.Bored, timePast);
            tijdelijkeCreature.OverStimulated = statsCalculators.DecreaseOverstimulation(CurrentState, tijdelijkeCreature.OverStimulated, timePast);
            tijdelijkeCreature.Lonely = statsCalculators.DecreaseLonely(tijdelijkeCreature.Lonely, timePast);


        }
        private void Eating()
        {
            CurrentState = PlayerAction.Eating;

            tijdelijkeCreature.Hunger = statsCalculators.IncreaseHungerAndThirst(tijdelijkeCreature.Hunger, timePast);
            tijdelijkeCreature.Thirst = statsCalculators.IncreaseHungerAndThirst(tijdelijkeCreature.Thirst, timePast);
            tijdelijkeCreature.Sleepy = statsCalculators.DecreaseEnergy(tijdelijkeCreature.Sleepy, timePast);
            tijdelijkeCreature.Money = statsCalculators.DecreaseMoney(CurrentState, tijdelijkeCreature.Money, timePast);
            tijdelijkeCreature.Lonely = statsCalculators.DecreaseLonely(tijdelijkeCreature.Lonely, timePast);


        }

        private void StartAppStatsUpdate(float _timePast)
        {
            tijdelijkeCreature = creatureDataStore.ReadItem();

            tijdelijkeCreature.Hunger = statsCalculators.DecreaseHungerAndThirst(tijdelijkeCreature.Hunger, _timePast);
            tijdelijkeCreature.Thirst = statsCalculators.DecreaseHungerAndThirst(tijdelijkeCreature.Thirst, _timePast);
            tijdelijkeCreature.Sleepy = statsCalculators.DecreaseEnergy(tijdelijkeCreature.Sleepy, _timePast);
            tijdelijkeCreature.Money = statsCalculators.DecreaseMoney(CurrentState, tijdelijkeCreature.Money, _timePast);
            tijdelijkeCreature.Bored = statsCalculators.IncreaseBoredNess(tijdelijkeCreature.Bored, _timePast);
            tijdelijkeCreature.Lonely = statsCalculators.IncreaseLonely(tijdelijkeCreature.Lonely, _timePast);

            creatureDataStore.UpdateItem(tijdelijkeCreature);

        }

    }
}
