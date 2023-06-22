using System.Collections.ObjectModel;
using Custom_Toolkit_MVVM;
using Model;
using ViewModel.Enums;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ViewModel
{
    public class ChampionVM : ObservableObject
    {

        private readonly Champion model;
        internal Champion Model => model;
        public string Name => model.Name;
        public string Bio 
        {
            get => model.Bio ;
            set => SetProperty(model.Bio, value, EqualityComparer<string>.Default, model,
                (model, value) => { model.Bio = value!; });

        }

        public ChampionClassVM Class
        {
            get => model.Class.ToViewModel();
            set => SetProperty(model.Class, value.ToModel(), EqualityComparer<ChampionClass>.Default, model,
                    (model, value) =>
                    {
                        model.Class = value;
                    });
        }

        public string Icon
        {
            get => model.Icon;
            set => SetProperty(model.Icon, value, EqualityComparer<string>.Default, model,
                    (model, value) => { model.Icon = value; });
        }

        public string LargeImage
        {
            get => model.Image.Base64;
            set => SetProperty(model.Image.Base64, value, EqualityComparer<string>.Default, model,
                (model, value) => { model.Image.Base64 = value!; });

        }
        
        public ReadOnlyObservableDictionary<string, int> Characteristics { get; }
        private readonly ObservableDictionary<string, int> characteristics = new();

        public ReadOnlyObservableCollection<SkillVM> Skills { get; private init; }
        private ObservableCollection<SkillVM> skills = new();

        public ReadOnlyObservableCollection<SkinVM> Skins { get; private init; }
        private ObservableCollection<SkinVM> skins = new();

        public ChampionVM(Champion model)
        {
            this.model = model;
            
            characteristics = new ObservableDictionary<string, int>(model.Characteristics);
            Characteristics = new(characteristics);

            skills = new ObservableCollection<SkillVM>(model.Skills.Select(skill => new SkillVM(skill)));
            Skills = new(skills);

            skins = new ObservableCollection<SkinVM>(model.Skins.Select(skin => new SkinVM(skin)));
            Skins = new(skins);
        }

        public ChampionVM()
        {
            model = new Champion("", ChampionClass.Unknown);
            Characteristics = new(characteristics);
            Skills = new(skills);
            Skins = new(skins);
        }

        public void AddCharacteristic(string key, int value)
        {
            model.AddCharacteristics(new Tuple<string, int>(key, value));
            characteristics.Add(key, value);
        }

        /// <summary>
        /// We know that this function is dirty but it's the only way to clear the characteristics... A better solution surely exist : )
        /// </summary>
        public void ClearCharacteristics()
        {
            foreach (var kvp in characteristics)
            {
                model.RemoveCharacteristics(kvp.Key);
            }
            characteristics.Clear();
        }
        /// <summary>
        /// We know that this function is dirty but it's the only way to clear the skills... A better solution surely exist : )
        /// </summary>
        public void ClearSkills()
        {
            foreach (var skill in Skills)
            {
                model.RemoveSkill(skill.Model);
            }
            skills.Clear();
        }
        
        public void RemoveSkill(SkillVM skill)
        {
            var result = model.RemoveSkill(skill.Model);
            if(result) skills.Remove(skill);
        }

        public void AddSkill(SkillVM skill)
        {
            var result =model.AddSkill(skill.Model);
            if(result) skills.Add(skill);
        }
    }
}
