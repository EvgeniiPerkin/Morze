using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Morze
{
    public  class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            Abc = new ABCMorze();
        }
        private ABCMorze abc;
        public ABCMorze Abc
        {
            get => abc;
            set
            {
                abc = value;
                OnPropertyChanged("Abc");
            }
        }
        
        private RelayCommand updateList;

        public RelayCommand GetUpdateList()
        {
            return updateList ??
              (updateList = new RelayCommand(obj =>
              {
                  Abc.Test();  
              }));
        }
        //*********************************************************
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
