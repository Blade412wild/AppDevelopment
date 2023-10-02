namespace FirstAppGame;

public partial class StartMenu : ContentPage
{
    public Creature MyCreature { get; set; }/* = new Creature*/
    //{
    //	Name = " Simon",
    //	Hunger = 100.0f,
    //	Thirst = 100.0f,
    //	Bored = 100.0f,
    //	Lonely = 100.0f,
    //	OverStimulated = 100.0f,
    //	Sleepy = 100.0f,
    //	Money = 0.0f

    //};

    private Timer timer = new Timer();
    private ActionStateManager actionStateManager = DependencyService.Get<ActionStateManager>();
    private IDataStore<Creature> creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
    public StartMenu()
    {
        InitializeComponent();

        CheckCreatureData();
    }

    private void OnImageButtonClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Corridor());
    }

    private void CheckCreatureData()
    {
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
                Money = 0.0f
            };

            creatureDataStore.CreateItem(MyCreature);
            creatureDataStore.UpdateItem(MyCreature);
            MyCreature = creatureDataStore.ReadItem();



        }
        else
        {
            Console.WriteLine("MyCreature was niet null");
            creatureDataStore.UpdateItem(MyCreature);
            Creature _testDataStore = creatureDataStore.ReadItem();
            Console.WriteLine(" StartMenu Monster name = " +  _testDataStore.Name);
        }
    }
}