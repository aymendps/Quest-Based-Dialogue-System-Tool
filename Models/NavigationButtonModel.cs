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
        public string IconPath { get; set; }

        /// <summary>
        /// Whether the navigation button is currently selected.
        /// </summary>
        public bool IsSelected { get; set; }

        public NavigationButtonModel() : this("Missing Name", "Missing Icon Path", false)
        {
        }

        public NavigationButtonModel(string name, string iconPath, bool isSelected)
        {
            Name = name;
            IconPath = iconPath;
            IsSelected = isSelected;
        }
    }
}
