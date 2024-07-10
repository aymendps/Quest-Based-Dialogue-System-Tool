using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            _selectedContentViewModel = new NPCsViewModel();

            _navigationButtons = new ObservableCollection<NavigationButtonViewModel>
            {
                new("NPCs", "/Assets/Icons/npc.png", true, (object parameter) =>
                {
                    if(_selectedNavigationButtonIndex == 0) return;

                    SelectedNavigationButtonIndex = 0;  
                    SelectedContentViewModel = new NPCsViewModel();
                }),
                new("Quests", "/Assets/Icons/quest.png", false, (object parameter) =>
                {
                    if(_selectedNavigationButtonIndex == 1) return;

                    SelectedNavigationButtonIndex = 1;
                    SelectedContentViewModel = new QuestsViewModel();
                }),
                new("Dialogues", "/Assets/Icons/dialogue.png", false, (object parameter) =>
                {
                    if(_selectedNavigationButtonIndex == 2) return;

                    SelectedNavigationButtonIndex = 2;
                    SelectedContentViewModel = new DialoguesViewModel();
                }),
            };
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
