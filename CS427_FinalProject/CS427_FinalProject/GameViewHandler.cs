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
        private string score = "";
        private float positionScore,positionCatHead,positionDogHead;
        Sprite2D catHead, dogHead;

        public GameViewHandler()
        {
            map = new Map();
            characters = new Characters();
            catHead = new Sprite2D(TextureFactory.headTextures[CharacterTexture.Cat], 518, 0, 0, 0);
            dogHead = new Sprite2D(TextureFactory.headTextures[CharacterTexture.Dog], 705, 0, 0, 0);
            catHead.Depth = 0.1f;
            dogHead.Depth = 0.1f;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            map.Update(gameTime);
            characters.Update(gameTime);
            List<Vector4> distances = map.GetDistances(this.characters.BoundingBoxes);
            this.characters.SetDistances(distances);
            catHead.Update(gameTime);
            dogHead.Update(gameTime);

            score = characters.ListCharacters[0].Point.ToString() + " : " + characters.ListCharacters[1].Point.ToString();
            positionScore = (1280 - Global.gDefaultMediumFont.MeasureString(score).X) / 2;
            positionCatHead = positionScore - catHead.Width - 10;
            positionDogHead = positionScore + Global.gDefaultMediumFont.MeasureString(score).X + 10;
        }
        public override void Draw(GameTime gameTime, object param)
        {
            base.Draw(gameTime, param);
            map.Draw(gameTime, param);
            characters.Draw(gameTime, param);
            
            SpriteBatch spriteBatch = param as SpriteBatch;
            catHead.Draw(gameTime, spriteBatch);
            dogHead.Draw(gameTime, spriteBatch);
            spriteBatch.DrawString(Global.gDefaultMediumFont, score, new Vector2(positionScore, 0), Color.FromNonPremultiplied(206, 235, 12, 255), 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.1f);           
        }
    }
}
