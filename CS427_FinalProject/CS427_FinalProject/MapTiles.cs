using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace CS427_FinalProject
{
    class MapTiles : VisibleGameEntity
    {
        private const string fileName = "Map.xml";
        private List<MapTile> tiles;

        public List<MapTile> Tiles
        {
            get { return tiles; }
            set { tiles = value; }
        }

        private List<MapTile> vSortedTiles;
        private List<MapTile> hSortedTiles;

        public MapTiles()
        {
            LoadMapTiles();
        }

        private void LoadMapTiles()
        {
            tiles = new List<MapTile>();
            vSortedTiles = new List<MapTile>();
            hSortedTiles = new List<MapTile>();

            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);

            XmlNodeList tileNodes = doc.DocumentElement.SelectNodes("/Maps/Map/Tiles/Tile");
            foreach (XmlNode tileNode in tileNodes)
            {
                MapTile newTile = LoadTileFromXmlNode(tileNode);
                tiles.Add(newTile);
                AddToHSortedTiles(newTile);
                //AddToVSortedTiles(newTile);
            }
        }

        private void AddToVSortedTiles(MapTile newTile)
        {
            int index = FindIndexSortedTiles(newTile.BoundingBox.Y, this.vSortedTiles, BoundingBoxEdge.X);
            this.vSortedTiles.Insert(index, newTile);
            index = FindIndexSortedTiles(newTile.BoundingBox.Z, this.vSortedTiles, BoundingBoxEdge.Z);
            this.vSortedTiles.Insert(index, newTile);
        }

        private void AddToHSortedTiles(MapTile newTile)
        {
            int index = FindIndexSortedTiles(newTile.BoundingBox.Y, this.hSortedTiles, BoundingBoxEdge.Y);
            this.hSortedTiles.Insert(index, newTile);
            index = FindIndexSortedTiles(newTile.BoundingBox.W, this.hSortedTiles, BoundingBoxEdge.W);
            this.hSortedTiles.Insert(index, newTile);
        }

        private int FindIndexSortedTiles(float key, List<MapTile> list, BoundingBoxEdge boundingBoxEdge)
        {
            if (list.Count == 0)
                return 0;
            int left, right, pivot;
            left = 0;
            right = list.Count;
            pivot = (left + right) / 2;
            list[pivot].CurrentEdge = boundingBoxEdge;
            while (left <= right)
            {
                if (list[pivot].CurrentEdgeValue == key)
                    return pivot;
                else if (key > list[pivot].CurrentEdgeValue)
                    left = pivot + 1;
                else
                    right = pivot - 1;
                pivot = (left + right) / 2;
                list[pivot].CurrentEdge = boundingBoxEdge;
            }
            if (list[pivot].CurrentEdgeValue < key)
                return pivot + 1;
            return pivot;
        }

        private static MapTile LoadTileFromXmlNode(XmlNode tileNode)
        {
            float height, width, left, top, depth;
            int type;
            height = float.Parse(tileNode.Attributes["Height"].Value);
            width = float.Parse(tileNode.Attributes["Width"].Value);
            left = float.Parse(tileNode.Attributes["Left"].Value);
            top = float.Parse(tileNode.Attributes["Top"].Value);
            depth = float.Parse(tileNode.Attributes["Depth"].Value);
            type = int.Parse(tileNode.Attributes["Type"].Value);
            MapTile newTile = new MapTile(height, width, left, top, depth, type);
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

    enum BoundingBoxEdge
    {
        X = 0,
        Y = 1,
        Z = 2,
        W = 3
    }
}
