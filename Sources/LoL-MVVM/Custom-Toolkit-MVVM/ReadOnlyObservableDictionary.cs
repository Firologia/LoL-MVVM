using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ViewModel.Utils;

namespace Custom_Toolkit_MVVM;

public class ReadOnlyObservableDictionary<TKey, TValue> : IReadOnlyDictionary<TKey, TValue>, INotifyPropertyChanged, INotifyCollectionChanged
    where TKey : notnull
{
    private readonly ObservableDictionary<TKey, TValue> dictionary;

    public event PropertyChangedEventHandler? PropertyChanged
    {
        add => dictionary.PropertyChanged += value;
        remove => dictionary.PropertyChanged -= value;
    }

    public event NotifyCollectionChangedEventHandler? CollectionChanged
    {
        add => dictionary.CollectionChanged += value;
        remove => dictionary.CollectionChanged -= value;
    }

    public ReadOnlyObservableDictionary(ObservableDictionary<TKey, TValue> dictionary)
    {
        this.dictionary = dictionary;
    }

    public int Count => dictionary.Count;

    public IEnumerable<TKey> Keys => dictionary.Keys;

    public IEnumerable<TValue> Values => dictionary.Values;

    public TValue this[TKey key] => dictionary[key];

    public bool ContainsKey(TKey key)
    {
        return dictionary.ContainsKey(key);
    }

    public bool TryGetValue(TKey key, out TValue value)
    {
        return dictionary.TryGetValue(key, out value);
    }

    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
    {
        return dictionary.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)dictionary).GetEnumerator();
    }

    public ObservableDictionary<TKey, TValue> ToObservableDictionary()
    {
        return new ObservableDictionary<TKey, TValue>(dictionary);
    }

}
