using System.ComponentModel;

namespace FirstAppGame;

public partial class Corridor : ContentPage, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    public string NameTest;
    private Creature currentCreature;
    public Corridor()
    {

        InitializeComponent();
        var _creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
        currentCreature = _creatureDataStore.ReadItem();
        //NameTest = currentCreature.Name;
    }

    private void OnNextRoomClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new LivingRoom());

    }
    private void OnPreviousRoomClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new BedRoom());
    }
}