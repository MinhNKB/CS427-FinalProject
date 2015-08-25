using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS427_FinalProject
{
    class Characters : VisibleGameEntity
    {
        private List<Character> characters;

        public List<Vector4> BoundingBoxes
        {
            get
            {
                List<Vector4> result = new List<Vector4>();
                foreach(Character character in this.characters)
                    result.Add(character.BoundingBox);
                return result;
            }
        }

        public void SetDistances(List<Vector4> distances)
        {
            for (int i = 0; i < distances.Count; ++i)
                characters[i].Distances = distances[i];
        }

        public Characters()
        {
            LoadCharacters();
            characters[0].Spawn(0, 592);
            characters[1].Spawn(500, 592);
        }

        private void LoadCharacters()
        {
            characters = new List<Character>();
            characters.Add(new Dog());
            characters.Add(new Cat());
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            for (int i = 0; i < characters.Count; ++i)
                characters[i].Update(gameTime);
        }

        public override void Draw(GameTime gameTime, object param)
        {
            base.Draw(gameTime, param);
            for (int i = 0; i < characters.Count; ++i)
                characters[i].Draw(gameTime, param);
        }
    }
}
