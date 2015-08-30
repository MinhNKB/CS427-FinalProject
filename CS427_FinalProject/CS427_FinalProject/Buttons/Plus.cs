using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS427_FinalProject.Buttons
{
    class Plus : Button
    {
        public Plus(float left, float top)
        {
            for(int i=0;i<3;i++)
            {
                ButtonState state = (ButtonState)i;
                this.buttonImages.Add(state, new Sprite2D(TextureFactory.buttonTextures[ButtonType.Plus][state], 0, 0, 0, 0));
            }
            this.Left = left;
            this.Top = top;
            this.width = buttonImages[0].Width;
            this.height = buttonImages[0].Height;
            this.CurrentState = ButtonState.Normal;            
        }

    }
}
