using System.Collections.ObjectModel;
using LoL_MVVM.ViewModel;
using ViewModel;

namespace LoL_MVVM.Pages;

public partial class ChampionListPage : ContentPage
{
    public ApplicationVM ApplicationVM { get; } = (Application.Current as App).ApplicationVM;
	public ChampionListPage()
    {
        InitializeComponent();
        BindingContext = ApplicationVM;
    }
}