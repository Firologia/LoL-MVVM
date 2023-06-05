using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ChampionClassManagerVM
    {

        public static ObservableCollection<string> ChampionClasses { get; } = new ()
        {
            "Assassin",
            "Fighter",
            "Mage",
            "Marksman",
            "Support",
            "Tank"
        };
    }
}
