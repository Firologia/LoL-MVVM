﻿using System.Collections.ObjectModel;
using Custom_Toolkit_MVVM;
using Model;
using ViewModel.Enums;

namespace ViewModel
{
    public class ChampionVM : GenericClassVM<Champion>
    {

        internal new Champion Model => base.model;
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
            set => SetModelPropertyChanged(model.Class, Enum.Parse<ChampionClass>(value.ToString()), EqualityComparer<ChampionClass>.Default, model,
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
        private ObservableCollection<SkillVM> _skills = new();

        public ReadOnlyObservableCollection<SkinVM> Skins { get; private init; }
        private ObservableCollection<SkinVM> _skins = new();

        public ChampionVM(Champion model) : base(model)
        {
            Skills = new(_skills);
            Skins = new(_skins);

            foreach (var characteristic in model.Characteristics)
            {
                characteristics.Add(characteristic.Key, characteristic.Value);
            }
            
            Characteristics = new(characteristics);

            foreach (var skill in model.Skills)
            {
                _skills.Add(new SkillVM(skill));
            }

            

            foreach (var skin in model.Skins)
            {
                _skins.Add(new SkinVM(skin));
            }

            

        }

        public ChampionVM() : base(new Champion("", ChampionClass.Unknown))
        {
            //Characteristics = new(_characteristics);
            Skills = new(_skills);
            Skins = new(_skins);
        }

        public void AddCharacteristic(string key, int value)
        {
            characteristics.Add(key, value);
        }

        public void ClearCharacteristics()
        {
            characteristics.Clear();
        }

    }
}
