using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Custom_Toolkit_MVVM;
using Model;
using ViewModel.Utils;

namespace ViewModel
{
    public class ChampionVM : GenericClassVM<Champion> {


        public string Name => model.Name;
        public string Bio 
        {
            get => model.Bio ;
            set => SetModelPropertyChanged(model.Bio, value, EqualityComparer<string>.Default, model,
                (model, value) => { model.Icon = value!; });

        }

        public string Class
        {
            get => model.Class.ToString();
            set => SetModelPropertyChanged(model.Class.ToString(), value, EqualityComparer<string>.Default, model,
                    (model, value) =>
                    {
                        try
                        {
                            model.Class = (ChampionClass)Enum.Parse(typeof(ChampionClass), value);
                        }
                        catch(Exception)
                        {
                            model.Class = ChampionClass.Unknown;
                        }
                    });
        }

        public string Icon
        {
            get => model.Icon;
            set => SetModelPropertyChanged(model.Icon, value, EqualityComparer<string>.Default, model,
                    (model, value) => { model.Icon = value!; });
        }

        public string LargeImage
        {
            get => model.Image.Base64;
            set => SetModelPropertyChanged(model.Image.Base64, value, EqualityComparer<string>.Default, model,
                (model, value) => { model.Image.Base64 = value!; });

        }
        public ObservableDictionary<string, int> Characteristics { get; private init; }
        private ObservableDictionary<string, int> _characteristics = new();

        public ReadOnlyObservableCollection<SkillVM> Skills { get; private init; }
        public ObservableCollection<SkillVM> _skills = new();

        public ReadOnlyObservableCollection<SkinVM> Skins { get; private init; }
        public ObservableCollection<SkinVM> _skins = new();

        public ChampionVM(Champion model) : base(model)
        {
            foreach (var characteristic in model.Characteristics)
            {
                _characteristics.Add(characteristic.Key, characteristic.Value);
            }

            Characteristics = new(_characteristics);

            foreach (var skill in model.Skills)
            {
                _skills.Add(new SkillVM(skill));
            }

            Skills = new(_skills);

            foreach (var skin in model.Skins)
            {
                _skins.Add(new SkinVM(skin));
            }

            Skins = new(_skins);



        }
    }
}
