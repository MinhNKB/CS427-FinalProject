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
                AddToVSortedTiles(newTile);
            }
        }

        private void AddToVSortedTiles(MapTile newTile)
        {
            int vIndex = FindIndex(newTile.BoundingBox.X, this.vSortedTiles);
            AddXToVSortedTiles(vIndex);
            vIndex = FindIndex(newTile.BoundingBox.Z, this.vSortedTiles);
            AddZToVSortedTiles(vIndex);
        }

        private void AddZToVSortedTiles(int vIndex)
        {
            throw new NotImplementedException();
        }

        private void AddXToVSortedTiles(int vIndex)
        {
            throw new NotImplementedException();
        }

        private int FindIndex(float p, List<MapTile> list)
        {
            throw new NotImplementedException();
        }

        private void AddToHSortedTiles(MapTile newTile)
        {
            int hIndex = FindIndex(newTile.BoundingBox.Y, this.hSortedTiles);
            addYToHSortedTiles(hIndex);
            hIndex = FindIndex(newTile.BoundingBox.W, this.hSortedTiles);
            addWToHSortedTiles(hIndex);
        }

        private void addWToHSortedTiles(int hIndex)
        {
            throw new NotImplementedException();
        }

        private void addYToHSortedTiles(int hIndex)
        {
            throw new NotImplementedException();
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
}
