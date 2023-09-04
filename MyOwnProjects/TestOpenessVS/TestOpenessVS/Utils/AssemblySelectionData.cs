using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiaOpennessHelper.Utils;

namespace TestOpenessVS.Utils
{
    class AssemblySelectionData
    {
        
        private  ObservableCollection<string> _engineeringVersions = new ObservableCollection<string>();
        private  ObservableCollection<string> _assemblyVersions = new ObservableCollection<string>();
        private  string _selectedVersion;
        private  string _selectedAssembly;
        private  bool _hide;

        public  ObservableCollection<string> EngineeringVersions
        {
            get { return _engineeringVersions; }
            set
            {
                _engineeringVersions = value;
            }
        }

        public  ObservableCollection<string> AssemblyVersions
        {
            get { return _assemblyVersions; }
            set
            {
                _assemblyVersions = value;
            }
        }

        public  string SelectedVersion
        {
            get { return _selectedVersion; }
            set
            {
                _selectedVersion = value;
                SelectedAssembly = null;
            }
        }

        public string SelectedAssembly
        {
            get { return _selectedAssembly; }
            set
            {
                _selectedAssembly = value;
                //UpdateCommands();
            }
        }

        private Nullable<bool> _dialogResult;
        public Nullable<bool> DialogResult
        {
            get { return _dialogResult; }
            set
            {
                _dialogResult = value;
            }
        }

        public string Result;

        // public RelayCommand<EventArgs> ConfirmationCommand => new RelayCommand<EventArgs>(OnConfirmation, CanConfirm);
        public void OnConfirmation(EventArgs args)
        {
            if (CanConfirm())
            {
                Result = Resolver.GetAssemblyPath(SelectedVersion, SelectedAssembly);
                DialogResult = true;
            }
        }
        private bool CanConfirm()
        {
            return string.IsNullOrEmpty(SelectedVersion) == false
                && string.IsNullOrEmpty(SelectedAssembly) == false;
        }

        //public RelayCommand<EventArgs> GetVersionsCommand => new RelayCommand<EventArgs>(OnGetVersions);
        public void OnGetVersions(EventArgs args)
        {
            EngineeringVersions = new ObservableCollection<string>(Resolver.GetEngineeringVersions());
        }

        // public RelayCommand<EventArgs> GetAssembliesCommand => new RelayCommand<EventArgs>(OnGetAssemblies);
        public void OnGetAssemblies(EventArgs args)
        {
            if (string.IsNullOrEmpty(SelectedVersion)) return;
            AssemblyVersions = new ObservableCollection<string>(Resolver.GetAssmblies(SelectedVersion));
        }

    }
}
