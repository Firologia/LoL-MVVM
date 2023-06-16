using Model;

namespace ViewModel.Enums;

public static class ChampionClassMapper
{
 
    public static ChampionClassVM ToViewModel(this ChampionClass championClass)
    {
        switch (championClass)
        {
            case ChampionClass.Unknown:
                return ChampionClassVM.Unknown;
            case ChampionClass.Assassin:
                return ChampionClassVM.Assassin;
            case ChampionClass.Fighter:
                return ChampionClassVM.Fighter;
            case ChampionClass.Mage:
                return ChampionClassVM.Mage;
            case ChampionClass.Marksman:
                return ChampionClassVM.Marksman;
            case ChampionClass.Support:
                return ChampionClassVM.Support;
            case ChampionClass.Tank:
                return ChampionClassVM.Tank;
            default:
                throw new ArgumentOutOfRangeException(nameof(championClass), championClass, "Invalid ChampionClass value.");
        }
    }
    
    public static ChampionClass ToModel(this ChampionClassVM championClassVM)
    {
        switch (championClassVM)
        {
            case ChampionClassVM.Unknown:
                return ChampionClass.Unknown;
            case ChampionClassVM.Assassin:
                return ChampionClass.Assassin;
            case ChampionClassVM.Fighter:
                return ChampionClass.Fighter;
            case ChampionClassVM.Mage:
                return ChampionClass.Mage;
            case ChampionClassVM.Marksman:
                return ChampionClass.Marksman;
            case ChampionClassVM.Support:
                return ChampionClass.Support;
            case ChampionClassVM.Tank:
                return ChampionClass.Tank;
            default:
                throw new ArgumentOutOfRangeException(nameof(championClassVM), championClassVM, "Invalid ChampionClassVM value.");
        }
    }


}