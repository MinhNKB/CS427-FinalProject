using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace CS427_FinalProject
{
    class Characters : VisibleGameEntity
    {
        private List<Character> characters;
        private EffectNotification effectNotification = new EffectNotification();

        internal List<Character> ListCharacters
        {
            get { return characters; }
            set { characters = value; }
        }

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
            Spawn(characters[0]);
            Spawn(characters[1]);
        }

        private void LoadCharacters()
        {
            characters = new List<Character>();
            characters.Add(new Cat());
            characters.Add(new Dog());
            foreach(Character c in characters)
                c.Respawn += c_Respawn;
        }

        void c_Respawn(object sender, EventArgs e)
        {
            Spawn(sender as Character);            
        }

        private static void Spawn(Character character)
        {
            Vector2 newPosition = Global.gMap.GetSpawnPosition();
            character.Spawn(newPosition.X, newPosition.Y);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            foreach (Character c in characters)
            {
                if (c.CurrentState == CharacterState.Fall)
                {
                    SpecialEffect effect = Global.gMap.GetEffect(c.BoundingBox);
                    if (effect != SpecialEffect.None)
                    {
                        c.CurrentState = CharacterState.Jump;
                        if (effect != SpecialEffect.NoJump)
                        {
                            c.CurrentEffect = effect;
                            effectNotification.Show(effect, c.BoundingBox);
                        }
                        else
                        {
                            int index = characters.IndexOf(c);
                            if (index == 0)
                                index = 1;
                            else
                                index = 0;
                            characters[index].CurrentEffect = SpecialEffect.NoJump;
                            effectNotification.Show(effect, characters[index].BoundingBox);
                        }                        
                    }
                }
            }
            effectNotification.Update(gameTime);
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
                    if (c1 != c2 && c1.BoundingBox.W >= c2.BoundingBox.Y && c1.BoundingBox.W <= c2.BoundingBox.Y + 45 && c1.CurrentState == CharacterState.Fall && c2.CurrentState != CharacterState.Dead && c2.CurrentEffect != SpecialEffect.Immortal)
                    {
                        if((c1.BoundingBox.X >= c2.BoundingBox.X && c1.BoundingBox.X <=c2.BoundingBox.Z) || (c1.BoundingBox.Z >= c2.BoundingBox.X && c1.BoundingBox.Z <=c2.BoundingBox.Z))
                        {
                            c2.CurrentState = CharacterState.Dead;
                            c1.CurrentState = CharacterState.Jump;
                            c1.Point++;
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
            effectNotification.Draw(gameTime, param);
        }
    }
}
