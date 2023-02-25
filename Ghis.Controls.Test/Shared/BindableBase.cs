namespace Ghis.Controls.Test.Shared
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class BindableBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string? propertyName = null, [CallerLineNumber] int lineNumber = 0)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            this.RaisePropertyChanged(propertyName);

            return true;
        }
        protected virtual bool SetProperty<T>(ref T storage, T value, Action onChanged, [CallerMemberName] string propertyName = null, [CallerLineNumber] int lineNumber = 0)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            onChanged?.Invoke();
            this.RaisePropertyChanged(propertyName);
            return true;
        }

        protected void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
        {
            this.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            this.PropertyChanged?.Invoke(this, args);
        }

    }
}