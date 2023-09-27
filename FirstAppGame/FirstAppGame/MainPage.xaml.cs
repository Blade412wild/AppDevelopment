﻿using System.ComponentModel;

namespace FirstAppGame;

public partial class MainPage : ContentPage, INotifyPropertyChanged
{
	public event PropertyChangedEventHandler PropertyChanged;
	int count = 0;

	public Creature MyCreature { get; set; } = new Creature
	{
		Name = " Simon",
		Hunger = 100.0f,
		Thirst = 100.0f,
		Bored = 100.0f,
		Lonely = 100.0f,
		OverStimulated = 100.0f,
		Sleepy = 100.0f,
		Money = 0.0f

	};



	public MainPage()
	{
		BindingContext = this;

		InitializeComponent();
		
		var dataStore = new CreatureDataStore();
		MyCreature = dataStore.ReadItem();

		if(MyCreature == null)
		{
            new Creature
            {
                Name = " Simon",
                Hunger = 100.0f,
                Thirst = 100.0f,
                Bored = 100.0f,
                Lonely = 100.0f,
                OverStimulated = 100.0f,
                Sleepy = 100.0f,
                Money = 0.0f
            };
			dataStore.CreateItem(MyCreature);
        }
	}

	private async void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Daddy Touched me {count} time";
		else
			CounterBtn.Text = $"Daddy Touched me  {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);

		var result = await CounterBtn.RelRotateTo(90.0, 1000, Easing.SpringIn);

    }
    private void NextPageClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NewPage1());
		
    }

	private void StatsPageClicked(object sender, EventArgs e)
	{
        Navigation.PushAsync(new StatsShower());

    }
}

