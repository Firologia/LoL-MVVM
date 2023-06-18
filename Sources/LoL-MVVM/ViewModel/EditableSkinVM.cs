
using Model;
using ViewModel.Enums;
using ViewModel.Utils;

namespace ViewModel;

public class EditableSkinVM
{
    public string Name { get; set; } = "";
    public ChampionVM ChampionVM { get; set; }
    public string Description { get; set; } = "";
    public string Icon { get; set; } = Base64Constants.DEFAULT_ICON;
    public string Image { get; set; } = Base64Constants.DEFAULT_IMAGE;
    public float Price { get; set; } = 0;
    
    public Skin ToModel()
    {
        return new Skin(Name,new Champion(ChampionVM.Name, ChampionVM.Class.ToModel(), ChampionVM.Icon, ChampionVM.LargeImage, ChampionVM.Bio),Price,Icon,Image,Description);
    }
    
    
}