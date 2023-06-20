using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Custom_Toolkit_MVVM
{
	public class CustomObservableObject : INotifyPropertyChanged
	{
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Set property changed for a property
        /// </summary>
        /// <param name="oldValue">Base value</param>
        /// <param name="newValue">Value to set</param>
        /// <param name="comparer">The comparer use to compare value</param>
        /// <param name="propertyName">The name of the property</param>
        /// <typeparam name="T">Type of the property</typeparam>
        protected void SetPropertyChanged<T>([NotNullIfNotNull(nameof(newValue))] ref T oldValue, T newValue, IEqualityComparer<T> comparer , [CallerMemberName] string propertyName = "")
        {
            if (comparer.Equals(oldValue, newValue))
                return;

            oldValue = newValue;
            OnPropertyChanged(propertyName);

        }

        /// <summary>
        /// Set property changed for an object property (model)
        /// </summary>
        /// <typeparam name="TModel">Object (Model) type</typeparam>
        /// <typeparam name="T">Property type</typeparam>
        /// <param name="oldValue">Base value</param>
        /// <param name="newValue">Value to set</param>
        /// <param name="comparer">The comparer used to compare the values</param>
        /// <param name="model">The object (model) which contains the property</param>
        /// <param name="callback">The callback we use to assign the value to the property in the model</param>
        /// <param name="propertyName">The name of the property</param>
        /// <returns></returns>
        protected bool SetModelPropertyChanged<TModel, T>(T oldValue, T newValue, IEqualityComparer<T> comparer, TModel model, Action<TModel, T> callback, [CallerMemberName] string? propertyName = null)
                where TModel : class
        {
            ArgumentNullException.ThrowIfNull(comparer);
            ArgumentNullException.ThrowIfNull(model);
            ArgumentNullException.ThrowIfNull(callback);

            if (comparer.Equals(oldValue, newValue)) return false;

            callback(model, newValue);

            OnPropertyChanged(propertyName);

            return true;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}

