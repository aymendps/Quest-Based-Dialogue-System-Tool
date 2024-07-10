using MahApps.Metro.IconPacks;

namespace QuestBasedDialogueSystemTool.Models
{
    class NavigationButtonModel
    {
        /// <summary>
        /// The name of the navigation button.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The path to the icon/image of the navigation button.
        /// </summary>
        public PackIconGameIconsKind Icon { get; set; }

        /// <summary>
        /// Whether the navigation button is currently selected.
        /// </summary>
        public bool IsSelected { get; set; }

        public NavigationButtonModel() : this("Missing Name", PackIconGameIconsKind.None, false)
        {
        }

        public NavigationButtonModel(string name, PackIconGameIconsKind icon, bool isSelected)
        {
            Name = name;
            Icon = icon;
            IsSelected = isSelected;
        }
    }
}
