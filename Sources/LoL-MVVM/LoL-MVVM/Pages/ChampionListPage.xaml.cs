using System.Collections.ObjectModel;
using LoL_MVVM.ViewModel;
using ViewModel;

namespace LoL_MVVM.Pages;

public partial class ChampionListPage : ContentPage
{
    private ApplicationVM ApplicationVM = (Application.Current as App).ApplicationVM;
	public ChampionListPage()
    {
        InitializeComponent();
        BindingContext = ApplicationVM;
    }

    async void ListView_ItemTapped(System.Object sender, Microsoft.Maui.Controls.ItemTappedEventArgs e)
    {
        if(e.Item is ChampionVM championVM)
        {
            await Navigation.PushAsync(new ChampionDetailsPage(championVM));
        }
        
    }
}