using Microsoft.Xna.Framework;
using MangalaGameProject;

namespace MangalaGameProjects
{
    class MainMenuScreen : MenuScreen
    {
        public MainMenuScreen()
            : base("Ana Menü")
        {
            // Create our menu entries.
            MenuEntry playGameMenuEntry = new MenuEntry("Oyunu Baþlat");
            MenuEntry optionsMenuEntry = new MenuEntry("Ayalar");
            MenuEntry rulesMenuEntry = new MenuEntry("Kurallar");
            MenuEntry exitMenuEntry = new MenuEntry("Çýkýþ");

            // Hook up menu event handlers.
            playGameMenuEntry.Selected += PlayGameMenuEntrySelected;
            optionsMenuEntry.Selected += OptionsMenuEntrySelected;
            rulesMenuEntry.Selected += RulesMenuEntrySelected;
            exitMenuEntry.Selected += OnCancel;

            // Add entries to the menu.
            MenuEntries.Add(playGameMenuEntry);
            MenuEntries.Add(optionsMenuEntry);
            MenuEntries.Add(rulesMenuEntry);
            MenuEntries.Add(exitMenuEntry);
        }

        void PlayGameMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            LoadingScreen.Load(ScreenManager, true, e.PlayerIndex,
                               new GameplayScreen());
        }

        void RulesMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            ScreenManager.AddScreen(new RulesScreen(), e.PlayerIndex);
        }

        void OptionsMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            ScreenManager.AddScreen(new OptionsMenuScreen(), e.PlayerIndex);
        }

        protected override void OnCancel(PlayerIndex playerIndex)
        {
            const string message = "Çýkmak istediðinize emin misiniz?";

            MessageBoxScreen confirmExitMessageBox = new MessageBoxScreen(message);

            confirmExitMessageBox.Accepted += ConfirmExitMessageBoxAccepted;

            ScreenManager.AddScreen(confirmExitMessageBox, playerIndex);
        }

        void ConfirmExitMessageBoxAccepted(object sender, PlayerIndexEventArgs e)
        {
            ScreenManager.Game.Exit();
        }
    }
}
