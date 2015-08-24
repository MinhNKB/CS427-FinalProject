using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS427_FinalProject
{
    class Dog : Character
    {
        public Dog()
        {
            Dictionary<CharacterState, List<Texture2D>> tmp = TextureFactory.characterTextures[CharacterTexture.Dog];
            foreach(CharacterState state in tmp.Keys)
            {
                this.characterSprites.Add(state,new Sprite2D(tmp[state], 0,0,0,0));
            }
        }
    }
}

