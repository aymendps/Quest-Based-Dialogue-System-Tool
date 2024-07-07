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

        public MainViewModel()
        {
            Trace.WriteLine("MainViewModel created");
            _navigationButtons = new ObservableCollection<NavigationButtonViewModel>
            {
                new("NPCs", "/Assets/Icons/npc.png", true, (object parameter) =>
                {
                    Trace.WriteLine("Navigate to NPCs");
                    SelectedNavigationButtonIndex = 0;  
                }),
                new("Quests", "/Assets/Icons/quest.png", false, (object parameter) =>
                {
                    Trace.WriteLine("Navigate to Quests");
                    SelectedNavigationButtonIndex = 1;
                }),
                new("Dialogues", "/Assets/Icons/dialogue.png", false, (object parameter) =>
                {
                    Trace.WriteLine("Navigate to Dialogues");
                    SelectedNavigationButtonIndex = 2;
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
