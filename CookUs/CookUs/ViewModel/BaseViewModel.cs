using CookUs.Model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CookUs.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public IDataStore DataStore => DependencyService.Get<IDataStore>();

        public string Title { get; set; }
        
        private bool _isRefreshing;
        public bool IsRefreshing 
        { 
            get => _isRefreshing; 
            set { 
                if (_isRefreshing == value) 
                    return; 
                _isRefreshing = value; 
                OnPropertyChanged(); 
            } 
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
