using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS427_FinalProject
{
    class Map : VisibleGameEntity
    {
        private Background background;

        private MapTiles mapTiles;

        public Map()
        {
            this.background = new Background();
            this.mapTiles = new MapTiles();
        }
        private Vector4 GetDistance(Vector4 boundingBox)
        {
            //need to be changed
            return new Vector4(100, 100, 100, 0);
        }

        public List<Vector4> GetDistance(List<Vector4> boundingBoxes)
        {
            List<Vector4> result = new List<Vector4>();
            for (int i = 0; i < boundingBoxes.Count; ++i)
                result.Add(GetDistance(boundingBoxes[i]));
            return result;
        }

        private SpecialEffect GetEffect(Vector4 boundingBox)
        {
            //need to be changed
            return SpecialEffect.None;
        }

        public List<SpecialEffect> GetEffects(List<Vector4> boudingBoxes)
        {
            List<SpecialEffect> result = new List<SpecialEffect>();
            for (int i = 0; i < boudingBoxes.Count; ++i)
                result.Add(GetEffect(boudingBoxes[i]));
            return result;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            this.background.Update(gameTime);
            this.mapTiles.Update(gameTime);

        }

        public override void Draw(GameTime gameTime, object param)
        {
            base.Draw(gameTime, param);
            this.background.Draw(gameTime, param);
            this.mapTiles.Draw(gameTime, param);
        }

    }
}
