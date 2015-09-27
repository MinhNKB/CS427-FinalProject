using CS427_FinalProject.Buttons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
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
        Back back;

        public int SoundLevel
        {
            get { return Global.gSound; }
            set {                 
                Global.gSound = value;
                if (Global.gSound > 5)
                    Global.gSound = 5;
                else if (Global.gSound < 0)
                    Global.gSound = 0;

                if (Global.gSound == 0)
                    soundDown.CurrentState = ButtonState.Locked;
                else
                    soundDown.CurrentState = ButtonState.Normal;
                if (Global.gSound == 5)
                    soundUp.CurrentState = ButtonState.Locked;
                else
                    soundUp.CurrentState = ButtonState.Normal;
            }
        }

        public int MusicLevel
        {
            get { return Global.gMusic; }
            set { 
                Global.gMusic = value;
                if (Global.gMusic > 5)
                    Global.gMusic = 5;
                else if (Global.gMusic < 0)
                    Global.gMusic = 0;
                MediaPlayer.Volume = Global.gMusic * 0.2f;
                if (Global.gMusic == 0)
                    musicDown.CurrentState = ButtonState.Locked;
                else
                    musicDown.CurrentState = ButtonState.Normal;
                if (Global.gMusic == 5)
                    musicUp.CurrentState = ButtonState.Locked;
                else
                    musicUp.CurrentState = ButtonState.Normal;
             

            }
        }
        public SettingView()
        {
            musicDown = new Minus(985, 177);
            musicUp = new Plus(1100, 177);
            soundDown = new Minus(985, 252);
            soundUp = new Plus(1100, 252);

            musicDown.Click += musicDown_Click;
            musicUp.Click += musicUp_Click;
            soundUp.Click += soundUp_Click;
            soundDown.Click += soundDown_Click;

            back = new Back(571, 550);
            back.Click += back_Click;
        }

        void back_Click(object sender, EventArgs e)
        {
            Global.gViewState = Global.gPreviousViewState;
        }

        void soundDown_Click(object sender, EventArgs e)
        {
            SoundLevel--;
        }

        void soundUp_Click(object sender, EventArgs e)
        {
            SoundLevel++;
        }

        void musicUp_Click(object sender, EventArgs e)
        {
            MusicLevel++;
        }

        void musicDown_Click(object sender, EventArgs e)
        {
            MusicLevel--;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            musicDown.Update(gameTime);
            musicUp.Update(gameTime);
            soundDown.Update(gameTime);
            soundUp.Update(gameTime);
            back.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, object param)
        {
            base.Draw(gameTime, param);
            Vector2 length = Global.gDefaultMediumFont.MeasureString("3");            
            SpriteBatch spriteBatch = param as SpriteBatch;
            spriteBatch.DrawString(Global.gDefaultLargeFont, "How to play", new Vector2(102.5f, 77), Color.FromNonPremultiplied(206, 235, 12, 255), 0f, Vector2.Zero, 1f, SpriteEffects.None, 1);
            spriteBatch.DrawString(Global.gDefaultMediumFont, "Cat", new Vector2(123.5f, 177), Color.FromNonPremultiplied(206, 235, 12, 255), 0f, Vector2.Zero, 1f, SpriteEffects.None, 1);
            spriteBatch.DrawString(Global.gDefaultMediumFont, "Left: A", new Vector2(92.5f, 252), Color.FromNonPremultiplied(206, 235, 12, 255), 0f, Vector2.Zero, 1f, SpriteEffects.None, 1);
            spriteBatch.DrawString(Global.gDefaultMediumFont, "Right: D", new Vector2(75.5f, 327), Color.FromNonPremultiplied(206, 235, 12, 255), 0f, Vector2.Zero, 1f, SpriteEffects.None, 1);
            spriteBatch.DrawString(Global.gDefaultMediumFont, "Jump: W", new Vector2(70.5f, 402), Color.FromNonPremultiplied(206, 235, 12, 255), 0f, Vector2.Zero, 1f, SpriteEffects.None, 1);
            spriteBatch.DrawString(Global.gDefaultMediumFont, "Down: S", new Vector2(77, 477), Color.FromNonPremultiplied(206, 235, 12, 255), 0f, Vector2.Zero, 1f, SpriteEffects.None, 1);

            spriteBatch.DrawString(Global.gDefaultMediumFont, "Dog", new Vector2(443.5f, 177), Color.FromNonPremultiplied(206, 235, 12, 255), 0f, Vector2.Zero, 1f, SpriteEffects.None, 1);
            spriteBatch.DrawString(Global.gDefaultMediumFont, "Left: Left", new Vector2(393.5f, 252), Color.FromNonPremultiplied(206, 235, 12, 255), 0f, Vector2.Zero, 1f, SpriteEffects.None, 1);
            spriteBatch.DrawString(Global.gDefaultMediumFont, "Right: Right", new Vector2(357.5f, 327), Color.FromNonPremultiplied(206, 235, 12, 255), 0f, Vector2.Zero, 1f, SpriteEffects.None, 1);
            spriteBatch.DrawString(Global.gDefaultMediumFont, "Jump: Up", new Vector2(382, 402), Color.FromNonPremultiplied(206, 235, 12, 255), 0f, Vector2.Zero, 1f, SpriteEffects.None, 1);
            spriteBatch.DrawString(Global.gDefaultMediumFont, "Down: Down", new Vector2(351.5f, 477), Color.FromNonPremultiplied(206, 235, 12, 255), 0f, Vector2.Zero, 1f, SpriteEffects.None, 1);

            spriteBatch.DrawString(Global.gDefaultLargeFont, "Audio", new Vector2(897, 77), Color.FromNonPremultiplied(206, 235, 12, 255), 0f, Vector2.Zero, 1f, SpriteEffects.None, 1);
            spriteBatch.DrawString(Global.gDefaultMediumFont, "Music", new Vector2(806, 177), Color.FromNonPremultiplied(206, 235, 12, 255), 0f, Vector2.Zero, 1f, SpriteEffects.None, 1);
            spriteBatch.DrawString(Global.gDefaultMediumFont, "Sound", new Vector2(808, 252), Color.FromNonPremultiplied(206, 235, 12, 255), 0f, Vector2.Zero, 1f, SpriteEffects.None, 1);
            musicDown.Draw(gameTime, param);
            spriteBatch.DrawString(Global.gDefaultMediumFont, MusicLevel.ToString(), new Vector2(1057, 177), Color.FromNonPremultiplied(206, 235, 12, 255), 0f, Vector2.Zero, 1f, SpriteEffects.None, 1);
            musicUp.Draw(gameTime, param);
            soundDown.Draw(gameTime, param);
            spriteBatch.DrawString(Global.gDefaultMediumFont, SoundLevel.ToString(), new Vector2(1057, 252), Color.FromNonPremultiplied(206, 235, 12, 255), 0f, Vector2.Zero, 1f, SpriteEffects.None, 1);
            soundUp.Draw(gameTime, param);

            back.Draw(gameTime,param);
        }
    }
}













