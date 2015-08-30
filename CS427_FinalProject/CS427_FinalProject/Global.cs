using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS427_FinalProject
{
    class Global
    {
        public static KeyboardHelper gKeyboardHelper = new KeyboardHelper();
        public static MouseHelper gMousetHelper = new MouseHelper();
        public static ViewState gViewState;
        public static ContentManager gContent;
        public static Map gMap;
        public static SpriteFont gDefaultMediumFont, gDefaultLargeFont, gDefaultExtraLargeFont;
        public static MapState gMapState;
        public static int gKillLimit;
        public static Game gGame;
        public static int gMusic = 3;
        public static int gSound = 3;
        public static ViewState gPreviousViewState;

        public static void UpdateAll(Microsoft.Xna.Framework.GameTime gameTime)
        {            
            gKeyboardHelper.Update(gameTime);
            gMousetHelper.Update(gameTime);
        }
    }
}
