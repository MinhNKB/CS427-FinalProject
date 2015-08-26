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
            characters[1].Spawn(0, 592);
        }

        private void LoadCharacters()
        {
            characters = new List<Character>();
            characters.Add(new Dog());
            characters.Add(new Cat());
            foreach(Character c in characters)
                c.Respawn += c_Respawn;
        }

        void c_Respawn(object sender, EventArgs e)
        {
            (sender as Character).Spawn(0, 592);
            if ((sender as Dog) != null)
                (sender as Character).CurrentEffect = SpecialEffect.Haste;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);            
            if (Global.gKeyboardHelper.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.S))
                characters[0].CurrentState = CharacterState.Dead;
            CheckKill();
            for (int i = 0; i < characters.Count; ++i)
                characters[i].Update(gameTime);
           
        }

        private void CheckKill()
        {
            foreach(Character c1 in characters)
            {
                foreach(Character c2 in characters)
                {
                    if (c1.BoundingBox.W >= c2.BoundingBox.Y - 10 && c1.BoundingBox.W <= c2.BoundingBox.Y + 10 && c1.CurrentState == CharacterState.Fall && c2.CurrentState != CharacterState.Dead)
                    {
                        if((c1.BoundingBox.X >= c2.BoundingBox.X && c1.BoundingBox.X <=c2.BoundingBox.Z) || (c1.BoundingBox.Z >= c2.BoundingBox.X && c1.BoundingBox.Z <=c2.BoundingBox.Z))
                        {
                            c2.CurrentState = CharacterState.Dead;
                            c1.CurrentState = CharacterState.Jump;
                        }
                    }
                }
            }
        }

        public override void Draw(GameTime gameTime, object param)
        {
            base.Draw(gameTime, param);
            for (int i = 0; i < characters.Count; ++i)
                characters[i].Draw(gameTime, param);
        }
    }
}
