using Microsoft.Xna.Framework;

namespace MangalaGameProject
{
    class OptionsMenuScreen : MenuScreen
    {
        MenuEntry languageMenuEntry;

        static string[] languages = { "English", "Turkish" };
        static int currentLanguage = 0;

        public OptionsMenuScreen()
            : base("Ayarlar")
        {
            languageMenuEntry = new MenuEntry(string.Empty);

            SetMenuEntryText();

            MenuEntry backMenuEntry = new MenuEntry("Geri");

            // Hook up menu event handlers.
            languageMenuEntry.Selected += LanguageMenuEntrySelected;
            backMenuEntry.Selected += OnCancel;
            
            // Add entries to the menu.
            MenuEntries.Add(languageMenuEntry);
            MenuEntries.Add(backMenuEntry);
        }

        void SetMenuEntryText()
        {
            languageMenuEntry.Text = "Language: " + languages[currentLanguage];
        }

        void LanguageMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            currentLanguage = (currentLanguage + 1) % languages.Length;

            SetMenuEntryText();
        }
    }
}
