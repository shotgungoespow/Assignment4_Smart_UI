
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;



namespace Assignment4_Smart_UI.ViewModels
{
    public abstract class Base_View_Model : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;


        protected bool SetProperty<T>(ref T backingfield, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingfield, value))
            {
                return false;
            }

            backingfield = value;
            OnpropertyChanged(propertyName);
            return true;
        }

        protected void OnpropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }

}
