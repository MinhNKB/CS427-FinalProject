using CS427_FinalProject.Buttons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS427_FinalProject
{
    class NewGameViewHandler : MenuViewHandler
    {
        public event EventHandler AcceptBtn_Click;

        private void OnAcceptBtn_Click()
        {
            if (AcceptBtn_Click != null)
                AcceptBtn_Click(this, new EventArgs());
        }

        public NewGameViewHandler()
        {
            AddButtons();
            AddEvents();
            this.buttons[0].CurrentState = ButtonState.Locked;
            Global.gKillLimit = 1;
        }

        private void AddEvents()
        {
            this.buttons[0].Click += AccpetButton_Click;
            this.buttons[2].Click += ForrestMapButton_Click;
            this.buttons[3].Click += SnowMapButton_Click;
            this.buttons[4].Click += MinusButton_Click;
            this.buttons[5].Click += PlusButton_Click;
        }

        private void PlusButton_Click(object sender, EventArgs e)
        {
            if (Global.gKillLimit < 90)
                Global.gKillLimit += 10;
        }

        private void MinusButton_Click(object sender, EventArgs e)
        {
            if (Global.gKillLimit > 10)
                Global.gKillLimit -= 10;
        }

        private void AccpetButton_Click(object sender, EventArgs e)
        {
            OnAcceptBtn_Click();
        }

        private void SnowMapButton_Click(object sender, EventArgs e)
        {
            this.buttons[3].CurrentState = ButtonState.Locked;
            this.buttons[2].CurrentState = ButtonState.Normal;
            this.buttons[0].CurrentState = ButtonState.Normal;
        }

        private void ForrestMapButton_Click(object sender, EventArgs e)
        {
            this.buttons[2].CurrentState = ButtonState.Locked;
            this.buttons[3].CurrentState = ButtonState.Normal;
            this.buttons[0].CurrentState = ButtonState.Normal;
        }

        private void AddButtons()
        {
            this.buttons.Add(new Accept(672, 542));
            this.buttons.Add(new Menu(470, 542));
            this.buttons.Add(new MapButton(96, 32, ButtonType.ForrestMap));
            this.buttons.Add(new MapButton(672, 32, ButtonType.SnowMap));
            this.buttons.Add(new Minus(552, 418));
            this.buttons.Add(new Plus(672, 418));
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime, object param)
        {
            base.Draw(gameTime, param);
            SpriteBatch spriteBatch = param as SpriteBatch;
            spriteBatch.DrawString(Global.gDefaultMediumFont, "Points to win", new Vector2(506.5f, 352), Color.FromNonPremultiplied(206, 235, 12, 255), 0f, Vector2.Zero, 1f, SpriteEffects.None, 1);
            spriteBatch.DrawString(Global.gDefaultMediumFont, Global.gKillLimit.ToString(), new Vector2(612.5f, 418), Color.FromNonPremultiplied(206, 235, 12, 255), 0f, Vector2.Zero, 1f, SpriteEffects.None, 1);
            
        }
    }
}
