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
        }

        private void AddButtons()
        {
            this.buttons.Add(new Menu(316, 291));
            this.buttons.Add(new Reload(486, 291));
            this.buttons.Add(new Resume(656, 291));
            this.buttons.Add(new Setting(826, 291));
        }
        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime, object param)
        {
            base.Draw(gameTime, param);
            SpriteBatch spriteBatch = param as SpriteBatch;
            spriteBatch.DrawString(Global.gDefaultExtraLargeFont, "Paused", new Vector2(515, 64), Color.FromNonPremultiplied(206, 235, 12, 255), 0f, Vector2.Zero, 1f, SpriteEffects.None, 1);
        }
    }
}
