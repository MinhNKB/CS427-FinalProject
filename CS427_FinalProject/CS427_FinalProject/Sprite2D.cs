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

        private List<Texture2D> _Textures;

        public List<Texture2D> Textures
        {
            get { return _Textures; }
            set { 
                _Textures = value;
                _nTextures = _Textures.Count;
                _iTexture = 0;
            }
        }
        private int _nTextures;

        public int NTextures
        {
            get { return _nTextures; }
            set { _nTextures = value; }
        }
        private int _iTexture;

        public int ITexture
        {
            get { return _iTexture; }
            set { _iTexture = value; }
        }
        private float _Top;

        public float Top
        {
            get { return _Top; }
            set { _Top = value; }
        }
        private float _Left;

        public float Left
        {
            get { return _Left; }
            set { _Left = value; }
        }
        private int _Width;

        public int Width
        {
            get { return _Width; }
            set { _Width = value; }
        }
        private int _Height;

        public int Height
        {
            get { return _Height; }
            set { _Height = value; }
        }

        private float _Depth = 1;

        public float Depth
        {
            get { return _Depth; }
            set { _Depth = value; }
        }

        public void Update(GameTime gameTime)
        {
            _iTexture = (_iTexture + 1) % (_nTextures);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(_Textures[_iTexture], new Vector2(_Left,_Top), new Rectangle(0, 0, _Textures[_iTexture].Width, _Textures[_iTexture].Height), Color.White);            
        }
    }
}
