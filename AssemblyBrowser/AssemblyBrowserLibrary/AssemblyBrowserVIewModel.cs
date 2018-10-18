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
        private string _resultString;

        public AssemblyBrowserVIewModel()
        {
            _asmReader = new AssemblyReader();
        }

        public AssemblyBrowserResult Result
        {
            get { return _result; }
            set
            {
                _result = value;
                OnPropertyChanged();
            }
        }

        public string OutputString
        {
            get { return _resultString; }
            set
            {
                if (_resultString != value)
                {
                    _resultString = value;
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

        private void NamespacesToString()
        {
            string res = "";
            foreach (var ns in _result.namespaces)
            {
                res += $"{ns.name}:\n";
                foreach (var dataType in ns.dataTypes)
                {
                    res += $"  {dataType.name}:\n";
                    foreach (var field in dataType.fields)
                    {
                        res += $"    Field: {field.type} {field.name}\n";
                    }

                    foreach (var property in dataType.properties)
                    {
                        res += $"    Property: {property.type} {property.name}\n";
                    }

                    foreach (var method in dataType.methods)
                    {
                        res += $"    Method: {method.signature}\n";
                    }
                }
            }

            OutputString = res;
        }
    }
}
