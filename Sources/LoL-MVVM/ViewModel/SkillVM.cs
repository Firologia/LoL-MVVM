using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel;
public class SkillVM : INotifyPropertyChanged
    {
        private Skill _model;
        public string Name => _model.Name;

        public string Description
        {
            get => _model.Description;
            set
            {
                if(_model.Description.Equals(value)) return;
                _model.Description = value;
                OnPropertyChanged();
            }
        }
        public string Type => _model.Type.ToString();

        public SkillVM(Model.Skill model)
        {
            _model = model;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
}
