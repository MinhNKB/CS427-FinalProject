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
            Vector4 result = new Vector4();
            result.X = GetLeftDistance(boundingBox);
            result.Y = GetTopDistance(boundingBox);
            result.Z = GetRightDistance(boundingBox);
            result.W = GetBottomDistance(boundingBox);
            return result;
        }

        private float GetBottomDistance(Vector4 boundingBox)
        {
            List<KeyValuePair<float, List<MapTile>>> list = this.mapTiles.HSortedTiles;
            int index = MapTiles.FindIndexSortedTiles(boundingBox.W, list);
            if (index == list.Count)
                return 720f - boundingBox.W;
            for (int i = index; i < list.Count; ++i)
                foreach (MapTile tile in list[i].Value)
                    if (IsHorizontalValid(boundingBox, tile) == true)
                        return Math.Abs(list[i].Key - boundingBox.W);
            return 720f - boundingBox.W;
        }

        private float GetRightDistance(Vector4 boundingBox)
        {
            List<KeyValuePair<float, List<MapTile>>> list = this.mapTiles.VSortedTiles;
            int index = MapTiles.FindIndexSortedTiles(boundingBox.Z, list);
            if (index == list.Count)
                return 1280f - boundingBox.Z;               
            for (int i = index; i < list.Count; ++i)
                foreach (MapTile tile in list[i].Value)
                    if (IsVerticalValid(boundingBox, tile) == true)
                        return Math.Abs(list[i].Key - boundingBox.Z);
            return 1280f - boundingBox.Z;               
        }

        private float GetTopDistance(Vector4 boundingBox)
        {
            List<KeyValuePair<float, List<MapTile>>> list = this.mapTiles.HSortedTiles;
            int index = MapTiles.FindIndexSortedTiles(boundingBox.Y, list);
            if (index == list.Count)
                return boundingBox.Y;
            if (list[index].Key == boundingBox.Y)
                foreach (MapTile tile in list[index].Value)
                    if (IsHorizontalValid(boundingBox, tile) == true)
                        return 0;
            for (index = index - 1; index > -1; --index)
                foreach (MapTile tile in list[index].Value)
                    if (IsHorizontalValid(boundingBox, tile) == true)
                        return Math.Abs(list[index].Key - boundingBox.Y);
            return boundingBox.Y;
        }

        private bool IsHorizontalValid(Vector4 boundingBox, MapTile tile)
        {
            if (tile.Sprite2D.Depth == 0.1f)
                return false;
            if ((boundingBox.X > tile.BoundingBox.X && boundingBox.X < tile.BoundingBox.Z)
                ||
                (boundingBox.Z > tile.BoundingBox.X && boundingBox.Z < tile.BoundingBox.Z))
                return true;
            return false;
        }

        private float GetLeftDistance(Vector4 boundingBox)
        {
            List<KeyValuePair<float, List<MapTile>>> list = this.mapTiles.VSortedTiles;
            int index = MapTiles.FindIndexSortedTiles(boundingBox.X, list);
            if (index == list.Count)
                return boundingBox.X;
            if (list[index].Key == boundingBox.X)
                foreach (MapTile tile in list[index].Value)
                    if (IsVerticalValid(boundingBox, tile) == true)
                        return 0;
            for (index = index - 1; index > -1; --index )
                foreach (MapTile tile in list[index].Value)
                    if (IsVerticalValid(boundingBox, tile) == true)
                        return Math.Abs(list[index].Key - boundingBox.X);
            return boundingBox.X;
        }

        private bool IsVerticalValid(Vector4 boundingBox, MapTile tile)
        {
            if (tile.Sprite2D.Depth == 0.1f)
                return false;
            if ((boundingBox.Y > tile.BoundingBox.Y && boundingBox.Y < tile.BoundingBox.W)
                ||
                (boundingBox.W > tile.BoundingBox.Y && boundingBox.W < tile.BoundingBox.W))
                return true;
            return false;
        }

        public List<Vector4> GetDistances(List<Vector4> boundingBoxes)
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
