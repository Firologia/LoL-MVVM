
using CommunityToolkit.Mvvm.ComponentModel;
using Model;
using ViewModel.Enums;
using ViewModel.Utils;

namespace ViewModel;

public partial class EditableSkinVM : ObservableObject
{
    [ObservableProperty] 
    private string _name = "";

    [ObservableProperty] 
    private ChampionVM _championVM;
    
    [ObservableProperty] 
    private string _description;

    [ObservableProperty] 
    private string _icon = Base64Constants.DEFAULT_ICON;
    
    [ObservableProperty] 
    private string _image = Base64Constants.DEFAULT_IMAGE;
    
    [ObservableProperty] 
    private float _price;
    
    public Skin ToModel()
    {
        return new Skin(_name,new Champion(ChampionVM.Name, ChampionVM.Class.ToModel(), ChampionVM.Icon, ChampionVM.LargeImage, ChampionVM.Bio),Price,Icon,Image,Description);
    }
    
    
}