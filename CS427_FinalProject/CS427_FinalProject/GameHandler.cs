using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS427_FinalProject
{
    public class GameHandler : VisibleGameEntity
    {
        Dictionary<ViewState, ViewHandler> viewHandlers;
        public GameHandler()
        {
            viewHandlers = new Dictionary<ViewState, ViewHandler>();

            viewHandlers.Add(ViewState.GameView, new GameViewHandler());
            viewHandlers.Add(ViewState.MainMenuView, new MainMenuViewHandler());
            viewHandlers.Add(ViewState.NewGameView, new NewGameViewHandler());
            //viewHandlers.Add(ViewState.MenuView, new MenuViewHandler());
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            viewHandlers[Global.gViewState].Update(gameTime);
        }

        public override void Draw(GameTime gameTime, object param)
        {
            base.Draw(gameTime, param);
            viewHandlers[Global.gViewState].Draw(gameTime, param);
        }
        
    }
}
