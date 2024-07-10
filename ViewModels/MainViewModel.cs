using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MahApps.Metro.IconPacks;  

namespace QuestBasedDialogueSystemTool.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        private ObservableCollection<NavigationButtonViewModel> _navigationButtons;
        public ObservableCollection<NavigationButtonViewModel> NavigationButtons
        {
            get => _navigationButtons;
        }

        private int _selectedNavigationButtonIndex;
        public int SelectedNavigationButtonIndex
        {
            get => _selectedNavigationButtonIndex;
            set
            {
                _selectedNavigationButtonIndex = value;
                UpdateNavigationButtons();
                OnPropertyChanged(nameof(SelectedNavigationButtonIndex));
            }
        }

        private BaseViewModel _selectedContentViewModel;
        public BaseViewModel SelectedContentViewModel
        {
            get => _selectedContentViewModel;
            set
            {
                _selectedContentViewModel = value;
                OnPropertyChanged(nameof(SelectedContentViewModel));
            }
        }

        public MainViewModel()
        {
            _selectedContentViewModel = new QuestsViewModel();
            _selectedNavigationButtonIndex = 0;

            _navigationButtons =
            [
                new("Quests", PackIconGameIconsKind.ScrollUnfurled, true, (object parameter) =>
                {
                    if(_selectedNavigationButtonIndex == 0) return;

                    SelectedNavigationButtonIndex = 0;
                    SelectedContentViewModel = new QuestsViewModel();
                }),
                new("NPCs", PackIconGameIconsKind.Backup, false, (object parameter) =>
                {
                    if(_selectedNavigationButtonIndex == 1) return;

                    SelectedNavigationButtonIndex = 1;
                    SelectedContentViewModel = new NPCsViewModel();
                }),
                new("Dialogues", PackIconGameIconsKind.Talk, false, (object parameter) =>
                {
                    if(_selectedNavigationButtonIndex == 2) return;

                    SelectedNavigationButtonIndex = 2;
                    SelectedContentViewModel = new DialoguesViewModel();
                }),
            ];
        }

        private void UpdateNavigationButtons()
        {
            for (int i = 0; i < _navigationButtons.Count; i++)
            {
                _navigationButtons[i].IsSelected = i == _selectedNavigationButtonIndex;
            }
        }
    }
}
