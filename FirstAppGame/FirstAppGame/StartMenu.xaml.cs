using Newtonsoft.Json;
using System.Threading;

namespace FirstAppGame;

public partial class StartMenu : ContentPage
{
    private ActionStateManager actionStateManager = DependencyService.Get<ActionStateManager>();
    private IDataStore<Creature> creatureDataStore = DependencyService.Get<IDataStore<Creature>>();

    private Creature MyCreature;

    public StartMenu()
    {
        //Creature item = new Creature();
        //item.Hunger = 76.0f;
        //string creatureString = JsonConvert.SerializeObject(item);
        //Preferences.Set("Test", creatureString);

        //Console.WriteLine(Preferences.Get("Test", ""));
        //string JsonDe = Preferences.Get("Test", "");


        //MyCreature = JsonConvert.DeserializeObject<Creature>(JsonDe);
        //Console.WriteLine(MyCreature.Hunger);




        InitializeComponent();
        CheckCreatureData();
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
        creatureDataStore.UpdateItem(MyCreature);

        MyCreature = creatureDataStore.ReadItem();
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
    }



}