using CS427_FinalProject.Buttons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS427_FinalProject
{
    class PauseView : MenuViewHandler
    {
        public PauseView()
        {
            AddButtons();
            AddEvents();
        }

        private void AddEvents()
        {
            this.buttons[1].Click += ReloadBtn_Click;
            this.buttons[2].Click += ResumeBtn_Click;
        }

        void ReloadBtn_Click(object sender, EventArgs e)
        {
            Global.gViewState = ViewState.NewGameView;
        }

        void ResumeBtn_Click(object sender, EventArgs e)
        {
            Global.gViewState = ViewState.GameView;
        }

        private void AddButtons()
        {
            this.buttons.Add(new Menu(316, 430));
            this.buttons.Add(new Reload(486, 430));
            this.buttons.Add(new Resume(656, 430));
            this.buttons.Add(new Setting(826, 430));
        }
        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime, object param)
        {
            Global.gViewHandlers[ViewState.GameView].Draw(gameTime, param);
            //base.Draw(gameTime, param);
            foreach (Button button in buttons)
                button.Draw(gameTime, param);      
            SpriteBatch spriteBatch = param as SpriteBatch;
            spriteBatch.DrawString(Global.gDefaultExtraLargeFont, "Paused", new Vector2(390, 180), Color.FromNonPremultiplied(206, 235, 12, 255), 0f, Vector2.Zero, 1f, SpriteEffects.None, 1);
        }
    }
}
