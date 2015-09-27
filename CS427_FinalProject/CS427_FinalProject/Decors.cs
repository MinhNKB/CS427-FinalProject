using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml;

namespace CS427_FinalProject
{
    class Decors : VisibleGameEntity
    {
        private List<Decor> decorList;

        public List<Decor> DecorList
        {
            get { return decorList; }
            set { decorList = value; }
        }

        public Decors(string fileName)
        {
            LoadDecors(fileName);
        }

        private void LoadDecors(string fileName)
        {
            this.decorList = new List<Decor>();

            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);

            XmlNodeList decorNodes = doc.DocumentElement.SelectNodes("/Maps/Map/Decors/Decor");
            foreach (XmlNode decorNode in decorNodes)
            {
                Decor newDecor = LoadDecorFromXmlNode(decorNode);
                this.decorList.Add(newDecor);
            }
        }

        private Decor LoadDecorFromXmlNode(XmlNode decorNode)
        {
            float left, top, depth;
            int type;
            left = float.Parse(decorNode.Attributes["Left"].Value.Replace(',', '.'), CultureInfo.InvariantCulture);
            top = float.Parse(decorNode.Attributes["Top"].Value.Replace(',', '.'), CultureInfo.InvariantCulture);
            depth = float.Parse(decorNode.Attributes["Depth"].Value.Replace(',', '.'), CultureInfo.InvariantCulture);
            type = int.Parse(decorNode.Attributes["Type"].Value.Replace(',', '.'), CultureInfo.InvariantCulture);
            Decor newDecor = new Decor(left, top, depth, type);
            return newDecor;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            foreach (Decor decor in this.decorList)
                decor.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, object param)
        {
            base.Draw(gameTime, param);
            foreach (Decor decor in this.decorList)
                decor.Draw(gameTime, param);
        }
    }
}
