using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS427_FinalProject.Buttons
{
    abstract class Button : VisibleGameEntity
    {
        protected Dictionary<ButtonState, Sprite2D> buttonImages;
        protected Sprite2D currentImage;
        private ButtonState currentState;

        public Button()
        {
            buttonImages = new Dictionary<ButtonState, Sprite2D>();
        }

        protected ButtonState CurrentState
        {
            get { return currentState; }
            set { 
                currentState = value; 
                if(currentState==ButtonState.Normal)
                {
                    OnNormal();
                }
                else if(currentState==ButtonState.Hover)
                {
                    OnHover();
                }
                else
                {
                    OnClick();
                }
            }
        }

        protected virtual void OnClick()
        {
            
        }

        protected virtual void OnHover()
        {
            
        }

        protected virtual void OnNormal()
        {
            
        }

        protected float left, top;

        public float Top
        {
            get { return top; }
            set { 
                top = value;
                foreach(ButtonState s in buttonImages.Keys)
                {
                    buttonImages[s].Top = top;
                }
            }
        }

        public float Left
        {
            get { return left; }
            set { 
                left = value;
                foreach (ButtonState s in buttonImages.Keys)
                {
                    buttonImages[s].Left = left;
                }
            }
        }
        protected int width, height; 
        

        public Vector4 BoundingBox
        {
            get
            {
                return new Vector4(left, top, left + width, top + height);
            }
        }

        protected void GetState()
        {
            //naive
            Vector2 mousePosition = Global.gMousetHelper.GetCurrentMousePosition();
            if(Global.gMousetHelper.IsLeftButtonPressed())
            {
                if(IsMouseOver(mousePosition))
                {
                    CurrentState = ButtonState.Click;
                }
            }
            else 
            {
                if (IsMouseOver(mousePosition))
                    CurrentState = ButtonState.Hover;
                else
                    CurrentState = ButtonState.Normal;
            }            
        }

        private bool IsMouseOver(Vector2 mousePosition)
        {
            if(mousePosition.X>=BoundingBox.X && mousePosition.X<=BoundingBox.Z)
            {
                if(mousePosition.Y>=BoundingBox.Y && mousePosition.Y<=BoundingBox.W)
                {
                    return true;
                }
            }
            return false;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            GetState();
        }

        public override void Draw(GameTime gameTime, object param)
        {
            base.Draw(gameTime, param);
            buttonImages[currentState].Draw(gameTime, param as SpriteBatch);
        }
    }
}
