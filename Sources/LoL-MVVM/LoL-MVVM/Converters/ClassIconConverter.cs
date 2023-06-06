using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Enums;

namespace LoL_MVVM.Converters
{
    public class ClassIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is not ChampionClassVM) return false;

            switch (value)
            {
                case ChampionClassVM.Assassin :
                    return "role_icon_assassin.png";
                case ChampionClassVM.Fighter:
                    return "role_icon_fighter.png";
                case ChampionClassVM.Mage:
                    return "role_icon_mage.png";
                case ChampionClassVM.Marksman:
                    return "role_icon_marksman.png";
                case ChampionClassVM.Support:
                    return "role_icon_support.png";
                case ChampionClassVM.Tank:
                    return "role_icon_tank.png";

                default: return "role_icon_unknown.png";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
