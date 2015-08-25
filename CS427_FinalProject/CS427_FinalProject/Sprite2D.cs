using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS427_FinalProject
{
    public class Sprite2D
    {

        public Sprite2D(List<Texture2D> textures, 
            float left, float top, int width, int height)
        {
            Textures = textures;
            Left = left;
            Top = top;
            if (width == 0)
                Width = Textures[0].Width;
            else
                Width = width;

            if (height == 0)
                Height = Textures[0].Height;
            else
                Height = height;

        }

        private List<Texture2D> textures;

        public List<Texture2D> Textures
        {
            get { return textures; }
            set { 
                textures = value;
                nTextures = textures.Count;
                iTexture = 0;
            }
        }
        private int nTextures;

        public int NTextures
        {
            get { return nTextures; }
            set { nTextures = value; }
        }
        private int iTexture;

        public int ITexture
        {
            get { return iTexture; }
            set { iTexture = value; }
        }
        private float top;

        public float Top
        {
            get { return top; }
            set { top = value; }
        }
        private float left;

        public float Left
        {
            get { return left; }
            set { left = value; }
        }
        private int width;

        public int Width
        {
            get { return width; }
            set { width = value; }
        }
        private int height;

        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        private float depth = 1;

        public float Depth
        {
            get { return depth; }
            set { depth = value; }
        }

        private bool repeat = true;

        public bool Repeat
        {
            get { return repeat; }
            set { repeat = value; }
        }

        private SpriteEffects effect = SpriteEffects.None;
        private float reverseFactor = 0;

        private bool reverse = false;

        public bool Reverse
        {
            get { return reverse; }
            set {
                reverse = value;
                if(reverse==false)
                {
                    reverseFactor = 0;
                    effect = SpriteEffects.None;
                }
                else
                {
                    reverseFactor = Width - 109;
                    effect = SpriteEffects.FlipHorizontally;
                }
            }
        }


        public void Update(GameTime gameTime)
        {
            if (repeat)
                iTexture = (iTexture + 1) % (nTextures);
            else
                while (iTexture < nTextures - 1)
                    iTexture++;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

            //spriteBatch.Draw(_Textures[_iTexture], new Vector2(_Left,_Top), new Rectangle(0, 0, _Textures[_iTexture].Width, _Textures[_iTexture].Height), Color.White);
            spriteBatch.Draw(textures[iTexture], new Vector2(left - reverseFactor, top), new Rectangle(0, 0, Width, Height), Color.White, 0f, Vector2.Zero, 1, effect, depth);
        }
    }
}
