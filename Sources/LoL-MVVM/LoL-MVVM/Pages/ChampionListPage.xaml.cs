using System.Collections.ObjectModel;
using ViewModel;

namespace LoL_MVVM.Pages;

public partial class ChampionListPage : ContentPage
{

    private ChampionsManagerVM championsManagerVm;

	public ChampionListPage(ChampionsManagerVM championsManagerVm)
    {
        this.championsManagerVm = championsManagerVm;
        InitializeComponent();
        BindingContext = this.championsManagerVm;
	}

    async void ListView_ItemTapped(System.Object sender, Microsoft.Maui.Controls.ItemTappedEventArgs e)
    {
        if(e.Item is ChampionVM championVM)
        {
            await Navigation.PushAsync(new ChampionDetailsPage(championVM));
        }
        
    }
}