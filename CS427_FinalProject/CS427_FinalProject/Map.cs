﻿using Microsoft.Xna.Framework;
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

        private Box box;

        private Decors decors;

        public Map()
        {
            this.background = new Background();
            this.mapTiles = new MapTiles("Map_" + ((int)(Global.gMapState)).ToString("00") + ".xml");
            CreateBox();
            this.decors = new Decors("Map_" + ((int)(Global.gMapState)).ToString("00") + ".xml");
            Global.gMap = this;
        }

        DateTime lastCreatedBoxTime;
        private void CreateBox()
        {
            int effect = rand.Next(1, 5);
            Vector2 position = GetSpawnPosition();
            box = new Box(position.X, position.Y, 0.5f, effect);
            this.lastCreatedBoxTime = DateTime.Now;
        }

        public Vector4 GetDistance(Vector4 boundingBox)
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
            float result = 720f - boundingBox.W;
            if (result < 0)
                result = 0;
            List<KeyValuePair<float, List<MapTile>>> list = this.mapTiles.HSortedTiles;
            int index = MapTiles.FindIndexSortedTiles(boundingBox.W, list);
            if (index == list.Count)
                return result;
            for (int i = index; i < list.Count; ++i)
                foreach (MapTile tile in list[i].Value)
                    if (IsHorizontalValid(boundingBox, tile) == true)
                        return Math.Abs(list[i].Key - boundingBox.W);
            return result;
        }

        private float GetRightDistance(Vector4 boundingBox)
        {
            float result = 1280 - boundingBox.Z;
            if (result < 0)
                result = 0;
            List<KeyValuePair<float, List<MapTile>>> list = this.mapTiles.VSortedTiles;
            int index = MapTiles.FindIndexSortedTiles(boundingBox.Z, list);
            if (index == list.Count)
                return result;             
            for (int i = index; i < list.Count; ++i)
                foreach (MapTile tile in list[i].Value)
                    if (IsVerticalValid(boundingBox, tile) == true)
                        return Math.Abs(list[i].Key - boundingBox.Z);
            return result;         
        }

        private float GetTopDistance(Vector4 boundingBox)
        {
            float result = boundingBox.Y;
            if (result < 0)
                result = 0;
            List<KeyValuePair<float, List<MapTile>>> list = this.mapTiles.HSortedTiles;
            int index = MapTiles.FindIndexSortedTiles(boundingBox.Y, list);
            if (index == list.Count)
                return result;
            if (list[index].Key == boundingBox.Y)
                foreach (MapTile tile in list[index].Value)
                    if (IsHorizontalValid(boundingBox, tile) == true)
                        return 0;
            for (index = index - 1; index > -1; --index)
                foreach (MapTile tile in list[index].Value)
                    if (IsHorizontalValid(boundingBox, tile) == true)
                        return Math.Abs(list[index].Key - boundingBox.Y);
            return result;
        }

        private bool IsHorizontalValid(Vector4 boundingBox, MapTile tile)
        {
            if ((boundingBox.X > tile.BoundingBox.X && boundingBox.X < tile.BoundingBox.Z)
                ||
                (boundingBox.Z > tile.BoundingBox.X && boundingBox.Z < tile.BoundingBox.Z)
                ||
                (boundingBox.X <= tile.BoundingBox.X && boundingBox.Z >= tile.BoundingBox.Z))
                return true;
            return false;
        }

        private float GetLeftDistance(Vector4 boundingBox)
        {
            float result = boundingBox.X;
            if (result < 0)
                result = 0;
            List<KeyValuePair<float, List<MapTile>>> list = this.mapTiles.VSortedTiles;
            int index = MapTiles.FindIndexSortedTiles(boundingBox.X, list);
            if (index == list.Count)
                return result;
            if (list[index].Key == boundingBox.X)
                foreach (MapTile tile in list[index].Value)
                    if (IsVerticalValid(boundingBox, tile) == true)
                        return 0;
            for (index = index - 1; index > -1; --index )
                foreach (MapTile tile in list[index].Value)
                    if (IsVerticalValid(boundingBox, tile) == true)
                        return Math.Abs(list[index].Key - boundingBox.X);
            return result;
        }

        private bool IsVerticalValid(Vector4 boundingBox, MapTile tile)
        {
            if (tile.Sprite2D.Depth == 0.2f)
                return false;
            if ((boundingBox.Y > tile.BoundingBox.Y && boundingBox.Y < tile.BoundingBox.W)
                ||
                (boundingBox.W > tile.BoundingBox.Y && boundingBox.W < tile.BoundingBox.W)
                ||
                (boundingBox.Y <= tile.BoundingBox.Y && boundingBox.W >= tile.BoundingBox.W))
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

        public SpecialEffect GetEffect(Vector4 boundingBox)
        {
            if (IsBoxValid() && IsAbleToGetBox(boundingBox))
            {
                this.box.IsVisible = false;
                this.lastCreatedBoxTime = DateTime.Now;
                return this.box.Effect;
            }
            return SpecialEffect.None;
        }

        public bool isFront(Vector4 boundingBox)
        {
            List<KeyValuePair<float, List<MapTile>>> list = this.mapTiles.HSortedTiles;
            int index = MapTiles.FindIndexSortedTiles(boundingBox.W, list);
            for (int i = index; i < list.Count; ++i)
                foreach (MapTile tile in list[i].Value)
                    if (IsHorizontalValid(boundingBox, tile) == true)
                        if (tile.Sprite2D.Depth == 0.3f)
                            return true;
                        else
                            return false;
            return false;
        }

        private bool IsAbleToGetBox(Vector4 boundingBox)
        {
            if ((boundingBox.W <= this.box.BoundingBox.Y + 20 && boundingBox.W >= this.box.BoundingBox.Y))
                if ((boundingBox.X > box.BoundingBox.X && boundingBox.X < box.BoundingBox.Z)
                    ||
                    (boundingBox.Z > box.BoundingBox.X && boundingBox.Z < box.BoundingBox.Z)
                    ||
                    (boundingBox.X <= box.BoundingBox.X && boundingBox.Z >= box.BoundingBox.Z))
                        return true;
            return false;
        }

        private bool IsBoxValid()
        {
            return this.box.IsVisible;
        }

        public List<SpecialEffect> GetEffects(List<Vector4> boudingBoxes)
        {
            List<SpecialEffect> result = new List<SpecialEffect>();
            for (int i = 0; i < boudingBoxes.Count; ++i)
                result.Add(GetEffect(boudingBoxes[i]));
            return result;
        }

        private Random rand = new Random();
        public Vector2 GetSpawnPosition()
        {
            int index00 = rand.Next(0, this.mapTiles.HSortedTiles.Count);
            int index01 = rand.Next(0, this.mapTiles.HSortedTiles[index00].Value.Count);
            MapTile spawnTile = this.mapTiles.HSortedTiles[index00].Value[index01];
            return new Vector2(spawnTile.BoundingBox.X, spawnTile.BoundingBox.Y);
        }

        public bool HasNextBottomEdge(Vector4 boundingBox)
        {
            List<KeyValuePair<float, List<MapTile>>> list = this.mapTiles.HSortedTiles;
            int index = MapTiles.FindIndexSortedTiles(boundingBox.W, list);
            ++index;
            for (int i = index; i < list.Count; ++i)
                foreach (MapTile tile in list[i].Value)
                    if (IsHorizontalValid(boundingBox, tile) == true)
                        return true;
            return false;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            this.background.Update(gameTime);
            this.mapTiles.Update(gameTime);
            CreateNextBox();
            this.box.Update(gameTime);
            this.decors.Update(gameTime);
        }

        private void CreateNextBox()
        {
            DateTime cur = DateTime.Now;
            if ((cur - this.lastCreatedBoxTime).Seconds >= 6)
                CreateBox();
        }

        public override void Draw(GameTime gameTime, object param)
        {
            base.Draw(gameTime, param);
            this.background.Draw(gameTime, param);
            this.mapTiles.Draw(gameTime, param);
            this.box.Draw(gameTime, param);
            this.decors.Draw(gameTime, param);
        }
    }
}
