using System.Collections.ObjectModel;
using Model;

namespace LoL_MVVM.Pages;

public partial class ChampionListPage : ContentPage
{
    public ObservableCollection<Champion> Champions { get; set; } = ((App)Application.Current).Champions;

    public ObservableCollection<int> Items { get; set; } = new ObservableCollection<int>();

	public ChampionListPage()
	{
		Items.Add(0);
        Items.Add(0);
        Items.Add(0);
        Items.Add(0);
        Items.Add(0);
        InitializeComponent();
        BindingContext = this;
	}
}