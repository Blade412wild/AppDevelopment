using System.ComponentModel;

namespace FirstAppGame;

public partial class Corridor : ContentPage, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    public delegate void PlayerActionButton();
    public static event PlayerActionButton OnWorkEvent;

    public delegate void RoomSwitchButton(int _room);
    public static event RoomSwitchButton RoomButtonIsPressed;

    private ActionStateManager actionStateManager = DependencyService.Get<ActionStateManager>();



    public string NameTest;
    private Creature currentCreature;
    public Corridor()
    {

        InitializeComponent();
        //var _creatureDataStore = DependencyService.Get<IDataStore<Creature>>();//dit verwijst inderdaad naar de singelton
        //currentCreature = _creatureDataStore.ReadItem(); // hier komt een System.NullReferenceException uit;
        //Console.WriteLine("CurrentCreature ! " + currentCreature);
        //NameTest = _creatureDataStore.Test();
    }


    private void OnNextRoomClicked(object sender, EventArgs e)
    {
        if (actionStateManager.CurrentState == ActionStateManager.PlayerAction.Eating)
        {
            Navigation.PushAsync(new LivingRoomP());
        }
        else
        {
            Navigation.PushAsync(new LivingRoom());
        }
    }
    private void OnPreviousRoomClicked(object sender, EventArgs e)
    {
        if (actionStateManager.CurrentState == ActionStateManager.PlayerAction.Sleeping)
        {
            Navigation.PushAsync(new BedRoomP());
        }
        else
        {
            Navigation.PushAsync(new BedRoom());
        }
    }
    private void OnImageButtonClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new CorridorP());
    }
}