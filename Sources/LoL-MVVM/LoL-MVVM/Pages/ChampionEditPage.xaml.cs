using System.Collections.ObjectModel;
using ViewModel;

namespace LoL_MVVM.Pages;

public partial class ChampionEditPage : ContentPage
{
	public ChampionVM ChampionVM { get; set; }
    public ObservableCollection<ChampionClassVM> Classes { get; } = ChampionClassVM.getAllClasses();
    public ChampionEditPage(ChampionVM championVm)
    {
        ChampionVM = championVm;
		InitializeComponent();
		BindingContext = this;
        /*
        foreach (ChampionClassVM item in ClassesCollectionView.ItemsSource)
        {
            if(item.Name == ChampionVM.Class) ClassesCollectionView.SelectedItem = item;
        }
        */
        
    }

    private void Cancel_OnClicked(object sender, EventArgs e)
    {
        Navigation.RemovePage(this);
    }

    private void Confirm_OnClicked(object sender, EventArgs e)
    {
        ChampionVM.Bio = BioEditor.Text;
        //ChampionVM.Class = ClassesCollectionView.SelectedItem.ToString() ?? string.Empty;
    }
}