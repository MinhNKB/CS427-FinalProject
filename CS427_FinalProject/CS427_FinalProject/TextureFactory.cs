using CS427_FinalProject.Buttons;
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
        public static Dictionary<CharacterTexture, List<Texture2D>> headTextures;
        public static List<Texture2D> backgroundTexture;
        public static List<List<Texture2D>> mapTileTextures;
        public static List<Texture2D> boxTexture;
        public static List<List<Texture2D>> decorTextures;
        public static List<Texture2D> menuBackgroundTexture;
        public static List<Texture2D> menuLogoTexture;
        public static Dictionary<ButtonType, Dictionary<ButtonState, List<Texture2D>>> buttonTextures;

        public static void Load()
        {
            LoadBackgroundTexture();
            LoadCharacterTextures();
            LoadMapTileTextures();
            LoadBoxTexture();
            LoadDecorTextures();
            LoadMenuBackgroundTexture();
            LoadMenuLogo();
            LoadButtonTextures();
            LoadHeadTextures();
        }

        private static void LoadHeadTextures()
        {
            headTextures = new Dictionary<CharacterTexture, List<Texture2D>>();
            for(int i=0;i<2;i++)
            {
                CharacterTexture character = (CharacterTexture)i;
                List<Texture2D> temp = new List<Texture2D>();
                temp.Add(Global.gContent.Load<Texture2D>(@"Textures\Characters\Head\Head_" + character.ToString()));
                headTextures.Add(character, temp);
            }
        }

        private static void LoadMenuLogo()
        {
            menuLogoTexture = new List<Texture2D>();
            menuLogoTexture.Add(Global.gContent.Load<Texture2D>(@"Textures\Menu\Logo\Logo"));
        }

        private static void LoadMenuBackgroundTexture()
        {
            menuBackgroundTexture = new List<Texture2D>();
            menuBackgroundTexture.Add(Global.gContent.Load<Texture2D>(@"Textures\Menu\Background\Background_00"));
        }

        private static void LoadButtonTextures()
        {
            buttonTextures = new Dictionary<ButtonType, Dictionary<ButtonState, List<Texture2D>>>();
            for(int i=0;i<16;i++)
            {
                ButtonType type = (ButtonType)i;
                buttonTextures.Add(type,GetAButton(type));
            }
        }

        private static Dictionary<ButtonState, List<Texture2D>> GetAButton(ButtonType type)
        {
            Dictionary<ButtonState, List<Texture2D>> result = new Dictionary<ButtonState, List<Texture2D>>();
            for(int i = 0;i<3;i++)
            {
                ButtonState state = (ButtonState)i;
                List<Texture2D> temp = new List<Texture2D>();
                temp.Add(Global.gContent.Load<Texture2D>(@"Textures\Menu\Buttons\Btn_"+type.ToString()+"_"+i.ToString("00")));
                result.Add(state,temp);
            }
            return result;
        }

        private static void LoadDecorTextures()
        {
            decorTextures = new List<List<Texture2D>>();
            for (int i = 0; i < 12; ++i)
            {
                List<Texture2D> tmp = new List<Texture2D>();
                tmp.Add(Global.gContent.Load<Texture2D>(@"Textures\Maps\Forrest\Decor\Decor_" + i.ToString("00")));
                decorTextures.Add(tmp);
            }
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
