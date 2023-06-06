using System;
using System.Collections.ObjectModel;

namespace ViewModel
{
	public class ChampionClassVM
	{
		public string ImagePath { get; set; }

		public string Name { get; set; }

		public ChampionClassVM(string ImagePath,string Name)
		{
			this.ImagePath = ImagePath;
			this.Name = Name;
		}

		public static ObservableCollection<ChampionClassVM> getAllClasses()
		{
			return new ObservableCollection<ChampionClassVM>()
			{
				new ChampionClassVM("role_icon_assassin.png", "Assassin"),
				new ChampionClassVM("role_icon_fighter.png", "Fighter"),
				new ChampionClassVM("role_icon_mage.png", "Mage"),
				new ChampionClassVM("role_icon_marksman", "Marksman"),
				new ChampionClassVM("role_icon_support", "Support"),
				new ChampionClassVM("role_icon_tank", "Tank")

			};
		}
	}
}

