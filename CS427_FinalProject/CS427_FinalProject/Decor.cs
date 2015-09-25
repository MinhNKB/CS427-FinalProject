using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS427_FinalProject
{
    class Decor : VisibleGameEntity
    {
        private Sprite2D sprite2D;

        public Sprite2D Sprite2D
        {
            get { return sprite2D; }
            set { sprite2D = value; }
        }

        public Decor(float left, float top, float depth, int type)
        {
            this.sprite2D = new Sprite2D(TextureFactory.decorTextures[Global.gMapState][type], left, top - TextureFactory.decorTextures[Global.gMapState][type][0].Height, 0, 0);
            this.sprite2D.Depth = depth;
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
