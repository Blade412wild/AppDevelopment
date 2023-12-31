﻿using System.ComponentModel;
using System.Timers;

namespace FirstAppGame;

public partial class MainPage : ContentPage, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    //public delegate void ButtonPressed(PlayerAction Action);
    public delegate void ButtonPressed();
    public static event ButtonPressed OnGamingEvent;

    public delegate void RoomSwitchButton(int _room);
    public static event RoomSwitchButton RoomButtonIsPressed;
    public Creature MyCreature { get; set; } = new Creature
    {
        Name = " Simon",
        Hunger = 100.0f,
        Thirst = 100.0f,
        Bored = 100.0f,
        Lonely = 100.0f,
        OverStimulated = 100.0f,
        Sleepy = 100.0f,
        Money = 0.0f

    };

    private ActionStateManager actionStateManager = DependencyService.Get<ActionStateManager>();


    public MainPage()
    {
        Timer();

        BindingContext = this;

        InitializeComponent();

        //var dataStore = new CreatureDataStore();
        //MyCreature = dataStore.ReadItem();\
        var _creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
        //roomManager = new RoomManager2(actionStateManager);


        MyCreature = _creatureDataStore.ReadItem();
        //RoomButtonIsPressed += RoomDecider;



        //if (MyCreature == null)
        //{
        //    new Creature
        //    {
        //        Name = " Ezra",
        //        Hunger = 100.0f,
        //        Thirst = 100.0f,
        //        Bored = 100.0f,
        //        Lonely = 100.0f,
        //        OverStimulated = 100.0f,
        //        Sleepy = 100.0f,
        //        Money = 0.0f
        //    };
        //    //dataStore.CreateItem(MyCreature);
        //    _creatureDataStore.CreateItem(MyCreature);
        //    MyCreature = _creatureDataStore.ReadItem();
        //    Console.WriteLine("MyCreature was null");

        //}
        //else
        //{
        //    Console.WriteLine("MyCreature was niet null");
        //    _creatureDataStore.UpdateItem(MyCreature);
        //}



    }
    private void NextPageClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NewPage1());
    }

    private void StatsPageClicked(object sender, EventArgs e)
    {

    }

    private void OnNextRoomClicked(object sender, EventArgs e)
    {

        if (actionStateManager.CurrentState == ActionStateManager.PlayerAction.Working)
        {
            Console.WriteLine("Changed To CorridorP");
            Navigation.PushAsync(new CorridorP());
        }
        else
        {
            Console.WriteLine("Changed To Corridor");
            Navigation.PushAsync(new StartMenu());
        }
    }
    private void OnPreviousRoomClicked(object sender, EventArgs e)
    {
        RoomButtonIsPressed?.Invoke(3);
    }

    private void Timer()
    {
        var timer = new System.Timers.Timer()
        {
            Interval = 1000,
            AutoReset = true
        };

        timer.Elapsed += TimerElapsed;
        timer.Start();
    }

    private void TimerElapsed(object sender, EventArgs e)
    {
        actionStateManager.UpdateStats();
        Console.WriteLine("1 second yes :)");
    }

}

