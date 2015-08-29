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
        public static SpriteFont gDefaultMediumFont;
        public static MapState gMapState;
        public static int gKillLimit;
       
        public static void UpdateAll(Microsoft.Xna.Framework.GameTime gameTime)
        {            
            gKeyboardHelper.Update(gameTime);
            gMousetHelper.Update(gameTime);
        }
    }
}
