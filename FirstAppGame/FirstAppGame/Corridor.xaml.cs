using System.ComponentModel;

namespace FirstAppGame;

public partial class Corridor : ContentPage, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    public delegate void ButtonPressed();
    public static event ButtonPressed OnWorkEvent;

    public string NameTest;
    private Creature currentCreature;
    public Corridor()
    {

        InitializeComponent();
        var _creatureDataStore = DependencyService.Get<IDataStore<Creature>>();//dit verwijst inderdaad naar de singelton
        currentCreature = _creatureDataStore.ReadItem(); // hier komt een System.NullReferenceException uit;
        Console.WriteLine("CurrentCreature ! " + currentCreature);
        //NameTest = _creatureDataStore.Test();
    }

    private void OnNextRoomClicked(object sender, EventArgs e)
    {
        //ActionStateManager.actionStateManager.ChangeAction(0);
        Navigation.PushAsync(new LivingRoom());

    }
    private void OnPreviousRoomClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new BedRoom());
    }
}