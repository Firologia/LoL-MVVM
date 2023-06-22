using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LoL_MVVM.Utils;
using ViewModel;

namespace LoL_MVVM.ViewModel;

public partial class SkinEditVM : ObservableObject
{
    private ApplicationVM applicationVM = (Application.Current as App)?.ApplicationVM;
    private ChampionVM championVM;
    private SkinVM skinVM;
    public EditableSkinVM EditableSkinVM { get; set; } = new();

    public SkinEditVM(ChampionVM championVM)
    {
        this.championVM = championVM;
        EditableSkinVM = new EditableSkinVM()
        {
            ChampionVM = championVM,

        };
    }

    public SkinEditVM(SkinVM skinVM) : this(skinVM.ChampionVM)
    {
        this.skinVM = skinVM;
        EditableSkinVM.Name = skinVM.Name;
        EditableSkinVM.Description = skinVM.Description;
        EditableSkinVM.Icon = skinVM.Icon;
        EditableSkinVM.Image = skinVM.Image;
        EditableSkinVM.Price = skinVM.Price;
    }

    #region Commands

    [RelayCommand]
    private async Task PickIcon()
    {
        var icon = await EditFilePicker.PickImage();
        if (icon is not null) EditableSkinVM.Icon = icon;
    }
    
    [RelayCommand]
    private async Task PickImage()
    {
        var image = await EditFilePicker.PickImage();
        if (image is not null) EditableSkinVM.Icon = image;
    }

    #endregion




    /// <summary>
    /// This submit command call AddSkin or UpdateSkin depending on the skinVM
    /// </summary>
    [RelayCommand]
    private void Submit()
    {
        var editedSkin = new SkinVM(EditableSkinVM);
        if(skinVM == null) AddSkin(editedSkin);
        else UpdateSkin(skinVM, editedSkin);
        
        CloseEdition();
    }

    /// <summary>
    /// Add a skin to the model
    /// </summary>
    /// <param name="skinVM">Skin added</param>
    private void AddSkin(SkinVM skinVM)
    {
        applicationVM.ChampionsManagerVM.AddSkin(skinVM);
    }

    /// <summary>
    /// Update a skin in the model
    /// </summary>
    /// <param name="oldSkin">The oldSkin to update</param>
    /// <param name="newSkin">The new Skin</param>
    private void UpdateSkin(SkinVM oldSkin, SkinVM newSkin)
    {
        applicationVM.ChampionsManagerVM.UpdateSkin(oldSkin, newSkin);
    }
    
    /// <summary>
    /// When we push the cancel button, we close the edition
    /// </summary>
    [RelayCommand]
    private void Cancel()
    {
        CloseEdition();
    }
    
    private void CloseEdition()
    {
        ApplicationVM.Navigation.RemovePage(ApplicationVM.Navigation.NavigationStack.Last());
    }


}