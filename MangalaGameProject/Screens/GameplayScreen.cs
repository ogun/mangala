using System;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace MangalaGameProject
{
    class GameplayScreen : GameScreen
    {
        ContentManager content;
        SpriteFont gameFont; // Oyunun fontunu belirliyoruz

        Random random = new Random();

        Rectangle gameWindow;// Oyun penceresinin sýnýrlarý

        List<Texture2D> BlueBall = new List<Texture2D>(); // Çukurlar içerisindeki mavi toplar olucak
        Texture2D RedBall; // Baþlangýçta þekil yaparsak el içinde kýrmýzý top seçtiririz

        Vector2 Location = Vector2.Zero;

        private List<Player> player = new List<Player>(2);  // Ýki oyuncu yarattým

        public GameplayScreen()
        {
            int player = random.Next(0, 2); // Kimin baþlayacaðýný seçiyoruz

            Thread.Sleep(300);

            TransitionOnTime = TimeSpan.FromSeconds(1.5);
            TransitionOffTime = TimeSpan.FromSeconds(0.5);
        }

        public override void LoadContent()
        {
            if (content == null)
                content = new ContentManager(ScreenManager.Game.Services, "Content");

            gameWindow = new Rectangle(0, 0, 800, 600); // Oyunun sýnýrlarýný çiziyorum

            gameFont = content.Load<SpriteFont>("gamefont");

            for (int i = 0; i < 48; i++)
                BlueBall.Add(content.Load<Texture2D>("Sprites/Blue Ball"));

            RedBall = content.Load<Texture2D>("Sprites/Red Ball");

            Thread.Sleep(1000);

            ScreenManager.Game.ResetElapsedTime();
        }

        public override void UnloadContent()
        {
            content.Unload();
        }

        public override void Update(GameTime gameTime, bool otherScreenHasFocus,
                                                       bool coveredByOtherScreen)
        {
            KeyboardState ks = Keyboard.GetState();

            if (ks.IsKeyDown(Keys.Up))
                Location.Y -= 3;
            if (ks.IsKeyDown(Keys.Down))
                Location.Y += 3;
            if (ks.IsKeyDown(Keys.Left))
                Location.X -= 3;
            if (ks.IsKeyDown(Keys.Right))
                Location.X += 3;

            base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);
        }

        public override void HandleInput(InputState input)
        {
            if (input == null)
                throw new ArgumentNullException("input");

            // Look up inputs for the active player profile.
            int playerIndex = (int)ControllingPlayer.Value;

            KeyboardState keyboardState = input.CurrentKeyboardStates[playerIndex];
            GamePadState gamePadState = input.CurrentGamePadStates[playerIndex];

            bool gamePadDisconnected = !gamePadState.IsConnected &&
                                       input.GamePadWasConnected[playerIndex];

            if (input.IsPauseGame(ControllingPlayer) || gamePadDisconnected)
            {
                ScreenManager.AddScreen(new PauseMenuScreen(), ControllingPlayer);
            }
            else
            {
                // Otherwise move the player position.
                Vector2 movement = Vector2.Zero;

                if (keyboardState.IsKeyDown(Keys.Left))
                    movement.X--;

                if (keyboardState.IsKeyDown(Keys.Right))
                    movement.X++;

                if (keyboardState.IsKeyDown(Keys.Up))
                    movement.Y--;

                if (keyboardState.IsKeyDown(Keys.Down))
                    movement.Y++;

                Vector2 thumbstick = gamePadState.ThumbSticks.Left;

                movement.X += thumbstick.X;
                movement.Y -= thumbstick.Y;

                if (movement.Length() > 1)
                    movement.Normalize();
            }
        }

        public override void Draw(GameTime gameTime)
        {
            ScreenManager.GraphicsDevice.Clear(ClearOptions.Target,
                                               Color.Black, 0, 0);

            SpriteBatch spriteBatch = ScreenManager.SpriteBatch;

            spriteBatch.Begin();

            int x = 0;
            for (int i = 0; i < 48; i++)
            {
                spriteBatch.Draw(BlueBall[10], new Vector2(Location.X+x,Location.Y), Color.White);
                x = x + 18;
            }

            spriteBatch.End();

            if (TransitionPosition > 0)
                ScreenManager.FadeBackBufferToBlack(255 - TransitionAlpha);
        }

    }
}
