
namespace MangalaGameProject
{
    class RulesScreen : MenuScreen
    {
        public RulesScreen()
            : base("Oyun Kuralları")
        {
            MenuEntry howToMenuEntry = new MenuEntry("Nasıl Oynanır ? ");
            MenuEntry ruleMenuEntry1 = new MenuEntry("4 Temel Kural");
            MenuEntry ruleMenuEntry2 = new MenuEntry("Diğer Kurallar");
            MenuEntry backMenuEntry = new MenuEntry("Geri");

            ruleMenuEntry1.Selected += RuleMenuEntry1Selected;
            howToMenuEntry.Selected += HowToMenuEntrySelected;
            backMenuEntry.Selected += OnCancel;

            MenuEntries.Add(howToMenuEntry);
            MenuEntries.Add(ruleMenuEntry1);
            MenuEntries.Add(ruleMenuEntry2);
            MenuEntries.Add(backMenuEntry);
        }

        void RuleMenuEntry1Selected(object sender, PlayerIndexEventArgs e)
        {
            ScreenManager.AddScreen(new RuleScreen1(), e.PlayerIndex);
        }

        void HowToMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            ScreenManager.AddScreen(new HowTo(), e.PlayerIndex);
        }


    }
}
