using System;
using System.ComponentModel;
using AssemblyBrowserLibrary.ResultStructure;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace AssemblyBrowserLibrary
{
    public class AssemblyBrowserVIewModel : INotifyPropertyChanged
    {
        private AssemblyBrowserResult _result;
        private AssemblyReader _asmReader;
        private RelayCommand _openCommand;

        public AssemblyBrowserVIewModel()
        {
            _asmReader = new AssemblyReader();
        }

        public AssemblyBrowserResult Result
        {
            get { return _result; }
            set
            {
                if(_result != value)
                {
                    _result = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public RelayCommand OpenCommand
        {
            get
            {
                return _openCommand ??
                    (_openCommand = new RelayCommand(obj =>
                       {
                           try
                           {
                               OpenFileDialog openFileDialog = new OpenFileDialog();
                               if (openFileDialog.ShowDialog() == DialogResult.OK)
                               {
                                   Result = _asmReader.Read(openFileDialog.FileName);
                               }
                           }
                           catch (Exception ex)
                           {
                               MessageBox.Show(ex.ToString());
                           }
                    }));
            }
        }
    }
}
