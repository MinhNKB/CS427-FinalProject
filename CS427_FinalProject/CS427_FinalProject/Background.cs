using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS427_FinalProject
{
    class Background : VisibleGameEntity
    {
        private Sprite2D sprite2D;

        public Background()
        {
            this.sprite2D = new Sprite2D(TextureFactory.backgroundTexture[Global.gMapState], 0, 0, 0, 0);
            this.sprite2D.Depth = 0;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            this.sprite2D.Update(gameTime);
        }
        
        public override void Draw(GameTime gameTime, object param)
        {
            base.Draw(gameTime, param);
            this.sprite2D.Draw(gameTime, (SpriteBatch)param);
        }
        
    }
}
