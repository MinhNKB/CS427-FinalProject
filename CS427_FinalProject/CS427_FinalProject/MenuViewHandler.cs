using CS427_FinalProject.Buttons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS427_FinalProject
{
    class MenuViewHandler : ViewHandler
    {
        protected Sprite2D background;
        protected List<Button> buttons;
        public MenuViewHandler()
        {
            background = new Sprite2D(TextureFactory.menuBackgroundTexture, 0, 0, 0, 0);
            background.Depth = 0f;
            buttons = new List<Button>();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            background.Update(gameTime);
            foreach (Button button in buttons)
                button.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, object param)
        {
            background.Draw(gameTime,param as SpriteBatch);
            foreach (Button button in buttons)
                button.Draw(gameTime, param as SpriteBatch);
        }
    }
}
