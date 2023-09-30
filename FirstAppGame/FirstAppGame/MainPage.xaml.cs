using Newtonsoft.Json;
using System.ComponentModel;
using static FirstAppGame.ActionStateManager;

namespace FirstAppGame;

public partial class MainPage : ContentPage, INotifyPropertyChanged
{
	public event PropertyChangedEventHandler PropertyChanged;

    //public delegate void ButtonPressed(PlayerAction Action);
    public delegate void ButtonPressed();
    public static event ButtonPressed OnGamingEvent;
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

    private ActionStateManager actionManager = new ActionStateManager();


	public MainPage()
	{
		BindingContext = this;

		InitializeComponent();

        //var dataStore = new CreatureDataStore();
        //MyCreature = dataStore.ReadItem();
        var _creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
        MyCreature = _creatureDataStore.ReadItem();



        if (MyCreature == null)
		{
            new Creature
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
            //dataStore.CreateItem(MyCreature);
            _creatureDataStore.CreateItem(MyCreature);
            MyCreature = _creatureDataStore.ReadItem();
            Console.WriteLine("MyCreature was null");
            
        }
        else
        {
            Console.WriteLine("MyCreature was niet null");
            _creatureDataStore.UpdateItem(MyCreature);
        }
        


    }
    private void NextPageClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NewPage1());
    }

	private void StatsPageClicked(object sender, EventArgs e)
	{
        Navigation.PushAsync(new StatsShower());
    }

	private void OnNextRoomClicked(object sender, EventArgs e)
	{
        //roomCounter++;
        //RoomDecider(roomCounter);
        Navigation.PushAsync(new Corridor());
    }
    private void OnPreviousRoomClicked(object sender, EventArgs e)
    {
        OnGamingEvent?.Invoke();
    }

}

