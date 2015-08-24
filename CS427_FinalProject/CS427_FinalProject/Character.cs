using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS427_FinalProject
{
    class Character : VisibleGameEntity
    {
        protected Dictionary<CharacterState,Sprite2D> characterSprites;

        private Vector4 boundingBox;

        public Vector4 BoundingBox
        {
            get { return boundingBox; }
            set { boundingBox = value; }
        }

        private CharacterState currentState;

        public CharacterState CurrentState
        {
            get { return currentState; }
            set { currentState = value; }
        }

        private SpecialEffect currentEffect;

        public SpecialEffect CurrentEffect
        {
            get { return currentEffect; }
            set { currentEffect = value; }
        }

        public Character()
        {
            this.characterSprites = new Dictionary<CharacterState, Sprite2D>();
            this.currentState = CharacterState.Idle;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            this.characterSprites[currentState].Update(gameTime);
        }

        public override void Draw(GameTime gameTime, object param)
        {
            base.Draw(gameTime, param);
            this.characterSprites[currentState].Draw(gameTime, (SpriteBatch)param);
        }
    }
}
