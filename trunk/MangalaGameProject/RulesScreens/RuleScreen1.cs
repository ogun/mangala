using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Content;

namespace MangalaGameProject
{
    class RuleScreen1 : MenuScreen
    {
        ContentManager content;
        SpriteFont gameFont;
        SpriteBatch _spriteBatch;

        Vector2 rulePosition = new Vector2(80, 100);

        public RuleScreen1()
            : base("Kural - 1 - ")                                                  
        {
     
            //Geri dönüşün kolaylığının inanılmaz hafifliği
            MenuEntry backMenuEntry = new MenuEntry("Geri");
            backMenuEntry.Selected += OnCancel;
            MenuEntries.Add(backMenuEntry);

        }

        public override void LoadContent()
        {
            if (content == null)
                content = new ContentManager(ScreenManager.Game.Services, "Content");

            gameFont = content.Load<SpriteFont>("rulesfont");

            ScreenManager.Game.ResetElapsedTime();
        }

        public override void UnloadContent()
        {
            content.Unload();
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch = ScreenManager.SpriteBatch;
            _spriteBatch.Begin();
            _spriteBatch.DrawString(gameFont, "1- Her oyuncunun 24 adet taşı vardır ve her oyuncu kendi önündeki 6 çukura\n bu taşları 4 erli şekilde koyar.", rulePosition, Color.White);
            _spriteBatch.End();
        }
    }

}
