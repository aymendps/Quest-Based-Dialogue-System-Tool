using QuestBasedDialogueSystemTool.Commands;
using QuestBasedDialogueSystemTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MahApps.Metro.IconPacks;

namespace QuestBasedDialogueSystemTool.ViewModels
{
    class NavigationButtonViewModel : BaseViewModel
    {
        private NavigationButtonModel _model;

        public string Name
        {
            get => _model.Name;
        }

        public PackIconGameIconsKind Icon
        {
            get => _model.Icon;
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

        public NavigationButtonViewModel(string name, PackIconGameIconsKind icon, bool isSelected, Action<object> navigateAction)
        {
            _model = new NavigationButtonModel(name, icon, isSelected);
            NavigateCommand = new RelayCommand<object>(navigateAction);
        }
    }
}
