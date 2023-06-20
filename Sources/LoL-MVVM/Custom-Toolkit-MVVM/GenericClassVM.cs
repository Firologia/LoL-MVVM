using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Custom_Toolkit_MVVM
{
	public class GenericClassVM<T> : CustomObservableObject
	{

        public event PropertyChangedEventHandler? PropertyChanged;

        protected T model;

        protected GenericClassVM(T model)
		{
			this.model = model;
		}

	}
}

