using System.ComponentModel;
using System.Runtime.CompilerServices;
using Model;

namespace ViewModel;

public class SkinVM : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private Skin _model;

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

    public string Icon
    {
        get => _model.Icon;
        set
        {
            if(_model.Icon.Equals(value)) return;
            _model.Icon = value;
            OnPropertyChanged();
        }
    }

    public float Price
    {
        get => _model.Price;
        set
        {
            if(_model.Price.Equals(value)) return;
            _model.Price = value;
            OnPropertyChanged();
        }
    }

    public SkinVM(Skin model)
    {
        _model = model;
    }
}