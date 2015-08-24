using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS427_FinalProject
{
    enum CharacterTexture
    {
        Cat = 0,
        Dog = 1
    }
    class TextureFactory
    {
        public static Dictionary<CharacterTexture, Dictionary<CharacterState, List<Texture2D>>> characterTextures;

        public static List<Texture2D> backgroundTexture;
        public static List<List<Texture2D>> mapTileTextures;

        public static void Load()
        {
            LoadBackgroundTextures();
            LoadCharacterTextures();
        }

        private static void LoadCharacterTextures()
        {
            characterTextures = new Dictionary<CharacterTexture, Dictionary<CharacterState, List<Texture2D>>>();
            LoadDogTextures();
            //LoadCatTextures();
        }

        private static void LoadDogTextures()
        {
            Dictionary<CharacterState, List<Texture2D>> textures = new Dictionary<CharacterState, List<Texture2D>>();
            for (int i = 0; i < 4; i++)
            {
                CharacterState state = (CharacterState)i;
                List<Texture2D> temp = new List<Texture2D>();
                int count;
                if (state == CharacterState.Idle)
                    count = 10;
                else
                    count = 8;
                for (int j = 0; j < count; j++)
                {
                    temp.Add(Global.gContent.Load<Texture2D>(@"Textures\Characters\Dog\" + state.ToString() + @"\" + state.ToString() + "_" + j.ToString("00")));
                }
                textures.Add(state, temp);
            }
            characterTextures.Add(CharacterTexture.Dog, textures);
        }

        private static void LoadBackgroundTextures()
        {
            backgroundTexture = new List<Texture2D>();
            backgroundTexture.Add(Global.gContent.Load<Texture2D>(@"Textures\Maps\Snow\Background\Background_00"));
        }
    }
}
