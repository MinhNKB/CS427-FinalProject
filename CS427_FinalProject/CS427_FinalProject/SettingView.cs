using CS427_FinalProject.Buttons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS427_FinalProject
{
    class SettingView : MenuViewHandler
    {
        Minus musicDown, soundDown;
        Plus musicUp, soundUp;
        

        public int SoundLevel
        {
            get { return Global.gSound; }
            set { Global.gSound = value; }
        }

        public int MusicLevel
        {
            get { return Global.gMusic; }
            set { Global.gMusic = value; }
        }
        public SettingView()
        {
            musicDown = new Minus(985, 227);
            musicUp = new Plus(1085, 227);  

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            musicDown.Update(gameTime);
            musicUp.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, object param)
        {
            base.Draw(gameTime, param);
            Vector2 length = Global.gDefaultMediumFont.MeasureString("Sound");            
            SpriteBatch spriteBatch = param as SpriteBatch;
            spriteBatch.DrawString(Global.gDefaultLargeFont, "How to play", new Vector2(102.5f, 127), Color.FromNonPremultiplied(206, 235, 12, 255), 0f, Vector2.Zero, 1f, SpriteEffects.None, 1);
            spriteBatch.DrawString(Global.gDefaultMediumFont, "Cat", new Vector2(123.5f, 227), Color.FromNonPremultiplied(206, 235, 12, 255), 0f, Vector2.Zero, 1f, SpriteEffects.None, 1);
            spriteBatch.DrawString(Global.gDefaultMediumFont, "Left: A", new Vector2(92.5f, 302), Color.FromNonPremultiplied(206, 235, 12, 255), 0f, Vector2.Zero, 1f, SpriteEffects.None, 1);
            spriteBatch.DrawString(Global.gDefaultMediumFont, "Right: D", new Vector2(75.5f, 377), Color.FromNonPremultiplied(206, 235, 12, 255), 0f, Vector2.Zero, 1f, SpriteEffects.None, 1);
            spriteBatch.DrawString(Global.gDefaultMediumFont, "Jump: W", new Vector2(70.5f, 452), Color.FromNonPremultiplied(206, 235, 12, 255), 0f, Vector2.Zero, 1f, SpriteEffects.None, 1);
            spriteBatch.DrawString(Global.gDefaultMediumFont, "Down: S", new Vector2(77, 527), Color.FromNonPremultiplied(206, 235, 12, 255), 0f, Vector2.Zero, 1f, SpriteEffects.None, 1);

            spriteBatch.DrawString(Global.gDefaultMediumFont, "Dog", new Vector2(443.5f, 227), Color.FromNonPremultiplied(206, 235, 12, 255), 0f, Vector2.Zero, 1f, SpriteEffects.None, 1);
            spriteBatch.DrawString(Global.gDefaultMediumFont, "Left: Left", new Vector2(393.5f, 302), Color.FromNonPremultiplied(206, 235, 12, 255), 0f, Vector2.Zero, 1f, SpriteEffects.None, 1);
            spriteBatch.DrawString(Global.gDefaultMediumFont, "Right: Right", new Vector2(357.5f, 377), Color.FromNonPremultiplied(206, 235, 12, 255), 0f, Vector2.Zero, 1f, SpriteEffects.None, 1);
            spriteBatch.DrawString(Global.gDefaultMediumFont, "Jump: Up", new Vector2(382, 452), Color.FromNonPremultiplied(206, 235, 12, 255), 0f, Vector2.Zero, 1f, SpriteEffects.None, 1);
            spriteBatch.DrawString(Global.gDefaultMediumFont, "Down: Down", new Vector2(351.5f, 527), Color.FromNonPremultiplied(206, 235, 12, 255), 0f, Vector2.Zero, 1f, SpriteEffects.None, 1);

            spriteBatch.DrawString(Global.gDefaultLargeFont, "Audio", new Vector2(897, 127), Color.FromNonPremultiplied(206, 235, 12, 255), 0f, Vector2.Zero, 1f, SpriteEffects.None, 1);
            spriteBatch.DrawString(Global.gDefaultMediumFont, "Music", new Vector2(806, 227), Color.FromNonPremultiplied(206, 235, 12, 255), 0f, Vector2.Zero, 1f, SpriteEffects.None, 1);
            spriteBatch.DrawString(Global.gDefaultMediumFont, "Sound", new Vector2(808, 302), Color.FromNonPremultiplied(206, 235, 12, 255), 0f, Vector2.Zero, 1f, SpriteEffects.None, 1);
            musicDown.Draw(gameTime, param);
            musicUp.Draw(gameTime, param);
        }
    }
}













