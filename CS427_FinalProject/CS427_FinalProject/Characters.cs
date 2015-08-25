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
        public Characters()
        {
            LoadCharacters();
            characters[0].Spawn(0, 500);
        }

        private void LoadCharacters()
        {
            characters = new List<Character>();
            characters.Add(new Dog());
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
