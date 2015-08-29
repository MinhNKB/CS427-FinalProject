using CS427_FinalProject.Buttons;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS427_FinalProject
{
    class MainMenuViewHandler : MenuViewHandler
    {
        private Sprite2D logo;
        public MainMenuViewHandler()
        {
            this.buttons.Add(new Play(555, 525));
            this.buttons.Add(new Setting(369, 542));
            this.buttons.Add(new Exit(777, 542));
            logo = new Sprite2D(TextureFactory.menuLogoTexture, 0, -15, 0, 0);
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Update(gameTime);
            logo.Update(gameTime);
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime, object param)
        {
            base.Draw(gameTime, param);
            logo.Draw(gameTime, param as SpriteBatch);
        }
    }
}
