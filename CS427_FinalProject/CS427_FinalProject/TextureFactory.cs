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
        public static List<Texture2D> boxTexture;

        public static void Load()
        {
            LoadBackgroundTexture();
            LoadCharacterTextures();
            LoadMapTileTextures();
            LoadBoxTexture();
        }

        private static void LoadBoxTexture()
        {
            boxTexture = new List<Texture2D>();
            boxTexture.Add(Global.gContent.Load<Texture2D>(@"Textures\Maps\Forrest\Box\Box_00"));
        }

        private static void LoadMapTileTextures()
        {
            mapTileTextures = new List<List<Texture2D>>();
            for (int i = 0; i < 18; ++i)
            {
                List<Texture2D> tmp = new List<Texture2D>();
                tmp.Add(Global.gContent.Load<Texture2D>(@"Textures\Maps\Forrest\Tiles\Tile_" + i.ToString("00")));
                mapTileTextures.Add(tmp);
            }
        }

        private static void LoadCharacterTextures()
        {
            characterTextures = new Dictionary<CharacterTexture, Dictionary<CharacterState, List<Texture2D>>>();
            LoadDogTextures();
            LoadCatTextures();
        }

        private static void LoadCatTextures()
        {
            Dictionary<CharacterState, List<Texture2D>> textures = LoadCharacterTextures("Cat");
            characterTextures.Add(CharacterTexture.Cat, textures);
        }

        private static void LoadDogTextures()
        {           
            Dictionary<CharacterState, List<Texture2D>> textures = LoadCharacterTextures("Dog");
            characterTextures.Add(CharacterTexture.Dog, textures);
        }

        private static Dictionary<CharacterState, List<Texture2D>> LoadCharacterTextures(string s)
        {
            Dictionary<CharacterState, List<Texture2D>> textures = new Dictionary<CharacterState, List<Texture2D>>();
            for (int i = 0; i < 5; i++)
            {
                CharacterState state = (CharacterState)i;
                List<Texture2D> temp = new List<Texture2D>();
                int count;
                if (state == CharacterState.Idle || state == CharacterState.Dead)
                    count = 10;
                else
                    count = 8;
                for (int j = 0; j < count; j++)
                {
                    temp.Add(Global.gContent.Load<Texture2D>(@"Textures\Characters\" + s + "\\" + state.ToString() + @"\" + state.ToString() + "_" + j.ToString("00")));
                }
                textures.Add(state, temp);
            }
            return textures;
        }

        private static void LoadBackgroundTexture()
        {
            backgroundTexture = new List<Texture2D>();
            backgroundTexture.Add(Global.gContent.Load<Texture2D>(@"Textures\Maps\Forrest\Background\Background_00"));
        }
    }
}
