using System.Collections.ObjectModel;
using Custom_Toolkit_MVVM;
using Model;
using ViewModel.Enums;

namespace ViewModel
{
    public class ChampionVM : GenericClassVM<Champion>
    {

        internal Champion Model => model;
        public string Name => model.Name;
        public string Bio 
        {
            get => model.Bio ;
            set => SetModelPropertyChanged(model.Bio, value, EqualityComparer<string>.Default, model,
                (model, value) => { model.Bio = value!; });

        }

        public ChampionClassVM Class
        {
            get => (ChampionClassVM) Enum.Parse<ChampionClassVM>(model.Class.ToString());
            set => SetModelPropertyChanged(model.Class, value.ToModel(), EqualityComparer<ChampionClass>.Default, model,
                    (model, value) =>
                    {
                        model.Class = value;
                    });
        }

        public string Icon
        {
            get => model.Icon;
            set => SetModelPropertyChanged(model.Icon, value, EqualityComparer<string>.Default, model,
                    (model, value) => { model.Icon = value; });
        }

        public string LargeImage
        {
            get => model.Image.Base64;
            set => SetModelPropertyChanged(model.Image.Base64, value, EqualityComparer<string>.Default, model,
                (model, value) => { model.Image.Base64 = value!; });

        }
        
        public ReadOnlyObservableDictionary<string, int> Characteristics { get; }
        private readonly ObservableDictionary<string, int> characteristics = new();

        public ReadOnlyObservableCollection<SkillVM> Skills { get; private init; }
        private ObservableCollection<SkillVM> skills = new();

        public ReadOnlyObservableCollection<SkinVM> Skins { get; private init; }
        private ObservableCollection<SkinVM> skins = new();

        public ChampionVM(Champion model) : base(model)
        {
            Skills = new(skills);
            Skins = new(skins);

            foreach (var characteristic in model.Characteristics)
            {
                characteristics.Add(characteristic.Key, characteristic.Value);
            }
            
            Characteristics = new(characteristics);

            foreach (var skill in model.Skills)
            {
                skills.Add(new SkillVM(skill));
            }

            

            foreach (var skin in model.Skins)
            {
                skins.Add(new SkinVM(skin));
            }

            

        }

        public ChampionVM() : base(new Champion("", ChampionClass.Unknown))
        {
            //Characteristics = new(_characteristics);
            Skills = new(skills);
            Skins = new(skins);
        }

        public void AddCharacteristic(string key, int value)
        {
            model.AddCharacteristics(new Tuple<string, int>(key, value));
        }

        /// <summary>
        /// We know that this function is dirty but it's the only way to clear the characteristics... A better solution surely exist : )
        /// </summary>
        public void ClearCharacteristics()
        {
            int count = model.Characteristics.Count;
            for (int i = 0; i < count; i++)
            {
                model.RemoveCharacteristics(model.Characteristics.First().Key);
            }
        }
        /// <summary>
        /// We know that this function is dirty but it's the only way to clear the skills... A better solution surely exist : )
        /// </summary>
        public void ClearSkills()
        {
            int count = model.Skills.Count;
            for (int i = 0; i < count; i++)
            {
                model.RemoveSkill(model.Skills.First());
            }
        }
        
        public void RemoveSkill(SkillVM skill)
        {
            model.RemoveSkill(new Skill(skill.Name, skill.Type.ToModel(), skill.Description));
        }

        public void AddSkill(SkillVM skill)
        {
            model.AddSkill(new Skill(skill.Name, skill.Type.ToModel(), skill.Description));
        }
    }
}
