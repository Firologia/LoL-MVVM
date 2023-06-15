

using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ViewModel.Utils;

public sealed class ObservableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, INotifyPropertyChanged, INotifyCollectionChanged
where TKey : notnull
{

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public event NotifyCollectionChangedEventHandler? CollectionChanged;

    private void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
    {
        CollectionChanged?.Invoke(this, e);
    }

    #region constructors

    public ObservableDictionary() : base(0, null) { }

    public ObservableDictionary(int capacity) : base(capacity, null) { }

    public ObservableDictionary(IEqualityComparer<TKey>? comparer) : base(comparer) { }

    public ObservableDictionary(int capacity, IEqualityComparer<TKey>? comparer) : base(capacity, comparer) { }

    public ObservableDictionary(IDictionary<TKey, TValue> dictionary) : base(dictionary) { }

    public ObservableDictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey>? comparer) : base(dictionary, comparer) { }

    public ObservableDictionary(IEnumerable<KeyValuePair<TKey, TValue>> collection) : base(collection) { }

    public ObservableDictionary(IEnumerable<KeyValuePair<TKey, TValue>> collection, IEqualityComparer<TKey>? comparer) : base(collection, comparer) { }

    #endregion

    public new void Clear()
    {
        base.Clear();
        OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        OnPropertyChanged(nameof(Keys));
        OnPropertyChanged(nameof(Values));
        OnPropertyChanged(nameof(Count));
    }

    public new void Add(TKey tKey, TValue tValue)
    {
        base.Add(tKey, tValue);
        OnCollectionChanged( new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, new KeyValuePair<TKey, TValue>(tKey, tValue)));
        OnPropertyChanged(nameof(Keys));
        OnPropertyChanged(nameof(Values));
        OnPropertyChanged(nameof(Count));
    }
    
    public new bool TryAdd(TKey tKey, TValue tValue)
    {
        var result = base.TryAdd(tKey, tValue);
        if (!result) return result;
        
        OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, new KeyValuePair<TKey, TValue>(tKey, tValue)));
        
        OnPropertyChanged(nameof(Keys));
        OnPropertyChanged(nameof(Values));
        OnPropertyChanged(nameof(Count));
        
        return result;


    }

    public new bool Remove(TKey tKey)
    {
        var result = base.Remove(tKey);
        if (!result) return result;
        
        OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, new KeyValuePair<TKey, TValue>(tKey, this[tKey])));
        
        OnPropertyChanged(nameof(Keys));
        OnPropertyChanged(nameof(Values));
        OnPropertyChanged(nameof(Count));
        
        return result;
    }
    
    public new TValue this[TKey key]
    {
        get => base[key];
        set
        {
            var result = base.TryGetValue(key, out var oldValue);
            base[key] = value;
            if (result)
            {
                OnCollectionChanged( new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, new KeyValuePair<TKey, TValue>(key, value), new KeyValuePair<TKey, TValue>(key, oldValue)));
                OnPropertyChanged(nameof(Values));
            }
            else
            {
                OnCollectionChanged( new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, new KeyValuePair<TKey, TValue>(key, value)));
                
                OnPropertyChanged(nameof(Keys));
                OnPropertyChanged(nameof(Values));
                OnPropertyChanged(nameof(Count));
            }
        }
    }






}