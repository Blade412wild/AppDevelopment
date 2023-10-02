using System.ComponentModel;

namespace FirstAppGame;

public partial class ChillRoom : ContentPage, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    public delegate void PlayerActionButton();
    public static event PlayerActionButton OnGamingEvent;

    public delegate void RoomSwitchButton(int _room);
    public static event RoomSwitchButton RoomButtonIsPressed;

    private ActionStateManager actionStateManager = DependencyService.Get<ActionStateManager>();
    private IDataStore<Creature> creatureDataStore = DependencyService.Get<IDataStore<Creature>>();

    public Creature LocalCreature { get; set; }


    public ChillRoom()
    {
        InitializeComponent();
        LocalCreature = creatureDataStore.ReadItem();
        Console.WriteLine(LocalCreature.Name);
    }


    private void OnNextRoomClicked(object sender, EventArgs e)
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
    private void OnPreviousRoomClicked(object sender, EventArgs e)
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
    private void OnImageButtonClicked(object sender, EventArgs e)
    {
        OnGamingEvent?.Invoke();
        Navigation.PushAsync(new ChillRoomP());
    }
}