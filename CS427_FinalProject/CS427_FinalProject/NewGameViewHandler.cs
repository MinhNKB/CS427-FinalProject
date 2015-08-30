using CS427_FinalProject.Buttons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS427_FinalProject
{
    class NewGameViewHandler : MenuViewHandler
    {
        public NewGameViewHandler()
        {
            this.buttons.Add(new Accept(656, 542));
            this.buttons.Add(new Menu(484, 542));
            this.buttons.Add(new MapButton(112, 64, ButtonType.ForrestMap));
            this.buttons.Add(new MapButton(656, 64, ButtonType.SnowMap));
            this.buttons[0].Click += AccpetButton_Click;
            this.buttons[1].Click += MenuButton_Click;
            this.buttons[2].Click += ForrestMapButton_Click;
            this.buttons[3].Click += SnowMapButton_Click;
            this.buttons[0].CurrentState = ButtonState.Locked;
        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            Global.gViewState = ViewState.MainMenuView;
        }

        private void AccpetButton_Click(object sender, EventArgs e)
        {
            Global.gViewState = ViewState.GameView;
        }

        private void SnowMapButton_Click(object sender, EventArgs e)
        {
            this.buttons[3].CurrentState = ButtonState.Locked;
            this.buttons[2].CurrentState = ButtonState.Normal;
            this.buttons[0].CurrentState = ButtonState.Normal;
        }

        private void ForrestMapButton_Click(object sender, EventArgs e)
        {
            this.buttons[2].CurrentState = ButtonState.Locked;
            this.buttons[3].CurrentState = ButtonState.Normal;
            this.buttons[0].CurrentState = ButtonState.Normal;
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime, object param)
        {
            base.Draw(gameTime, param);
            
        }
    }
}
