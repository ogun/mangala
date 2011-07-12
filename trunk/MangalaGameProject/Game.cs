//   Oyun Baþlangýç Noktasý

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MangalaGameProject;
using MangalaGameProjects;

namespace MangalaGameProject
{
    public class Game : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        ScreenManager screenManager;

        public Game()
        {
            this.Window.Title = "Mangala - Türk Strateji ve Zeka Oyunu";
            Content.RootDirectory = "Content";

            graphics = new GraphicsDeviceManager(this);

            graphics.IsFullScreen = true;

            screenManager = new ScreenManager(this);

            Components.Add(screenManager);

            // Activate the first screens.
            screenManager.AddScreen(new BackgroundScreen(), null);
            screenManager.AddScreen(new MainMenuScreen(), null);
        }

        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.Black);
            base.Draw(gameTime);
        }
    }
}
