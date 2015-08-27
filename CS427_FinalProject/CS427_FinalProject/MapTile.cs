using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS427_FinalProject
{
    class MapTile : VisibleGameEntity
    {
        private Sprite2D sprite2D;

        public Sprite2D Sprite2D
        {
            get { return sprite2D; }
            set { sprite2D = value; }
        }

        private Vector4 boundingBox;

        public Vector4 BoundingBox
        {
            get { return boundingBox; }
            set { boundingBox = value; }
        }

        private int type;

        public int Type
        {
            get { return type; }
            set { type = value; }
        }

        public MapTile(float left, float top, float depth, int type)
        {
            this.sprite2D = new Sprite2D(TextureFactory.mapTileTextures[type], left, top, 0, 0);
            this.sprite2D.Depth = depth;
            this.boundingBox = new Vector4(left, top, left + this.sprite2D.Width, top + this.sprite2D.Height);
            this.type = type;
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
