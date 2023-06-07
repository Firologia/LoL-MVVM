using System.Collections.ObjectModel;
using System.Globalization;
using LoL_MVVM.Converters;
using ViewModel;
using ViewModel.Enums;
using ViewModel.Utils;

namespace LoL_MVVM.Pages;

public partial class ChampionEditPage : ContentPage
{
	public ChampionVM ChampionVM { get; set; }
    public ChampionEditPage(ChampionVM championVm)
    {
        ChampionVM = championVm;
		InitializeComponent();
		BindingContext = this;

    }

    private void Cancel_OnClicked(object sender, EventArgs e)
    {
        Navigation.RemovePage(this);
    }

    private void Confirm_OnClicked(object sender, EventArgs e)
    {
        ChampionVM.Bio = BioEditor.Text;
    }
    
    
    private async Task<FileResult> PickAnIcon(PickOptions options)
    {
        try
        {
            var result = await FilePicker.Default.PickAsync(options);
            if (result != null)
            {
                if (result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ||
                    result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase))
                {
                    using var stream = await result.OpenReadAsync();
                    var image = ImageSource.FromStream(() => stream);
                }
            }

            return result;
        }
        catch (Exception ex)
        {
            // The user canceled or something went wrong
        }

        return null;
    }

    private async void Icon_Button_Clicked(object sender, EventArgs e)
    {
        var result = await PickAnIcon(new PickOptions()
        {
            PickerTitle = "Pick an icon",
            FileTypes = FilePickerFileType.Images
        });

        if(result != null) ChampionVM.Icon = await result.ToBase64();
    }

    private async void Image_Button_OnClicked(object sender, EventArgs e)
    {
        var result = await PickAnIcon(new PickOptions()
        {
            PickerTitle = "Pick an image",
            FileTypes = FilePickerFileType.Images
        });

        if(result != null) ChampionVM.LargeImage = await result.ToBase64();
    }
}