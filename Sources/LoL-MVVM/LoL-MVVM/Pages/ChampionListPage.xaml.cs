using System.Collections.ObjectModel;
using ViewModel;

namespace LoL_MVVM.Pages;

public partial class ChampionListPage : ContentPage
{
    public ObservableCollection<ChampionVM> Champions { get; set; } = ( (App) Application.Current ).ChampionsVM;


	public ChampionListPage()
	{
        InitializeComponent();
        BindingContext = this;
	}

    async void ListView_ItemTapped(System.Object sender, Microsoft.Maui.Controls.ItemTappedEventArgs e)
    {
        if(e.Item is ChampionVM championVM)
        {
            await Navigation.PushAsync(new ChampionDetailsPage(championVM));
        }
        
    }
}