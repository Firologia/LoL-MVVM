using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Model;
using ViewModel.Utils;

namespace ViewModel
{
    public class ChampionVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private Champion _model;

        public string Name => _model.Name;
        public string Bio 
        {
            get => _model.Bio ;
            set
            {
                if (_model.Bio.Equals(value)) return;
                _model.Bio = value;
                OnPropertyChanged();
            }

        }

        public string Class
        {
            get => _model.Class.ToString();
            set
            {
                if (_model.Class.ToString().Equals(value)) return;
                try
                {
                    _model.Class = (ChampionClass)Enum.Parse(typeof(ChampionClass), value);
                }
                catch (Exception)
                {
                    _model.Class = ChampionClass.Unknown;
                }
            }
        }

        public string Icon
        {
            get => _model.Icon;
            set
            {
                if (_model.Icon.Equals(value)) return;
                _model.Icon = value;
                OnPropertyChanged();
            }
        }
        
        public string LargeImage
        {
            get => _model.Image.Base64;
            set
            {
                if (_model.Image.Base64.Equals(value)) return;
                _model.Image.Base64 = value;
                OnPropertyChanged();
            }
        }
        public ObservableDictionary<string, int> Characteristics { get; private init; }
        private ObservableDictionary<string, int> _characteristics = new();

        public ReadOnlyObservableCollection<SkillVM> Skills { get; private init; }
        public ObservableCollection<SkillVM> _skills = new();
        public ChampionVM(Champion model)
        {
            _model = model;
            foreach (var characteristic in _model.Characteristics)
            {
                _characteristics.Add(characteristic.Key, characteristic.Value);
            }

            Characteristics = new(_characteristics);

            foreach (var skill in _model.Skills)
            {
                _skills.Add(new SkillVM(skill));
            }

            Skills = new(_skills);



        }


        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
