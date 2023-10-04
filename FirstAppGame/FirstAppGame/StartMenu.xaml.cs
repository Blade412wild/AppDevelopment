
namespace FirstAppGame;

public partial class StartMenu : ContentPage
{
    public delegate void StartGameEvent(float _pastTime);
    public static event StartGameEvent OnOpenGameEvent;

    private ActionStateManager actionStateManager = DependencyService.Get<ActionStateManager>();
    private IDataStore<Creature> creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
    private IDataStore<OwnTime> pastTimeDataStore = DependencyService.Get<IDataStore<OwnTime>>();


    private Creature MyCreature;
    private OwnTime ownTime;

    public StartMenu()
    {
        InitializeComponent();
        CheckCreatureData();
        OfflineTime();
        Timer();
    }

    private void OnImageButtonClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Corridor());
    }

    private void CheckCreatureData()
    {
        //creatureDataStore.DeleteItem(MyCreature);
        MyCreature = creatureDataStore.ReadItem();


        if (MyCreature == null)
        {
            Console.WriteLine("MyCreature was null");
            MyCreature = new Creature
            {
                Name = " Ezra",
                Hunger = 100.0f,
                Thirst = 100.0f,
                Bored = 100.0f,
                Lonely = 100.0f,
                OverStimulated = 100.0f,
                Sleepy = 100.0f,
                Money = 800.0f
            };

            creatureDataStore.CreateItem(MyCreature);
        }

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

    private void OfflineTime()
    {

        ownTime = pastTimeDataStore.ReadItem();

        if (ownTime == null)
        {
            ownTime = new OwnTime
            {
                LastTime = DateTime.Now,
            };

            pastTimeDataStore.CreateItem(ownTime);
        }

        DateTime previousTime = ownTime.LastTime;
        DateTime nowTime = DateTime.Now;

        TimeSpan elapsedTime = nowTime - previousTime;

        ownTime.LastTime = nowTime;
        ownTime.ElapsedTimeSeconds = elapsedTime.Seconds;

        OnOpenGameEvent?.Invoke(elapsedTime.Seconds);

        pastTimeDataStore.UpdateItem(ownTime);
        Console.WriteLine("LastTime = " + previousTime);
        Console.WriteLine("now Time = " + nowTime);
        Console.WriteLine("PastTime in seconds = " + elapsedTime.Seconds);

        //return elapsedTime.Seconds;
    }
    private  void UpdateOfflineTime()
    {
        DateTime nowTime = DateTime.Now;
        ownTime.LastTime = nowTime;
        pastTimeDataStore.UpdateItem(ownTime);

    }

    private void TimerElapsed(object sender, EventArgs e)
    {
        actionStateManager.UpdateStats();
        UpdateOfflineTime();
    }



}