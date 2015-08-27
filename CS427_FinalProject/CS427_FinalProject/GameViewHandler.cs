using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
            SpriteBatch spriteBatch = param as SpriteBatch;
            spriteBatch.DrawString(Global.gDefaultMediumFont, characters.ListCharacters[0].Point.ToString(), new Vector2(5, 0), Color.Black, 0f, Vector2.Zero, 1f, SpriteEffects.None, 1f);
            spriteBatch.DrawString(Global.gDefaultMediumFont, characters.ListCharacters[1].Point.ToString(), new Vector2(1240, 0), Color.Black, 0f, Vector2.Zero, 1f, SpriteEffects.None, 1f);
        }
    }
}
