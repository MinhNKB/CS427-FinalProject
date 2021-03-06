﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml;

namespace CS427_FinalProject
{
    class MapTiles : VisibleGameEntity
    {
        private List<MapTile> tiles;

        public List<MapTile> Tiles
        {
            get { return tiles; }
            set { tiles = value; }
        }

        private List<KeyValuePair<float, List<MapTile>>> vSortedTiles;

        public List<KeyValuePair<float, List<MapTile>>> VSortedTiles
        {
            get { return vSortedTiles; }
            set { vSortedTiles = value; }
        }

        private List<KeyValuePair<float, List<MapTile>>> hSortedTiles;

        public List<KeyValuePair<float, List<MapTile>>> HSortedTiles
        {
            get { return hSortedTiles; }
            set { hSortedTiles = value; }
        }

        public MapTiles(string fileName)
        {
            LoadMapTiles(fileName);
        }

        private void LoadMapTiles(string fileName)
        {
            tiles = new List<MapTile>();
            vSortedTiles = new List<KeyValuePair<float, List<MapTile>>>();
            hSortedTiles = new List<KeyValuePair<float, List<MapTile>>>();

            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);

            XmlNodeList tileNodes = doc.DocumentElement.SelectNodes("/Maps/Map/Tiles/Tile");
            foreach (XmlNode tileNode in tileNodes)
            {
                MapTile newTile = LoadTileFromXmlNode(tileNode);
                tiles.Add(newTile);
                AddToHSortedTiles(newTile);
                AddToVSortedTiles(newTile);
            }
        }

        private void AddToVSortedTiles(MapTile newTile)
        {
            int index = FindIndexSortedTiles(newTile.BoundingBox.X, this.vSortedTiles);
            if (index != this.vSortedTiles.Count && vSortedTiles[index].Key == newTile.BoundingBox.X)
                vSortedTiles[index].Value.Add(newTile);
            else
            {
                List<MapTile> tmp = new List<MapTile>();
                tmp.Add(newTile);
                this.vSortedTiles.Insert(index, new KeyValuePair<float, List<MapTile>>(newTile.BoundingBox.X, tmp));
            }
            index = FindIndexSortedTiles(newTile.BoundingBox.Z, this.vSortedTiles);
            if (index != this.vSortedTiles.Count && vSortedTiles[index].Key == newTile.BoundingBox.Z)
                vSortedTiles[index].Value.Add(newTile);
            else
            {
                List<MapTile> tmp = new List<MapTile>();
                tmp.Add(newTile);
                this.vSortedTiles.Insert(index, new KeyValuePair<float, List<MapTile>>(newTile.BoundingBox.Z, tmp));
            }
        }

        private void AddToHSortedTiles(MapTile newTile)
        {
            if (newTile.Type == 0 || newTile.Type == 1 || newTile.Type == 2 || newTile.Type == 6 || newTile.Type == 10 || newTile.Type == 12 || newTile.Type == 13 || newTile.Type == 14)
            {
                int index = FindIndexSortedTiles(newTile.BoundingBox.Y, this.hSortedTiles);
                if (index != this.hSortedTiles.Count && hSortedTiles[index].Key == newTile.BoundingBox.Y)
                    hSortedTiles[index].Value.Add(newTile);
                else
                {
                    List<MapTile> tmp = new List<MapTile>();
                    tmp.Add(newTile);
                    this.hSortedTiles.Insert(index, new KeyValuePair<float, List<MapTile>>(newTile.BoundingBox.Y, tmp));
                }
            }
        }

        public static int FindIndexSortedTiles(float key, List<KeyValuePair<float, List<MapTile>>> list)
        {
            if (list.Count == 0)
                return 0;
            int left, right, mid;
            left = 0;
            right = list.Count - 1;
            mid = (left + right) / 2;
            while (left <= right)
            {
                mid = (left + right) / 2;
                if (list[mid].Key == key)
                    return mid;
                else if (key > list[mid].Key)
                    left = mid + 1;
                else
                    right = mid - 1;
            }
            if (list[mid].Key < key)
                return mid + 1;
            return mid;
        }

        private static MapTile LoadTileFromXmlNode(XmlNode tileNode)
        {
            float left, top, depth;
            int type;
            left = float.Parse(tileNode.Attributes["Left"].Value.Replace(',', '.'), CultureInfo.InvariantCulture);
            top = float.Parse(tileNode.Attributes["Top"].Value.Replace(',', '.'), CultureInfo.InvariantCulture);
            depth = float.Parse(tileNode.Attributes["Depth"].Value.Replace(',', '.'), CultureInfo.InvariantCulture);
            type = int.Parse(tileNode.Attributes["Type"].Value.Replace(',', '.'), CultureInfo.InvariantCulture);
            MapTile newTile = new MapTile(left, top, depth, type);
            return newTile;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            foreach(MapTile tile in this.tiles)
                tile.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, object param)
        {
            base.Draw(gameTime, param);
            foreach(MapTile tile in this.tiles)
                tile.Draw(gameTime, param);
        }
    }
}
