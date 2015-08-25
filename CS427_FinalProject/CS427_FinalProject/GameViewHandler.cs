using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS427_FinalProject
{
    public class GameViewHandler : ViewHandler
    {
        private Map map;
        private Characters characters;

        public GameViewHandler()
        {
            map = new Map();
            characters = new Characters();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            map.Update(gameTime);
            characters.Update(gameTime);
            List<Vector4> distances = map.GetDistances(this.characters.BoundingBoxes);
            this.characters.SetDistances(distances);
        }
        public override void Draw(GameTime gameTime, object param)
        {
            base.Draw(gameTime, param);
            map.Draw(gameTime, param);
            characters.Draw(gameTime, param);
        }
    }
}
