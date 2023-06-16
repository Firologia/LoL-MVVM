using Model;
using ViewModel.Enums;

namespace ViewModel;

public class EditableSkinVM
{
    public string Name { get; set; }
    public ChampionVM ChampionVM { get; set; }
    public string Description { get; set; }
    public string Icon { get; set; }
    public string Image { get; set; }
    public float Price { get; set; }
    
    public Skin ToModel()
    {
        return new Skin(Name,new Champion(ChampionVM.Name, ChampionVM.Class.ToModel(), ChampionVM.Icon, ChampionVM.LargeImage, ChampionVM.Bio),Price,Icon,Image,Description);
    }
    
    
}