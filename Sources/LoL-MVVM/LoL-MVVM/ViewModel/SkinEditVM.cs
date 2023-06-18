using System.Windows.Input;
using LoL_MVVM.Utils;
using ViewModel;

namespace LoL_MVVM.ViewModel;

public class SkinEditVM
{
    private ApplicationVM applicationVM = (Application.Current as App)?.ApplicationVM;
    private ChampionVM championVM;
    private SkinVM skinVM;
    public EditableSkinVM EditableSkinVM { get; set; } = new();
    
    public ICommand PickImageCommand { get; }
    public ICommand PickIconCommand { get; }
    public ICommand SubmitCommand { get; }
    public ICommand CancelCommand { get; }

    public SkinEditVM(ChampionVM championVM)
    {
        this.championVM = championVM;
        EditableSkinVM = new EditableSkinVM()
        {
            ChampionVM = championVM,

        };

        SubmitCommand = new Command(SubmitCommandMethod);
        CancelCommand = new Command(CancelCommandMethod);
        PickIconCommand = new Command(PickIconCommandMethod);
        PickImageCommand = new Command(PickImageCommandMethod);
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

    private async void PickIconCommandMethod()
    {
        var icon = await EditFilePicker.PickImage();
        if (icon is not null) EditableSkinVM.Icon = icon;
    }

    private async void PickImageCommandMethod()
    {
        var image = await EditFilePicker.PickImage();
        if (image is not null) EditableSkinVM.Icon = image;
    }

    /// <summary>
    /// This submit command call AddSkin or UpdateSkin depending on the skinVM
    /// </summary>
    /// <param name="execute"></param>
    private void SubmitCommandMethod(object execute)
    {
        var skinToAdd = new SkinVM(EditableSkinVM);
        if(skinVM == null) AddSkin(skinToAdd);
        else UpdateSkin(skinVM, skinToAdd);
        
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
    /// <param name="execute"></param>
    private void CancelCommandMethod(object execute)
    {
        CloseEdition();
    }
    
    private void CloseEdition()
    {
        ApplicationVM.Navigation.RemovePage(ApplicationVM.Navigation.NavigationStack.Last());
    }


}