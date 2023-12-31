namespace FirstAppGame;

public partial class StatsUI : ContentView
{
    private IDataStore<Creature> creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
    private ActionStateManager actionStateManager = DependencyService.Get<ActionStateManager>();


    public delegate void PlayerActionButton();
    public static event PlayerActionButton OnDeadEvent;


    private Creature creature;

    public StatsUI()
    {
        Console.WriteLine("Ik STATSUI geactiveerd :) ");
        InitializeComponent();
        UpdateStatsUI();
        //CheckStats(); als ik deze aan doe en de if statement is true, dan gaat de constructor zichzelf in een loop aanzetten?

    }

    private void UpdateStatsUI()
    {

        creature = creatureDataStore.ReadItem();

        PlayerName.Text = "Naam : " + creature.Name;
        PlayerMoney.Text = "Money : " + ((int)creature.Money).ToString();
        PlayerAction.Text = "Action : " + creature.PlayerAction.ToString();


        PlayerHunger.Text = "Hunger : " + ((int)creature.Hunger).ToString() + "%";
        PlayerThirst.Text = "Thirst : " + ((int)creature.Thirst).ToString() + "%";
        PlayerEnergy.Text = "Energy : " + ((int)creature.Sleepy).ToString() + "%";

        PlayerOverStimulated.Text = "brain dead : " + ((int)creature.OverStimulated).ToString() + "%";
        PlayerBored.Text = "Bored : " + ((int)creature.Bored).ToString() + "%";
        PlayerLonely.Text = "Lonely : " + ((int)creature.Lonely).ToString() + "%";

    }

    private void CheckStats()
    {

        if (creature.Hunger <= 0.0f && creature.Thirst <= 0.0f && actionStateManager.CurrentState != ActionStateManager.PlayerAction.ending) 
        {
            OnDeadEvent.Invoke();
            Navigation.PushAsync(new EndingHunger());
        }

        if (creature.Money <= -200.0f && actionStateManager.CurrentState != ActionStateManager.PlayerAction.ending)
        {
            OnDeadEvent.Invoke();
            Navigation.PushAsync(new EndingDebt());
        }
    }

}