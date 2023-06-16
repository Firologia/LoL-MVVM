using System.Windows.Input;
using ViewModel;

namespace LoL_MVVM.ViewModel;

public class SkinEditVM
{
    private ApplicationVM applicationVM = (Application.Current as App)?.ApplicationVM;
    private ChampionVM championVM;
    private SkinVM skinVM;
    public EditableSkinVM EditableSkinVM { get; set; } = new();
    
    public ICommand SubmitCommand { get; }
    public ICommand CancelCommand { get; }
    
    public SkinEditVM(ChampionVM championVM)
    {
        this.championVM = championVM;
        
        SubmitCommand = new Command(SubmitCommandMethod);
        CancelCommand = new Command(CancelCommandMethod);
    }
    
    public SkinEditVM(ChampionVM championVM,SkinVM skinVM) : this(championVM)
    {
        this.skinVM = skinVM;
        EditableSkinVM = new EditableSkinVM()
        {
            Name = skinVM.Name,
            Description = skinVM.Description,
            Icon = skinVM.Icon,
            Image = skinVM.Image,
            Price = skinVM.Price
        };
    }
    
    private void SubmitCommandMethod(object execute)
    {
        var oldSkin = skinVM;
        
        CloseEdition();
    }
    
    private void CancelCommandMethod(object execute)
    {
        CloseEdition();
    }
    
    private void CloseEdition()
    {
        ApplicationVM.Navigation.RemovePage(ApplicationVM.Navigation.NavigationStack.Last());
    }


}