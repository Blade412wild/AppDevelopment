namespace FirstAppGame;

public partial class App : Application
{
	public App()
	{
		DependencyService.RegisterSingleton<IDataStore<Creature>>(new CreatureDataStore());
        DependencyService.RegisterSingleton<ActionStateManager>(new ActionStateManager());

        InitializeComponent();

		MainPage = new NavigationPage(new StartMenu());
		//MainPage = new AppShell();
	}
}
