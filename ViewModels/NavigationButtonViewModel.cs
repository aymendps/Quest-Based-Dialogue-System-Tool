using QuestBasedDialogueSystemTool.Commands;
using QuestBasedDialogueSystemTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuestBasedDialogueSystemTool.ViewModels
{
    class NavigationButtonViewModel : BaseViewModel
    {
        private NavigationButtonModel _model;

        public string Name
        {
            get => _model.Name;
        }

        public string IconPath
        {
            get => _model.IconPath;
        }

        public bool IsSelected
        {
            get => _model.IsSelected;
            set
            {
                _model.IsSelected = value;
                OnPropertyChanged(nameof(IsSelected));
            }
        }

        /// <summary>
        /// Command used to navigate to the corresponding view
        /// </summary>
        public ICommand NavigateCommand { get; }

        public NavigationButtonViewModel(string name, string iconPath, bool isSelected, Action<object> navigateAction)
        {
            _model = new NavigationButtonModel(name, iconPath, isSelected);
            NavigateCommand = new RelayCommand<object>(navigateAction);
        }
    }
}
