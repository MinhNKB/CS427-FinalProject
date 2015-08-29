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
            //this.buttons.Add(new Accept(555, 525));
            //this.buttons.Add(new Menu(369, 542));
            //this.buttons.Add(new Exit(777, 542));
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
