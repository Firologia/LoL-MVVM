using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Custom_Toolkit_MVVM;

public class ReadOnlyObservableDictionary<TKey, TValue> : ReadOnlyDictionary<TKey, TValue>, INotifyPropertyChanged, INotifyCollectionChanged
    where TKey : notnull
{

    public event PropertyChangedEventHandler? PropertyChanged;
    public event NotifyCollectionChangedEventHandler? CollectionChanged;

    public ReadOnlyObservableDictionary(ObservableDictionary<TKey, TValue> dictionary) : base(dictionary)
    {
        dictionary.CollectionChanged += HandleCollectionChanged;
        dictionary.PropertyChanged += HandlePropertyChange;
    }

    protected virtual void HandlePropertyChange(object sender,PropertyChangedEventArgs args)
    {
        OnPropertyChanged(args);
    }

    protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
    {
        PropertyChanged?.Invoke(this,args);
    }

    protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs args)
    {
        CollectionChanged?.Invoke(this, args);
    }

    private void HandleCollectionChanged(object sender,NotifyCollectionChangedEventArgs eventArgs)
    {
        OnCollectionChanged(eventArgs);
    }

}
