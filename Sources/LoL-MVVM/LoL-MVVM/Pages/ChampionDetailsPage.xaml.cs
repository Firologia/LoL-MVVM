using ViewModel;

namespace LoL_MVVM.Pages;

public partial class ChampionDetailsPage : ContentPage
{
	public ChampionVM ChampionVM { get; set; }

	public ChampionDetailsPage(ChampionVM championVM)
	{
		ChampionVM = championVM;
        InitializeComponent();
		BindingContext = ChampionVM;

	}

    private void Edit_Champion(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ChampionEditPage(ChampionVM));
    }
}