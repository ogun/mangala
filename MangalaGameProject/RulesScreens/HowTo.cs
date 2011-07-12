using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Input;

namespace MangalaGameProject
{
    class HowTo : MenuScreen
    {
        ContentManager content;
        SpriteBatch _spriteBatch;

        Video _video;
        VideoPlayer _videoPlayer;

        public HowTo()
            : base("Nasıl Oynanır")                                                  
        {
            ////Geri dönüşün kolaylığının inanılmaz hafifliği
            //MenuEntry backMenuEntry = new MenuEntry("Geri");
            //backMenuEntry.Selected += OnCancel;
            //MenuEntries.Add(backMenuEntry);
        }

        public override void LoadContent()
        {
            if (content == null)
                content = new ContentManager(ScreenManager.Game.Services, "Content");

            _video = content.Load<Video>("Mangala");

            _videoPlayer = new VideoPlayer();
            _videoPlayer.Play(_video);

            ScreenManager.Game.ResetElapsedTime();
        }

        public override void Update(GameTime gameTime, bool otherScreenHasFocus,
                                               bool coveredByOtherScreen)
        {
            KeyboardState ks = Keyboard.GetState();

            if (ks.IsKeyDown(Keys.Escape))
            {
                _videoPlayer.Stop();
            }

            base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);
        }

        public override void UnloadContent()
        {
            content.Unload();
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch = ScreenManager.SpriteBatch;
            _spriteBatch.Begin();        
            _spriteBatch.Draw(_videoPlayer.GetTexture(),new Vector2(100,100), Color.White);
            _spriteBatch.End();
        }
    }
}
