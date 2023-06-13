using System.Collections.ObjectModel;
using System.Globalization;
using LoL_MVVM.Converters;
using ViewModel;
using ViewModel.Enums;
using LoL_MVVM.Utils;
using LoL_MVVM.ViewModel;

namespace LoL_MVVM.Pages;

public partial class ChampionEditPage : ContentPage
{
	public EditVM EditVM { get; set; }
    public ChampionEditPage(EditVM editVM)
    {
        EditVM = editVM;
		InitializeComponent();
		BindingContext = editVM;

    }
    



}