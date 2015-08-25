using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS427_FinalProject
{
    class Character : VisibleGameEntity
    {
        protected Dictionary<CharacterState,Sprite2D> characterSprites;

        protected int actualWidth = 60, actualHeight = 90;
        protected float actualBottom, actualLeft, paddingLeft, paddingTop, left, top;
        protected float horizontalVelocity, verticalVelocity;
        protected Keys lastKeyPressed = Keys.None;
        protected bool reverse = false;
        protected Keys keyUp, keyDown, keyLeft, keyRight;
        protected float jumpHeight;
        protected Vector4 distances;

        protected Vector4 Distances
        {
            get { return distances; }
            set { distances = value; }
        }

        public float ActualLeft
        {
            get { return actualLeft; }
            set { 
                actualLeft = value;
                left = actualLeft - paddingLeft;
            }
        }

        public float ActualBottom
        {
            get { return actualBottom; }
            set { 
                actualBottom = value;
                top = actualBottom - actualHeight - paddingTop;
            }
        }

        public Vector4 BoundingBox
        {
            get { return new Vector4(actualLeft,actualBottom-actualHeight,actualLeft+actualWidth,actualBottom); }            
        }

        private CharacterState currentState;

        public CharacterState CurrentState
        {
            get { return currentState; }
            set { 
                currentState = value;
                if (this.characterSprites.Count>0 && currentState!=CharacterState.None)
                    this.characterSprites[currentState].ITexture = 0;
                if(currentState == CharacterState.Fall)
                {
                    paddingLeft = 14;
                    paddingTop = 1;                    
                }
                else 
                {
                    paddingLeft = 20;
                    paddingTop = 3;
                   
                }
                
            }
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
            this.CurrentState = CharacterState.Idle;
        }

        protected void LoadSprites(CharacterTexture type)
        {
            Dictionary<CharacterState, List<Texture2D>> tmp = TextureFactory.characterTextures[type];
            foreach (CharacterState state in tmp.Keys)
            {
                this.characterSprites.Add(state, new Sprite2D(tmp[state], 0, 0, 0, 0));
                if (state != CharacterState.Idle && state != CharacterState.Run)
                    this.characterSprites[state].Repeat = false;
            }
        }

        public void Spawn(float left,float bottom)
        {
            this.ActualLeft = left;
            this.ActualBottom = bottom;
            this.currentState = CharacterState.Idle;
            this.verticalVelocity = 0;
            this.horizontalVelocity = 0;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (currentState != CharacterState.None)
            {
                if (currentState != CharacterState.Dead)
                {
                    if (Global.gKeyboardHelper.IsKeyPressed(keyRight))
                    {
                        if (distances.Z >= 10)
                            horizontalVelocity = 10;
                        else
                            horizontalVelocity = distances.Z;
                        lastKeyPressed = keyRight;
                        this.reverse = false;
                    }
                    if (Global.gKeyboardHelper.IsKeyPressed(keyLeft))
                    {
                        if (distances.X >= 10)
                            horizontalVelocity = -10;
                        else
                            horizontalVelocity = -distances.X;
                        lastKeyPressed = keyLeft;
                        this.reverse = true;
                    }
                    if (Global.gKeyboardHelper.IsKeyReleased(lastKeyPressed))
                    {
                        horizontalVelocity = 0;                        
                    }                    
                    if (this.currentState == CharacterState.Jump)
                    {
                        jumpHeight += verticalVelocity;
                        if(jumpHeight<=0)
                        {
                            this.CurrentState = CharacterState.Fall;
                            verticalVelocity = 15;
                        }                     
                    }
                    if (this.currentState == CharacterState.Fall)
                    {
                        jumpHeight += verticalVelocity;
                        if(jumpHeight>=150)
                        {
                            this.CurrentState = CharacterState.Idle;
                            if (Global.gKeyboardHelper.IsKeyDown(lastKeyPressed))
                            {
                                this.CurrentState = CharacterState.Run;
                                if (lastKeyPressed == keyLeft)
                                    this.reverse = true;
                                else
                                    this.reverse = false;
                            }
                            verticalVelocity = 0;
                        }                    
                    }
                    if (currentState != CharacterState.Jump && currentState != CharacterState.Fall)
                    {
                        if(Global.gKeyboardHelper.IsKeyPressed(keyLeft) || Global.gKeyboardHelper.IsKeyPressed(keyRight))
                            this.CurrentState = CharacterState.Run;
                        if(Global.gKeyboardHelper.IsKeyReleased(lastKeyPressed))
                            this.CurrentState = CharacterState.Idle;
                        if (Global.gKeyboardHelper.IsKeyDown(keyUp))
                        {
                            this.CurrentState = CharacterState.Jump;
                            jumpHeight = 150;
                            verticalVelocity = -15;
                            jumpHeight += verticalVelocity;
                        }
                    }
                }
                this.ActualLeft += horizontalVelocity;
                this.ActualBottom += verticalVelocity;
                this.characterSprites[this.CurrentState].Reverse = this.reverse;
                this.characterSprites[this.CurrentState].Left = this.left;
                this.characterSprites[this.CurrentState].Top = this.top;
                this.characterSprites[this.CurrentState].Update(gameTime);
            }
        }

        public override void Draw(GameTime gameTime, object param)
        {
            base.Draw(gameTime, param);
            if (currentState != CharacterState.None)
            {
                this.characterSprites[this.CurrentState].Draw(gameTime, (SpriteBatch)param);
            }
        }
    }
}
