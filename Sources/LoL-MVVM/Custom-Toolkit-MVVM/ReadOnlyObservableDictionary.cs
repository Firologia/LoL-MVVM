using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Custom_Toolkit_MVVM;

public sealed class ReadOnlyObservableDictionary<TKey, TValue> : ReadOnlyDictionary<TKey, TValue>, INotifyPropertyChanged, INotifyCollectionChanged
    where TKey : notnull
{

    private ObservableDictionary<TKey, TValue> dictionary;
    public event PropertyChangedEventHandler? PropertyChanged
    {
        add => dictionary.PropertyChanged += value;
        remove => dictionary.PropertyChanged -= value;
    }
    public event NotifyCollectionChangedEventHandler? CollectionChanged;

    public ReadOnlyObservableDictionary(ObservableDictionary<TKey, TValue> dictionary) : base(dictionary)
    {
        this.dictionary = dictionary;
    }

}
