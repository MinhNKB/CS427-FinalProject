﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS427_FinalProject.Buttons
{
    class Setting : Button
    {
        public Setting(float left,float top)
        {
            for (int i = 0; i < 3; i++)
            {
                ButtonState state = (ButtonState)i;
                this.buttonImages.Add(state, new Sprite2D(TextureFactory.buttonTextures[ButtonType.Setting][state], 0, 0, 0, 0));
            }
            this.Left = left;
            this.Top = top;
            this.width = buttonImages[0].Width;
            this.height = buttonImages[0].Height;
            this.CurrentState = ButtonState.Normal;
        }

        protected override void OnClick()
        {
            base.OnClick();
            Global.gPreviousViewState = Global.gViewState;
            Global.gViewState = ViewState.SettingView;
        }
    }
}
