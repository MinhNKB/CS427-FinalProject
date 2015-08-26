using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS427_FinalProject
{
    class Box : VisibleGameEntity
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

        private SpecialEffect effect;

        public SpecialEffect Effect
        {
            get { return effect; }
            set { effect = value; }
        }

        private bool isVisible;

        public bool IsVisible
        {
            get { return isVisible; }
            set { isVisible = value; }
        }

        public Box(float left, float top, float depth, int effect)
        {
            this.sprite2D = new Sprite2D(TextureFactory.boxTexture, left, top - TextureFactory.boxTexture[0].Height, 0, 0);
            this.sprite2D.Depth = depth;
            this.boundingBox = new Vector4(left, top, left + this.sprite2D.Width, top + this.sprite2D.Height);
            this.effect = (SpecialEffect)effect;
            this.isVisible = true;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            this.sprite2D.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, object param)
        {
            base.Draw(gameTime, param);
            if (this.isVisible)
                this.sprite2D.Draw(gameTime, (SpriteBatch)param);
        }
    }
}
