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
        private Skill model;
        public string Name => model.Name;

        public string Description
        {
            get => model.Description;
            set
            {
                if(model.Description.Equals(value)) return;
                model.Description = value;
                OnPropertyChanged();
            }
        }
        public string Type => model.Type.ToString();

        public SkillVM(Model.Skill model)
        {
            this.model = model;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
}
