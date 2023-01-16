using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proxy_server.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual void Dispose()
        {

        }

        public void ValidateProperty<T>(object Context, T value, string name)
        {
            Console.WriteLine(value);
            Validator.ValidateProperty(value, new ValidationContext(Context, null, null)
            {
                MemberName = name
            });
        }
    }
}
