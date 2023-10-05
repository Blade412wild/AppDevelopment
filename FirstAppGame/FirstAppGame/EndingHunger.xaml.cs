namespace FirstAppGame;

public partial class EndingHunger : ContentPage
{
    private IDataStore<Creature> creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
    private IDataStore<OwnTime> pastTimeDataStore = DependencyService.Get<IDataStore<OwnTime>>();
    private Creature creature;
    private OwnTime ownTime;

    public EndingHunger()
	{
		InitializeComponent(); 
        Console.WriteLine("EndingHunger");
        creature = creatureDataStore.ReadItem();
        ownTime = pastTimeDataStore.ReadItem();
    }

	private void OnRestartClicked(object sender, EventArgs e)
	{
        creatureDataStore.DeleteItem(creature);
        pastTimeDataStore.DeleteItem(ownTime);

        Application.Current.Quit();

    }

}