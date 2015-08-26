using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace CS427_FinalProject
{
    class Character : VisibleGameEntity
    {
        public event EventHandler Respawn;
        private void OnRespawn()
        {
            if(Respawn!=null)
            {
                Respawn(this, new EventArgs());
            }
        }

        protected Dictionary<CharacterState,Sprite2D> characterSprites;

        protected int actualWidth = 60, actualHeight = 90;
        protected float actualBottom, actualLeft, paddingLeft, paddingTop, left, top;
        protected float horizontalDirection, verticalVelocity;
        protected Keys lastKeyPressed = Keys.None;
        protected bool reverse = false;
        protected Keys keyUp, keyDown, keyLeft, keyRight;
        protected float jumpHeight;
        protected Vector4 distances;
        protected int delayRespawn, effectDuration;
        protected int hasteFactor = 1;

        public Vector4 Distances
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
            get { return new Vector4(actualLeft + 15, actualBottom - actualHeight, actualLeft + actualWidth - 15, actualBottom); }            
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
                if(currentState == CharacterState.Jump)
                {
                    if (this.currentEffect == SpecialEffect.DoubleJump)
                        jumpHeight = 250;
                    else
                        jumpHeight = 150;
                    verticalVelocity = -15;
                }
                
            }
        }

        private SpecialEffect currentEffect;

        public SpecialEffect CurrentEffect
        {
            get { return currentEffect; }
            set { 
                currentEffect = value;
                if (currentEffect != SpecialEffect.None)
                    this.effectDuration = 150;
            }
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
            this.horizontalDirection = 0;
            this.delayRespawn = 20;            
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (currentState != CharacterState.None)
            {
                if (currentState != CharacterState.Dead)
                {
                    float basicHorizontalVelocity;

                    if (currentEffect == SpecialEffect.Haste)
                        basicHorizontalVelocity = 25;
                    else
                        basicHorizontalVelocity = 15;

                    Keys keyRight, keyLeft;
                    if(currentEffect == SpecialEffect.Reverse)
                    {
                        keyRight = this.keyLeft;
                        keyLeft = this.keyRight;
                    }
                    else
                    {
                        keyRight = this.keyRight;
                        keyLeft = this.keyLeft;
                    }

                    if (Global.gKeyboardHelper.IsKeyPressed(keyRight))
                    {
                        horizontalDirection = 1;
                        lastKeyPressed = keyRight;
                        this.reverse = false;
                    }
                    if (Global.gKeyboardHelper.IsKeyPressed(keyLeft))
                    {
                        horizontalDirection = -1;
                        lastKeyPressed = keyLeft;
                        this.reverse = true;
                    }                   

                    if (Global.gKeyboardHelper.IsKeyReleased(lastKeyPressed))
                    {
                        horizontalDirection = 0;                        
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

                    if (distances.X < basicHorizontalVelocity && horizontalDirection == -1)
                        basicHorizontalVelocity = distances.X;
                    else if (distances.Z < basicHorizontalVelocity && horizontalDirection == 1)
                        basicHorizontalVelocity = distances.Z;
                    this.ActualLeft += horizontalDirection * basicHorizontalVelocity;

                    this.Distances = Global.gMap.GetDistance(this.BoundingBox);

                    if (this.currentState != CharacterState.Jump && this.currentState != CharacterState.Fall && distances.W > 0)
                        this.CurrentState = CharacterState.Fall;
                    if (this.currentState == CharacterState.Fall)
                    {
                        if(distances.W>0)
                        {
                            if (distances.W >= 15)
                                verticalVelocity = 15;
                            else
                                verticalVelocity = distances.W;
                        }
                        else
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
                        if (Global.gKeyboardHelper.IsKeyPressed(keyUp) && this.currentEffect != SpecialEffect.NoJump)
                        {
                            this.CurrentState = CharacterState.Jump;                                                       
                        }
                    }                    
                }
                else
                {
                    if (distances.W >= 15)
                        verticalVelocity = 15;
                    else
                        verticalVelocity = distances.W;    
                    if(verticalVelocity==0)
                    {
                        if(delayRespawn--==0)
                            OnRespawn();
                    }
                }
   

                if (this.ActualBottom == 720)
                    this.CurrentState = CharacterState.Dead;

                if (this.ActualBottom > 720 - 128)
                    this.characterSprites[this.CurrentState].Depth = 0.05f;
                else
                    this.characterSprites[this.CurrentState].Depth = 1;

                this.ActualBottom += verticalVelocity;    
                this.characterSprites[this.CurrentState].Reverse = this.reverse;
                this.characterSprites[this.CurrentState].Left = this.left;
                this.characterSprites[this.CurrentState].Top = this.top;
                this.characterSprites[this.CurrentState].Update(gameTime);
                if(this.effectDuration--==0)
                {
                    this.CurrentEffect = SpecialEffect.None;
                }
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
