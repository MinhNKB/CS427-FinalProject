using CS427_FinalProject.Buttons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS427_FinalProject
{
    class GameOverView : MenuViewHandler
    {
        public GameOverView()
        {
            this.buttons.Add(new Menu(486, 430));
            this.buttons.Add(new Reload(656, 430));
            this.buttons[1].Click += Reload_Click;
        }

        void Reload_Click(object sender, EventArgs e)
        {
            Global.gViewState = ViewState.NewGameView;
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Update(gameTime);
            foreach (Button button in buttons)
                button.Update(gameTime);
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime, object param)
        {
            Global.gViewHandlers[ViewState.GameView].Draw(gameTime, param);
            //base.Draw(gameTime, param);           
            
            SpriteBatch spriteBatch = param as SpriteBatch;
            
            spriteBatch.DrawString(Global.gDefaultExtraLargeFont, "Game Over", new Vector2(283.5f, 150), Color.FromNonPremultiplied(206, 235, 12, 255), 0f, Vector2.Zero, 1f, SpriteEffects.None, 1);
            foreach (Button button in buttons)
                button.Draw(gameTime, param);
            float left = (1280 - Global.gDefaultLargeFont.MeasureString(Global.gWinner + " win!!!").X) / 2;
            spriteBatch.DrawString(Global.gDefaultLargeFont, Global.gWinner + " win!!!", new Vector2(left, 325), Color.FromNonPremultiplied(206, 235, 12, 255), 0f, Vector2.Zero, 1f, SpriteEffects.None, 1);
        }
    }
}
